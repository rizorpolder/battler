using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Controllers.PlayerController;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		[SerializeField] private GameController _gameController;

		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterComponent(_gameController).AsImplementedInterfaces();
			
			builder.Register<PlayerController>(Lifetime.Scoped).As<IPlayerListener,IPLayerCommand,IPlayerData>().Keyed("LeftPlayerController");
			builder.Register<PlayerController>(Lifetime.Scoped).As<IPlayerListener,IPLayerCommand,IPlayerData>().Keyed("RightPlayerController");
		}
	}
}