using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using Game.Scripts.Services.NetworkService;
using Game.Scripts.Services.SaveDataService;
using Game.Scripts.Services.SaveDataService.DataSerializer;
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
			
			builder.Register<JSONDataSerializer>(Lifetime.Scoped).As<IDataSerializer>();
			
			builder.Register<PlayerPrefsDataSaver>(Lifetime.Singleton).As<IDataSaver>()
				.WithParameter(new JSONDataSerializer());
			
			builder.RegisterComponent(_wsController).AsImplementedInterfaces();


			builder.RegisterBuildCallback(resolver =>
			{
				var sceneLoader = resolver.Resolve<ISceneCommand>();
				sceneLoader.LoadScene(SceneNames.Menu);
			});
		}
	}
}