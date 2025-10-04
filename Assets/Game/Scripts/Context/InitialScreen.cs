using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class InitialScreen :IInitializable, IAsyncStartable
	{
		[Inject] private ISceneCommand _command;

		void IInitializable.Initialize()
		{
			//вызывается до сборки контейнера, но при этом все инъекции уже есть
		}

		public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
		{
			//Load assets
			//Load Data
			//Initialize Services and Features (Ads, monetization, etc)
			//await UniTask.Delay(TimeSpan.FromSeconds(4));

			_command.LoadScene(SceneNames.Menu);
		}
	}
}