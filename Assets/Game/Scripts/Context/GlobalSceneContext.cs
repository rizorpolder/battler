using Game.Scripts.Configs;
using Game.Scripts.Controllers.Resources;
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
		[SerializeField] private ConfigsRepository _configsRepository;
		[SerializeField] private WSController _wsController;

		protected override void Configure(IContainerBuilder builder)
		{
			DontDestroyOnLoad(this);

			builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();

			builder.Register<ResourcesController>(Lifetime.Singleton).AsImplementedInterfaces();

			//Save Data Service
			builder.Register<JSONDataSerializer>(Lifetime.Scoped).As<IDataSerializer>();
			builder.Register<PlayerPrefsDataSaver>(Lifetime.Singleton).As<IDataSaver>()
				.WithParameter(new JSONDataSerializer());
			builder.Register<SaveDataService>(Lifetime.Singleton).As<IDataSaverCommand>();

			//Network
			builder.RegisterComponent(_wsController).AsImplementedInterfaces();


			//Configs
			builder.RegisterInstance(_configsRepository.unitClassesConfig);
			builder.RegisterInstance(_configsRepository.itemsConfig);
			builder.RegisterInstance(_configsRepository.coreConfig);
			builder.RegisterInstance(_configsRepository.unitLevelsConfig);

			builder.RegisterBuildCallback(resolver =>
			{
				var sceneLoader = resolver.Resolve<ISceneCommand>();
				sceneLoader.LoadScene(SceneNames.Menu);
			});
		}
	}
}