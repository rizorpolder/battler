using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using Game.Scripts.Resources;
using VContainer;

namespace Game.Scripts.Controllers.MatchmakingController
{
	public class MatchmakingController : IMatchmakingListener, IMatchmakingData, IMatchmakingCommand
	{
		private MatchmakingData _data;
		public MatchmakingData Data => _data;

		private ISceneCommand _sceneCommand;
		
		[Inject]
		public MatchmakingController(ISceneCommand iSceneCommand) //прокинуть сюда network controller
		{
		}

		public void FindMatchmaking()
		{
			//Если это интернет бой - то прокинуть в network controller и ждать пока найдется матч,
			//Если это ИИ бой - то взять данные и сгенерить "противника"
			
		}

		public void MarkPlayerAsReady()
		{
			//отправить на сервер что пользователь готов
		}

		private void OnMatchmakingFound(MatchmakingData matchmakingData)
		{
			_data = matchmakingData;
			_sceneCommand.LoadScene(SceneNames.Battle);
		}
	}
}