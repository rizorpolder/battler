using Game.Scripts.Controllers;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Services
{
	public class TempService : IInitializable, IStartable
	{
		void IInitializable.Initialize()
		{
		}

		[Inject]
		public TempService(IContainerBuilder builder)
		{
			builder.Register<UnitController>(Lifetime.Singleton).AsImplementedInterfaces().Keyed($"Player1");
			builder.Register<UnitController>(Lifetime.Singleton).AsImplementedInterfaces().Keyed($"Player2");
			builder.Register<UnitController>(Lifetime.Singleton).AsImplementedInterfaces().Keyed($"Player3");
		}

		void IStartable.Start()
		{
		}
	}
}