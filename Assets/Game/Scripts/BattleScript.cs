using System;
using Game.Scripts.LoadingSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class BattleScript : MonoBehaviour
{
	[SerializeField] private Button temp;
	[Inject] ISceneListener _listener;

	private void Start()
	{
		temp.onClick.AddListener(OnButtonClickHandler);
	}

	private void OnButtonClickHandler()
	{

	}
}
