using System;
using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using Game.Scripts.Resources;
using Game.Scripts.Services.NetworkService;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Controllers.MatchmakingController
{
	public class MatchmakingController : IMatchmakingListener, IMatchmakingData, IMatchmakingCommand
	{
		private MatchmakingData _data;
		public MatchmakingData Data => _data;

		private ISceneCommand _sceneCommand;
		private IWSControllerCommand _controllerCommand;

		[Inject]
		public MatchmakingController(ISceneCommand sceneCommand, IWSControllerCommand wsControllerCommand) //прокинуть сюда network controller
		{
			_sceneCommand = sceneCommand;
			_controllerCommand =  wsControllerCommand;
		}

		public void FindMatchmaking()
		{
			//Если это интернет бой - то прокинуть в network controller и ждать пока найдется матч,
			//Если это ИИ бой - то взять данные и сгенерить "противника"
			_controllerCommand.CreateConnection();
			
			
			// var data = new MatchmakingData()
			// {
			// 	RoomID = Guid.NewGuid().ToString(),
			// };
			//
			// OnMatchmakingFound(data);
		}

		public void MarkPlayerAsReady()
		{
			Debug.Log($"Player Ready Send To Server");
		}

		public void PlayerEndTurn()
		{
			Debug.Log($"End Turn Send To Server");
		}

		public void CancelMatchmaking()
		{
			_controllerCommand.Disconnect();
		}

		private void OnMatchmakingFound(MatchmakingData matchmakingData)
		{
			_data = matchmakingData;
			_sceneCommand.LoadScene(SceneNames.Battle);
		}
	}
}