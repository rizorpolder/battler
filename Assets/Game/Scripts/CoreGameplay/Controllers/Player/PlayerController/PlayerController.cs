using System;
using Game.Scripts.Configs;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Controllers.Player
{
	public class PlayerController : IPlayerData, IPlayerListener, IPlayerCommand
	{
		public event Action<int, int> OnPlayerHealthChanged;
		public event Action OnPlayerDeath;
		public event Action OnStepPointsChanged;

		private int _maxTurnPoints; //количество очков которые может игрок потратить
		private int _currentStepPoints;

		private Unit _playerUnit;

		public bool IsPlayer => _playerUnit.UnitType == UnitType.Player;

		private IGameControllerCommand _gameControllerCommand;
		private CoreConfig _coreConfig;

		[Inject]
		public PlayerController(CoreConfig config, IGameControllerCommand command, bool isPlayer) //данные об персонаже игрока
		{
			_coreConfig = config;
			_gameControllerCommand = command;

			_playerUnit = new Unit(isPlayer ? UnitType.Player : UnitType.Enemy);
			 _currentStepPoints = _coreConfig.StartTurnPoints;
			 _maxTurnPoints = _coreConfig.MaxTurnPoints;
		}

		public void ActionImpact(AUnitAction action)
		{
			action.ExecuteAction(_playerUnit);
		}

		public void ActionCall(AUnitAction action)
		{
			if (!IsEnoughPoints(action.Price))
			{
				Debug.Log($"Not enough points for action {action.ActionType.ToString()}");
				return;
			}

			SpendStepPoints(action.Price);
			_gameControllerCommand.CreateAction(_playerUnit.UnitType, action);
		}

		public void IncreaseStepPoints(int amount)
		{
			throw new NotImplementedException();
		}

		public void IncreaseStepPoints()
		{
			_currentStepPoints += _coreConfig.IncreaseTurnPoints;
			if (_currentStepPoints >= _maxTurnPoints)
			{
				_currentStepPoints = _maxTurnPoints;
				return;
			}

			OnStepPointsChanged?.Invoke();
		}

		private void SpendStepPoints(int amount)
		{
			if (!IsEnoughPoints(amount))
				return;
			_currentStepPoints -= amount;
			OnStepPointsChanged?.Invoke();
		}

		private bool IsEnoughPoints(int amount)
		{
			return _currentStepPoints - amount >= 0;
		}
	}
}