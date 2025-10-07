using System;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterAbilityButton : MonoBehaviour
	{
		public Action<AbilityData> OnButtonClicked;

		[SerializeField] private Button _button;
		[SerializeField] private Image _image;

		private AbilityData _abilityData;

		private void Start()
		{
			_button.onClick.AddListener(OnButtonClickHandler);
		}

		private void OnButtonClickHandler()
		{
			OnButtonClicked?.Invoke(_abilityData);
		}

		public void Initialize(AbilityData abilityData)
		{
			_abilityData = abilityData;
			_image.sprite = abilityData.Icon;
		}

		public void SetInteractable(bool interactable)
		{
			_button.interactable = interactable;
		}
	}
}