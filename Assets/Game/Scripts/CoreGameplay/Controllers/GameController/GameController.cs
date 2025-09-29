using System;
using System.Collections.Generic;
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


		private bool _isPlayerReady = false;
		
		[Inject]
		public GameController(IWSControllerListener listener, IWSControllerCommand command)
		{
			_listener = listener;
			_command = command;
		}

		private async void ExecutePlayerTurnsFlow()
		{
		}

		public void EndOfTurn()
		{
			ExecutePlayerTurnsFlow();
		}

		public void CreateAction()
		{
		}

		public void MarkPlayerReady()
		{
			_isPlayerReady = !_isPlayerReady;
			OnPlayerReady?.Invoke(_isPlayerReady);
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