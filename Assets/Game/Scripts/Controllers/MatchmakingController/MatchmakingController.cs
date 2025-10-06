using System;
using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using Game.Scripts.Resources;
using Game.Scripts.test;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Controllers.MatchmakingController
{
	public class MatchmakingController : IMatchmakingListener, IMatchmakingData, IMatchmakingCommand
	{
		private List<CharacterBattleData> _characterBattleData;
		public List<CharacterBattleData> CharacterBattleData => _characterBattleData;

		private ISceneCommand _sceneCommand;

		//temp
		[Inject] private TestCharactersRepository _repository;

		[Inject]
		public MatchmakingController(ISceneCommand sceneCommand) //прокинуть сюда network controller
		{
			_sceneCommand = sceneCommand;
			_characterBattleData = new List<CharacterBattleData>();
		}

		public void FindMatchmaking()
		{
			//Если это интернет бой - то прокинуть в network controller и ждать пока найдется матч,
			//Если это ИИ бой - то взять данные и сгенерить "противника"

			//создает из данных - персонажа
			var data = new MatchmakingData()
			{
				RoomID = Guid.NewGuid().ToString(),
			};

			OnMatchmakingFound(data);
		}

		public void MarkPlayerAsReady()
		{
			Debug.Log($"Player Ready Send To Server");
		}

		public void PlayerEndTurn()
		{
			Debug.Log($"End Turn Send To Server");
		}

		private void OnMatchmakingFound(MatchmakingData matchmakingData)
		{
			//TODO Its test logic
			bool isPlayer = true;
			foreach (var repositoryConfig in _repository.configs)
			{
				_characterBattleData.Add(new CharacterBattleData()
				{
					IsPlayer = isPlayer,
					PlayerData = repositoryConfig.GetCharacterData()
				});
				isPlayer = false;
			}

			
			//callback
			_sceneCommand.LoadScene(SceneNames.Battle);
		}
	}
}