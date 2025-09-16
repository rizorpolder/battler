using Game.Scripts.LoadingSystem;
using VContainer;

namespace Game.Scripts.StartScreenTest
{
	public class StartScreenController : IStartScreenCommand
	{
		[Inject] ISceneCommand _sceneCommand;

		public void LoadBattleScene(string sceneName)
		{
			_sceneCommand.LoadScene(sceneName);
		}
	}
}