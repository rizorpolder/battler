using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterEntryPoint<BattleController>().As<IBattleControllerListener, IBattleControllerCommand, IBattleControllerData>();
		}
	}
}