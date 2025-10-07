using System;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BottomIconView : MonoBehaviour
	{
		public event Action<AbilityData> OnButtonClicked = i => { };

		[SerializeField] private Image _icon;
		[SerializeField] private Button _button;

		AbilityData _abilityData;

		private void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}

		private void OnButtonClickHandler()
		{
			OnButtonClicked.Invoke(_abilityData);
		}

		public void Initialize(AbilityData abilityData)
		{
			_abilityData = abilityData;
			_icon.sprite = _abilityData.Icon;
		}

		public void SetInteractable(bool active)
		{
			_button.interactable = active;
		}
	}
}