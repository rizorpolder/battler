using Game.Scripts.Controllers.Inventory;
using Game.Scripts.Controllers.MatchmakingController;
using Game.Scripts.Data;
using Game.Scripts.Services.SaveDataService;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.StartScreenTest.StartScreenView
{
	public class StartScreenView : MonoBehaviour
	{
		[SerializeField] private Button _button;

		[Inject] private IMatchmakingCommand _matchmakingCommand;
		private void OnButtonClickHandler()
		{
			_matchmakingCommand.FindMatchmaking();
		}

		public void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}
	}
}