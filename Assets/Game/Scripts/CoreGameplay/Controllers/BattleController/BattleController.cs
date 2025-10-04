using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Controllers.MatchmakingController;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class BattleController : IBattleControllerListener, IBattleControllerCommand, IBattleControllerData,
		IAsyncStartable
	{
		public event Action OnBattleLoaded;
		public event Action OnTurnPointsSpend;
		public event Action OnTurnPointsRestore;
		public event Action<AbilityData> OnActionAdded;
		public event Action<AbilityData> OnActionRemoved;

		[Inject] private IMatchmakingCommand _matchmakingCommand;
		[Inject] private IMatchmakingData _matchmakingData;
		[Inject] private IMatchmakingListener _matchmakingListener;

		private int _maxTurnsCount;
		private int _currentTurnsCount;

		private List<AbilityData> playerActionsQueue;

		public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
		{
			Debug.Log("Starting Battle Controller");

			await UniTask.Delay(TimeSpan.FromSeconds(4), cancellationToken: cancellation);

			OnBattleLoaded?.Invoke();
			StartTurn();

			Debug.Log("Battle Controller loaded");
		}

		public void AddPlayerAction(AbilityData action)
		{
			OnActionAdded?.Invoke(action);
		}

		public void RemovePlayerAction(AbilityData action)
		{
			playerActionsQueue.Remove(action);
			OnActionRemoved?.Invoke(action);
		}

		private void AddTurnsPoints(int points)
		{
			_currentTurnsCount += points;
			if (_currentTurnsCount > _maxTurnsCount)
			{
				_currentTurnsCount = _maxTurnsCount;
			}

			OnTurnPointsRestore?.Invoke();
		}

		private void SpendTurnPoints(int points)
		{
			_currentTurnsCount -= points;
			OnTurnPointsSpend?.Invoke();
		}

		public void IncreaseMaxTurnPoints(int points)
		{
			_maxTurnsCount += points;
			if (_maxTurnsCount > 10)
				_maxTurnsCount = 10;
		}

		public void MarkAsReady()
		{
			_matchmakingCommand.MarkPlayerAsReady();
		}

		public void EndOfTurn()
		{
			_matchmakingCommand.PlayerEndTurn();
		}

		public void StartTurn()
		{
			IncreaseMaxTurnPoints(1);
			AddTurnsPoints(1);
		}
	}
}