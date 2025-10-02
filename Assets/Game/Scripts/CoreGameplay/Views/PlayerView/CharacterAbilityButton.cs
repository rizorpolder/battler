using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterAbilityButton : MonoBehaviour
	{
		public Action<int> OnButtonClicked;

		[SerializeField] private Button _button;
		[SerializeField] private Sprite _sprite;

		private int _index = 0; //change to action

		private void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}

		private void OnButtonClickHandler()
		{
			OnButtonClicked?.Invoke(_index);
		}

		public void Initialize(int index) //todo change to action
		{
			_index = index;
		}
	}
}