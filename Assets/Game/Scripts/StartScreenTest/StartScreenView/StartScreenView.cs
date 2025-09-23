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

		[Inject] private IStartScreenCommand _startScreenCommand;
		[Inject] private IDataSaverCommand dataSaverCommand;
		private void OnButtonClickHandler()
		{
			_startScreenCommand.LoadBattleScene(SceneNames.Battle);
		}

		public void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}

		[Inject]
		public void Initialize(IObjectResolver resolver)
		{
		}
	}
}