using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Controllers.Player;
using Game.Scripts.Enums;
using VContainer;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<GameController>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(builder);
			builder.Register<PlayerController>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(true).Keyed(UnitType.Player);
			builder.Register<PlayerController>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(false).Keyed(UnitType.Enemy);
			
		}
	}
}