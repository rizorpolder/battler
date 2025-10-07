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
		private const int MAX_TURN_POINTS = 10;

		#region IBattleControllerListener implementation

		public event Action OnBattleLoaded;
		public event Action OnTurnPointsChanged;
		public event Action OnAbilitiesQueueChanged;

		#endregion

		private CharacterData _playerData;
		private CharacterData _enemyData;

		private List<AbilityData> _playerActionsQueue;
		public List<AbilityData> AbilitiesQueue => _playerActionsQueue;

		public int CurrentTurnPoints => _currentTurnsCount;

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
			_currentTurnsCount = 2; //TODO from config
			_maxTurnsCount = 2;

			//Todo factory, convert from data to stats;

			_playerData = _matchmakingData.CharacterBattleData[0].PlayerData;
			_enemyData = _matchmakingData.CharacterBattleData[0].PlayerData;
			
			await UniTask.Delay(TimeSpan.FromSeconds(2), cancellationToken: cancellation);

			OnBattleLoaded?.Invoke();

			Debug.Log("Battle Controller loaded");
		}

		public void AddAbilityToQueue(AbilityData data)
		{
			if (_currentTurnsCount - data.Price < 0)
			{
				return;
			}

			SpendTurnPoints(data.Price);
			_playerActionsQueue.Add(data);
			OnAbilitiesQueueChanged?.Invoke();
		}

		public void RemoveAbilityFromQueue(AbilityData data)
		{
			AddTurnsPoints(data.Price);
			_playerActionsQueue.Remove(data);
			OnAbilitiesQueueChanged?.Invoke();
		}

		private void AddTurnsPoints(int points)
		{
			_currentTurnsCount += points;
			if (_currentTurnsCount > _maxTurnsCount)
			{
				_currentTurnsCount = _maxTurnsCount;
			}

			OnTurnPointsChanged?.Invoke();
		}

		private void SpendTurnPoints(int points)
		{
			_currentTurnsCount -= points;
			OnTurnPointsChanged?.Invoke();
		}

		public void IncreaseMaxTurnPoints(int points)
		{
			_maxTurnsCount += points;
			if (_maxTurnsCount > MAX_TURN_POINTS)
				_maxTurnsCount = MAX_TURN_POINTS;
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