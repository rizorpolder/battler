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

		private ResourceModel _resourceModel;

		public int Soft => _resourceModel.Soft;
		public int Hard => _resourceModel.Hard;
		public int Level => _resourceModel.Level;
		public int Experience => _resourceModel.Experience;

		private void SetSoft(int soft, bool castEvent = true)
		{
			var previous = Soft;
			_resourceModel.SetSoft(soft);
			if (castEvent)
				SoftResourceChanged?.Invoke(previous, Soft);
		}

		private void SetHard(int hard, bool castEvent = true)
		{
			var previous = Hard;
			_resourceModel.SetHard(hard);
			if (castEvent)
				HardResourceChanged?.Invoke(previous, Hard);
		}

		private void SetLevel(int level, bool castEvent = true)
		{
			var previous = Level;
			_resourceModel.SetLevel(level);
			if (castEvent)
				LevelResourceChanged?.Invoke(previous, Level);
		}

		private void SetExperience(int exp, bool castEvent = true)
		{
			var previous = Experience;
			_resourceModel.SetExperience(exp);
			if (castEvent)
				ExperienceResourceChanged?.Invoke(previous, Experience);
		}

		#endregion

		[Inject]
		public void Initialize(IDataSaverCommand saverCommand)
		{
			if (!saverCommand.TryLoadData(SaveDataType.Resource, out ResourceData result))
			{
				result = ResourceData.Default;
			}

			_resourceModel = new ResourceModel();
			ApplyData(result);
		}

		private void ApplyData(ResourceData data, bool castEvent = false)
		{
			SetSoft(data.Soft, castEvent);
			SetHard(data.Hard, castEvent);
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
					SetSoft(Soft + amount);
					break;
				case ResourceType.Hard:
					SetHard(Hard + amount);
					break;
				case ResourceType.Level:
					SetLevel(Level + amount);
					break;
				case ResourceType.Experience:
					SetExperience(Experience + amount);
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