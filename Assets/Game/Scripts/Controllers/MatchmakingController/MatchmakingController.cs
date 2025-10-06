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
		
		//отправляет на сервер данные, список ходов игрока
		//получает на сервере данные, списка ходов противника
		//возвращает список ходов игрока и противника (в заранее сформированном порядке)
		//BattleController начинает применять по очереди каждый ход к цели (дожидаясь ответа от цели об окончании анимации)
		
		//значит на сервер отправлется пакет
		//1) Данные об игроке и сражении( RoomID и UUID)
		//2) Список его AbilityData
		//3) Рассчеты урона сделать временно локально, в перспективе перенести на сервер
	}
}