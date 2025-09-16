using Game.Scripts.LoadingSystem;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class GlobalSceneContext : LifetimeScope
	{
		private void Start()
		{
			DontDestroyOnLoad(this.gameObject);
		}

		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
		}
	}
}