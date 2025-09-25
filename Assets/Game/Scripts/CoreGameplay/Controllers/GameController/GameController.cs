using System;
using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Controllers.Player;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums;
using Game.Scripts.Services.NetworkService;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class GameController : IGameControllerCommand, IGameControllerListener, IGameControllerData,
		IInstaller
	{
		public event Action<bool> OnPlayerReady;
		public event Action OnPlayerTurn;
		public event Action<BattleResultType> OnBattleComplete;

		IWSControllerListener _listener;
		IWSControllerCommand _command;

		private List<PlayerStep> _playerSteps;

		private bool _isPlayerReady = false;

		private PlayerController _player;
		private PlayerController _enemy;

		[Inject]
		public GameController(IWSControllerListener listener, IWSControllerCommand command)
		{
			_listener = listener;
			_command = command;
		}

		private async void ExecutePlayerTurnsFlow()
		{
			foreach (var action in _playerSteps)
			{
				var target = action.CallerType == UnitType.Enemy ? _player : _enemy;
				target.ActionImpact(action.UnitAction);
			}

			_playerSteps.Clear();
		}

		public void EndOfTurn()
		{
			ExecutePlayerTurnsFlow();
		}

		public void MarkPlayerReady()
		{
			_isPlayerReady = !_isPlayerReady;
			OnPlayerReady?.Invoke(_isPlayerReady);
		}

		public void CreateAction(UnitType caller, AUnitAction action)
		{
			var step = new PlayerStep(caller, action);
			_playerSteps.Add(step);
		}

		public void Install(IContainerBuilder builder)
		{
		}
	}

	public enum BattleResultType
	{
		Draw,
		Win,
		Lose
	}
}