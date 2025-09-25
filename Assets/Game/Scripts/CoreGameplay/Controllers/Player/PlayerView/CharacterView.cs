using System;
using Game.Scripts.CoreGameplay.Controllers;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour, IDisposable
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;
		[SerializeField] private Button _skillButton;

		
		
		private void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		private void AddAction()
		{
		}

		private void OnPlayerDataChangedHandler()
		{
		}

		public void Dispose()
		{
		}
	}
}