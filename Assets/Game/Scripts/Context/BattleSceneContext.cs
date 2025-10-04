using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.Services;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			var service = new TempService(builder);
			builder.RegisterInstance(service);
			
			builder.RegisterEntryPoint<BattleController>();
			
			//builder.Register<BattleController>(Lifetime.Singleton).AsImplementedInterfaces();

		}
	}
}