using Game.Scripts.Context.Abstract;
using Game.Scripts.Controllers.Inventory;
using Game.Scripts.StartScreenTest;
using VContainer;

namespace Game.Scripts.Context
{
	public class StartSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<StartScreenController>(Lifetime.Scoped).AsImplementedInterfaces();

			builder.Register<InventoryController>(Lifetime.Scoped).AsImplementedInterfaces().Build();
		}
	}
}