using System;
using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Controllers.Player;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class GameController : MonoBehaviour, IGameControllerCommand, IGameControllerListener, IGameControllerData
	{
		public event Action<bool> OnPlayerReady;
		public event Action OnPlayerTurn;
		public event Action<BattleResultType> OnBattleComplete;

		// [Inject] IWSControllerListener _listener;
		// [Inject] IWSControllerCommand _command;

		private List<PlayerStep> _playerSteps;

		private bool _isPlayerReady = false;

		private PlayerController _player;
		private PlayerController _enemy;
		
		
		private void Start()
		{
			//TODO temp "On server data received"
			InitializePlayersData();
		}

		private void InitializePlayersData()
		{
			ThrowTurnsPriority(); //Бросок жребия кто ходит первым
			GeneratePlayersTurns(); //смешиваем ходы с учетом того, кто ходит первый

			//по очереди берем ход и проигрываем анимацию, по окончании - возвращаем управление игроку.
		}

		private void ThrowTurnsPriority()
		{
		}

		private void GeneratePlayersTurns()
		{
		}

		private async void ExecutePlayerTurnsFlow()
		{
			foreach (var action in _playerSteps)
			{
				var target = action.CallerType == UnitType.Enemy ? _player : _enemy;
				target.ActionImpact(action.UnitAction);

			}
		
			EndOfTurn();
		}

		public void EndOfTurn()
		{
			//TODO Конец текущего хода, 
			_playerSteps.Clear();
		}

		public void BattleResult()
		{
		}

		private void EndOfBattle()
		{
			OnBattleComplete?.Invoke(BattleResultType.Win);
		}

		public void MarkPlayerReady()
		{
			_isPlayerReady = !_isPlayerReady;
			OnPlayerReady?.Invoke(_isPlayerReady);
		}

		public void OnTurnCompleted()
		{
			OnPlayerTurn?.Invoke();
		}

		public void CreateAction(UnitType caller, AUnitAction action)
		{
			var step = new PlayerStep(caller, action);
			_playerSteps.Add(step);
		}

		
	}

	public enum BattleResultType
	{
		Draw,
		Win,
		Lose
	}
}