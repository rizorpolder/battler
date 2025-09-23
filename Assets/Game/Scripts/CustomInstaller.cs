using Game.Scripts.StartScreenTest;
using VContainer;
using VContainer.Unity;

public class CustomInstaller : IInstaller
{
	public void Install(IContainerBuilder builder)
	{
		builder.Register<StartScreenController>(Lifetime.Scoped).AsImplementedInterfaces();
	}
}
