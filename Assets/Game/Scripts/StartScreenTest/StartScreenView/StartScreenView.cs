using Game.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.StartScreenTest.StartScreenView
{
	public class StartScreenView : MonoBehaviour, IStartable
	{
		[SerializeField] private Button _button;

		[Inject] private IStartScreenCommand _startScreenCommand;

		private void OnButtonClickHandler()
		{
			_startScreenCommand.LoadBattleScene(SceneNames.Battle);
		}

		public void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}
	}
}