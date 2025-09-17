using System;
using Game.Scripts.CoreGameplay.Controllers;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BattleHUDController : MonoBehaviour
	{
		[SerializeField] private Button _button;


		[Inject] IGameControllerCommand _gameControllerCommand;

		private void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandled);
		}

		private void OnButtonClickHandled()
		{
			_gameControllerCommand.Hit();
		}
	}
}