using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using VContainer;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<GameController>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(builder);
		}
	}
}