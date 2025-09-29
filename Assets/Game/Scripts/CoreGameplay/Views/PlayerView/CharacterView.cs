using System;
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

		public void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		[Inject]
		public void ResolvePlayerCommand(IObjectResolver resolver)
		{
			
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