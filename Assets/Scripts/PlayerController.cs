using System;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Action OnPlayerButtonClicked = () => { };

	[SerializeField] private int currentHealth = 100;
	[SerializeField] private Button sendButton;
	[SerializeField] private Image healthBar;
	[SerializeField] private ToggleController controller;

	private PlayerStatus _currentStatus;

	private void Start()
	{
		sendButton.onClick.AddListener(OnButtonClickedHandler);
		controller.OnToggleInvoked += OnToggleInvoked;
	}

	private void OnToggleInvoked(int value, bool isOn)
	{
		if (isOn)
		{
			_currentStatus = value == 0 ? PlayerStatus.Attack : PlayerStatus.Defence;
		}
		else
		{
			_currentStatus = PlayerStatus.None;
		}

		Debug.Log($"{this.gameObject.name}: OnToggleInvoked: {_currentStatus}");
	}

	private void OnButtonClickedHandler()
	{
		OnPlayerButtonClicked?.Invoke();
	}

	public void HitPlayer()
	{
		currentHealth -= 10;
	}

	public enum PlayerStatus
	{
		None = 0,
		Attack = 1,
		Defence = 2,
	}
}