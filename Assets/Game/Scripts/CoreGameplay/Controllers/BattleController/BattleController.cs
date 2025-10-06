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
		#region IBattleControllerListener implementation

		public event Action OnBattleLoaded;
		public event Action OnTurnPointsSpend;
		public event Action OnTurnPointsRestore;
		public event Action OnAbilitiesChanged;

		#endregion

		private CharacterData _playerData;
		private CharacterData _enemyData;

		private List<AbilityData> _playerActionsQueue;
		public List<AbilityData> AbilitiesQueue => _playerActionsQueue;

		public int TurnPoints => 10;
		public CharacterData PlayerData => _playerData;
		public CharacterData EnemyData => _enemyData;

		[Inject] private IMatchmakingCommand _matchmakingCommand;
		[Inject] private IMatchmakingData _matchmakingData;
		[Inject] private IMatchmakingListener _matchmakingListener;

		private int _maxTurnsCount;
		private int _currentTurnsCount;

		public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
		{
			_playerActionsQueue = new List<AbilityData>();
			Debug.Log("Starting Battle Controller");

			//Todo factory, convert from data to stats;

			_playerData = _matchmakingData.CharacterBattleData[0].PlayerData;
			_enemyData = _matchmakingData.CharacterBattleData[0].PlayerData;

			await UniTask.Delay(TimeSpan.FromSeconds(4), cancellationToken: cancellation);

			OnBattleLoaded?.Invoke();
			StartTurn();

			Debug.Log("Battle Controller loaded");
		}

		public void AddPlayerAction(AbilityData action)
		{
			_playerActionsQueue.Add(action);
			OnAbilitiesChanged?.Invoke();
		}

		public void RemovePlayerAction(AbilityData action)
		{
			_playerActionsQueue.Remove(action);
			OnAbilitiesChanged?.Invoke();
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

		public void AddAbilityToQueue(AbilityData data)
		{
			_playerActionsQueue.Add(data);
		}

		public void RemoveAbilityFromQueue(AbilityData data)
		{
		}

		public void StartTurn()
		{
			IncreaseMaxTurnPoints(1);
			AddTurnsPoints(1);
		}
	}
}