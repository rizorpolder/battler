using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Scripts.LoadingService
{
	public class SceneLoader : ISceneCommand, ISceneListener
	{
		public event Action<string> OnStartSceneLoad;
		public event Action<string> OnSceneLoaded;
		public event Action<string> OnStartSceneUnload;
		public event Action<string> OnSceneUnloaded;

		public async void LoadScene(string sceneName)
		{
			await LoadAsync(sceneName);
		}

		private async UniTask LoadAsync(string sceneName)
		{
			OnStartSceneLoad?.Invoke(sceneName);
			await SceneManager.LoadSceneAsync(sceneName).ToUniTask();
			OnSceneLoaded?.Invoke(sceneName);
		}

		public async void UnloadScene(string sceneName)
		{
			await UnloadAsync(sceneName);
		}

		private async UniTask UnloadAsync(string sceneName)
		{
			OnStartSceneUnload?.Invoke(sceneName);
			await SceneManager.UnloadSceneAsync(sceneName).ToUniTask();
			OnSceneUnloaded?.Invoke(sceneName);
		}
	}
}