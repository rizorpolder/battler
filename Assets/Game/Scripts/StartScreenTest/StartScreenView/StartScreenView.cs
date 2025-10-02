using Game.Scripts.Controllers.MatchmakingController;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.StartScreenTest.StartScreenView
{
	public class StartScreenView : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private Button _buttonCancel;

		[Inject] private IMatchmakingCommand _matchmakingCommand;

		public void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
			_buttonCancel.onClick.AddListener(OnCancelButtonClickHandler);
		}

		private void OnButtonClickHandler()
		{
			_matchmakingCommand.FindMatchmaking();
		}

		private void OnCancelButtonClickHandler()
		{
			_matchmakingCommand.CancelMatchmaking();
		}
	}
}