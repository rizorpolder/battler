using System;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Data;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Controllers.Player
{
	public class PlayerController : IPlayerData, IPlayerListener, IPlayerCommand
	{
		public event Action<int, int> OnPlayerHealthChanged;
		public event Action OnPlayerDeath;

		private int _maxStepPoints; //количество очков которые может игрок потратить
		private int _currentStepPoints;

		private Unit _playerUnit;

		[Inject] private IGameControllerCommand _gameControllerCommand;

		public PlayerController(Unit unit) //данные об персонаже игрока
		{
		}

		public void ActionImpact(AUnitAction action)
		{
			action.ExecuteAction(_playerUnit);
		}

		public void ActionCall(AUnitAction action)
		{
			if (action.Price > _currentStepPoints)
			{
				Debug.Log($"Not enough points for action {action.ActionType.ToString()}");
				return;
			}

			_gameControllerCommand.CreateAction(_playerUnit.UnitType, action);
		}
	}
}