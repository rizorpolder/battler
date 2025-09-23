using System;

namespace Game.Scripts.LoadingService
{
	public interface ISceneListener
	{
		public event Action<string> OnStartSceneLoad;
		public event Action<string> OnSceneLoaded;
		public event Action<string> OnStartSceneUnload;
		public event Action<string> OnSceneUnloaded;
	}
}