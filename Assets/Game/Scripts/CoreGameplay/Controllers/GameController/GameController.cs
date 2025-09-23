using System;
using System.Collections.Generic;
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

		private List<string> _playersTurns;

		private bool _isLeftTurnFirst;
		private bool _isPlayerReady = false;

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

		// private async void ExecutePlayerTurnsFlow()
		// {
		// 	foreach (var action in _playersTurns)
		// 	{
		// 		// по очереди выполняются комманды атакующего и атакуемого игрока (типа Attacker.Attack,Enemy.GetDamage)
		// 		//await targetPlayer.
		// 	}
		//
		// 	EndOfTurn();
		// }

		public void EndOfTurn()
		{
			//TODO Конец текущего хода, 
			_playersTurns.Clear();
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
	}

	public enum BattleResultType
	{
		Draw,
		Win,
		Lose
	}
}