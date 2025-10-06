using System;
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
		
		[Inject] ISceneCommand _sceneCommand;

		private void Start()
		{
			_leaveButton.onClick.AddListener(LeaveGameHandler);
		}

		private void LeaveGameHandler()
		{
			_sceneCommand.LoadScene(SceneNames.Menu);
		}

		public void Dispose()
		{
			_leaveButton.onClick.RemoveListener(LeaveGameHandler);
		}
	}
}