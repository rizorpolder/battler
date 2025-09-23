using Game.Scripts.Data;
using Game.Scripts.LoadingSystem;
using Game.Scripts.Network.WebSocketController;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class GlobalSceneContext : LifetimeScope
	{
		[SerializeField] private WSController _wsController;

		protected override void Configure(IContainerBuilder builder)
		{
			DontDestroyOnLoad(this);

			builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.RegisterComponent(_wsController).AsImplementedInterfaces();
			builder.RegisterBuildCallback(resolver =>
			{
				var sceneLoader = resolver.Resolve<ISceneCommand>();
				sceneLoader.LoadScene(SceneNames.Menu);
			});
		}
	}
}