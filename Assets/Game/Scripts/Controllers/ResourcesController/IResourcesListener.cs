using System;

namespace Game.Scripts.Controllers.Resources
{
	public interface IResourcesListener
	{
		public event Action<int,int> SoftResourceChanged;
		public event Action<int,int> HardResourceChanged;
		public event Action<int,int> LevelResourceChanged;
		public event Action<int,int> ExperienceResourceChanged;
	}
}