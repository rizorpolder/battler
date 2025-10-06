using System;
using Game.Scripts.CoreGameplay.Controllers;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BottomIconView : MonoBehaviour
	{
		public event Action<int> OnButtonClicked = i => { };

		[SerializeField] private Image _icon;
		[SerializeField] private Button _button;


		[Inject] IBattleControllerCommand _battleControllerCommand;
		
		
		private int _index = 0;

		private void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}

		private void OnButtonClickHandler()
		{
			//_battleControllerCommand.AddAbilityToQueue();
		}

		public void Initialize( Sprite dataIcon)
		{
			_index = 0;
			_icon.sprite = dataIcon;
		}
	}
}