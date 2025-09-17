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

		private void Start()
		{
			DontDestroyOnLoad(this.gameObject);
		}

		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.RegisterComponent(_wsController).AsImplementedInterfaces();
		}
	}
}