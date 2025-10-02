using System;
using System.Collections.Generic;
using Game.Scripts.Controllers.MatchmakingController;
using Game.Scripts.Data;
using VContainer;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class BattleController : IBattleControllerListener, IBattleControllerCommand, IBattleControllerData
	{
		public event Action OnBattleLoaded;
		public event Action OnTurnPointsSpend;
		public event Action OnTurnPointsRestore;
		public event Action<UnitAction> OnActionAdded;
		public event Action<UnitAction> OnActionRemoved;

		private IMatchmakingCommand _matchmakingCommand;
		private IMatchmakingData _matchmakingData;
		private IMatchmakingListener _matchmakingListener;

		private int _maxTurnsCount;
		private int _currentTurnsCount;

		private List<UnitAction> playerActionsQueue;

		[Inject]
		public BattleController(IObjectResolver objectResolver)
		{
			_matchmakingListener = objectResolver.Resolve<IMatchmakingListener>();
			_matchmakingData = objectResolver.Resolve<IMatchmakingData>();
			_matchmakingCommand = objectResolver.Resolve<IMatchmakingCommand>();
		}

		private void LoadBattleData()
		{
			//берем из MM даты данные про противника и комнаты.
			OnBattleLoaded?.Invoke();
			StartTurn();
		}

		public void AddPlayerAction(UnitAction action)
		{
			if (_currentTurnsCount < action.ActionPrice)
				return;

			playerActionsQueue.Add(action);
			OnActionAdded?.Invoke(action);
			SpendTurnPoints(action.ActionPrice);
		}

		public void RemovePlayerAction(UnitAction action)
		{
			playerActionsQueue.Remove(action);
			OnActionRemoved?.Invoke(action);
			AddTurnsPoints(action.ActionPrice);
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
		}

		public void StartTurn()
		{
			IncreaseMaxTurnPoints(1);
			AddTurnsPoints(1);
		}
	}

	public interface IBattleControllerCommand
	{
		public void StartTurn();
		public void MarkAsReady();
		public void EndOfTurn();
	}

	public interface IBattleControllerListener
	{
		public event Action OnBattleLoaded;
		public event Action OnTurnPointsSpend;
		public event Action OnTurnPointsRestore;

		public event Action<UnitAction> OnActionAdded;
		public event Action<UnitAction> OnActionRemoved;
	}

	public interface IBattleControllerData
	{
	}
}