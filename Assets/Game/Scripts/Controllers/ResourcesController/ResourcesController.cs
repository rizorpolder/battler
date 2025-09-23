using System;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Game.Scripts.Resources;
using Game.Scripts.Services.SaveDataService;
using VContainer;

namespace Game.Scripts.Controllers.Resources
{
	public class ResourcesController : IResourcesListener, IResourcesData, IResourcesCommand
	{
		public event Action<int, int> SoftResourceChanged;
		public event Action<int, int> HardResourceChanged;
		public event Action<int, int> LevelResourceChanged;
		public event Action<int, int> ExperienceResourceChanged;

		#region ResourceData

		private int _soft;
		private int _hard;
		private int _level;
		private int _experience;

		public int Soft => _soft;
		public int Hard => _hard;
		public int Level => _level;
		public int Experience => _experience;

		private void SetSoft(int soft, bool castEvent = true)
		{
			var previous = _soft;
			_soft = soft;
			if (castEvent)
				SoftResourceChanged?.Invoke(previous, _soft);
		}

		private void SetHard(int hard, bool castEvent = true)
		{
			var previous = _hard;
			_hard = hard;
			if (castEvent)
				HardResourceChanged?.Invoke(previous, _hard);
		}

		private void SetLevel(int level, bool castEvent = true)
		{
			var previous = _level;
			_level = level;
			if (castEvent)
				LevelResourceChanged?.Invoke(previous, _level);
		}

		private void SetExperience(int exp, bool castEvent = true)
		{
			var previous = _experience;
			_experience = exp;
			if (castEvent)
				ExperienceResourceChanged?.Invoke(previous, _experience);
		}

		#endregion

		[Inject]
		public void Initialize(IDataSaverCommand saverCommand)
		{
			if (!saverCommand.TryLoadData(SaveDataType.Resource, out ResourceData result))
			{
				result = ResourceData.Default;
			}

			ApplyData(result);
		}

		private void ApplyData(ResourceData data, bool castEvent = false)
		{
			SetSoft(data.Soft, castEvent);
			SetHard(data.Hard, castEvent);
			SetLevel(data.Level, castEvent);
			SetExperience(data.Experience, castEvent);
		}

		public void AddResource(Resource resource)
		{
			AddResource(resource.Type, resource.Amount);
		}

		public void AddResource(ResourceType type, int amount)
		{
			switch (type)
			{
				case ResourceType.Soft:
					SetSoft(_soft + amount);
					break;
				case ResourceType.Hard:
					SetHard(_hard + amount);
					break;
				case ResourceType.Level:
					SetLevel(_level + amount);
					break;
				case ResourceType.Experience:
					SetExperience(_experience + amount);
					break;
			}
		}

		public bool SpendResource(Resource resource)
		{
			if (!HasEnough(resource)) return false;
			var spendResource = new Resource(resource.Type, resource.Id, -resource.Amount);
			AddResource(spendResource);
			return true;
		}

		public bool HasEnough(Resource resource)
		{
			var amount = GetCommonResourceCount(resource.Type);
			bool isEnough = resource.Amount <= amount;
			return isEnough;
		}

		private int GetCommonResourceCount(ResourceType resourceType)
		{
			switch (resourceType)
			{
				case ResourceType.Soft:
					return Soft;
				case ResourceType.Hard:
					return Hard;
				case ResourceType.Level:
					return Level;
				case ResourceType.Experience:
					return Experience;
				default: return 0;
			}
		}
	}
}