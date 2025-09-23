using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
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

		[Inject] IContainerBuilder _containerBuilder;

		private PlayerController.PlayerController _leftPlayer;
		private PlayerController.PlayerController _rightPlayer;

		private List<string> _playersTurns;

		private bool _isLeftTurnFirst;
		
		private void Start()
		{
			//TODO temp "On server data received"
			InitializePlayersData();
		}

		public void InitializePlayersData( /*player1 data, player2 data*/)
		{
			_leftPlayer = new PlayerController.PlayerController("LeftPlayer");
			_rightPlayer = new PlayerController.PlayerController("RightPlayer");

			_containerBuilder.RegisterInstance(_leftPlayer).AsImplementedInterfaces().Keyed("LeftPlayerController");
			_containerBuilder.RegisterInstance(_rightPlayer).AsImplementedInterfaces().Keyed("RightPlayerController");

			ThrowTurnsPriority(); //Бросок жребия кто ходит первым

			GeneratePlayersTurns(); //смешиваем ходы с учетом того, кто ходит первый

			//по очереди берем ход и проигрываем анимацию, по окончании - возвращаем управление игроку.
		}

		private void ThrowTurnsPriority()
		{
			_isLeftTurnFirst = Random.Range(0f, 1f) <= 0.5f;
		}

		private void GeneratePlayersTurns()
		{
			_playersTurns = new List<string>();

			var left = _leftPlayer.PlayerActionQueue;
			var right = _rightPlayer.PlayerActionQueue;
			var totalTurns = left.Count + right.Count;

			for (int i = 0; i < totalTurns; i++)
			{
				if (i >= left.Count)
				{
					_playersTurns.AddRange(right.Skip(i));
					break;
				}

				if (i >= right.Count)
				{
					_playersTurns.AddRange(left.Skip(i));
					break;
				}

				if (i == 0)
				{
					var turn = _isLeftTurnFirst ? left : right;
					_playersTurns.Add(turn[i]);
				}
				else
				{
					var takeFrom = Random.Range(0f, 1f) <= 0.5f ? left[i] : right[i];
					_playersTurns.Add(takeFrom);
				}
			}
		}

		private async void ExecutePlayerTurnsFlow()
		{
			PlayerController.PlayerController targetPlayer = _isLeftTurnFirst ? _leftPlayer : _rightPlayer;
			foreach (var action in _playersTurns)
			{
				// по очереди выполняются комманды атакующего и атакуемого игрока (типа Attacker.Attack,Enemy.GetDamage)
				//await targetPlayer.
			}

			EndOfTurn();
		}

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
		
		public void MarkPlayerReady(bool isReady)
		{
			OnPlayerReady?.Invoke(isReady);
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