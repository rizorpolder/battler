using System;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.Data;
using Game.Scripts.LoadingService;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BattleHUDController : MonoBehaviour, IDisposable
	{
		[SerializeField] private Button _readyButton;
		[SerializeField] private Button _endOfTurnButton;
		[SerializeField] private Button _leaveButton;

		[Inject] IGameControllerCommand _gameControllerCommand;
		[Inject] IGameControllerListener _gameControllerListener;

		[Inject] ISceneCommand _sceneCommand;

		private void Start()
		{
			_readyButton.onClick.AddListener(OnButtonClickHandled);
			_endOfTurnButton.onClick.AddListener(EndOfTurnHandler);
			_leaveButton.onClick.AddListener(LeaveGameHandler);
			_gameControllerListener.OnPlayerReady += OnPlayerReadyHandler;
		}

		private void LeaveGameHandler()
		{
			_sceneCommand.LoadScene(SceneNames.Menu);
		}

		private void OnPlayerReadyHandler(bool obj)
		{
			_readyButton.image.color = obj ? Color.green : Color.white;
		}

		private void EndOfTurnHandler()
		{
			_gameControllerCommand.EndOfTurn();
		}

		private void OnButtonClickHandled()
		{
			_gameControllerCommand.MarkPlayerReady();
		}

		public void Dispose()
		{
			_gameControllerListener.OnPlayerReady -= OnPlayerReadyHandler;

			_readyButton.onClick.RemoveListener(OnButtonClickHandled);
			_endOfTurnButton.onClick.RemoveListener(EndOfTurnHandler);
			_leaveButton.onClick.RemoveListener(LeaveGameHandler);
		}
	}
}