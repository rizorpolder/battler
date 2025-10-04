using Game.Scripts.Context.Abstract;
using Game.Scripts.Controllers;
using Game.Scripts.Controllers.Inventory;
using Game.Scripts.Helpers;
using Game.Scripts.StartScreenTest;
using VContainer;

namespace Game.Scripts.Context
{
	public class MenuSceneContext : ASceneContext
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<StartScreenController>(Lifetime.Scoped).AsImplementedInterfaces();
			builder.Register<InventoryController>(Lifetime.Scoped).AsImplementedInterfaces();
			builder.Register<UnitModelFactory>(Lifetime.Singleton);
			builder.Register<UnitController>(Lifetime.Scoped).AsImplementedInterfaces();
		}
	}
}