using System;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Controllers.PlayerController;
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

		private IPlayerListener _playerListener;
		private IPLayerCommand _playerCommand;

		private IObjectResolver _objectResolver;

		[Inject] IGameControllerListener listener;
		
		[Inject]
		private void Initialize(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
			listener.OnPlayerReady += Temp;
		}

		private void Temp(bool obj)
		{
			InitializeCharacter();
		}

		public void InitializeCharacter()
		{
			
			var temp = _objectResolver.Resolve<IContainerBuilder>();
			_playerListener = _objectResolver.Resolve<IPlayerListener>("LeftPlayerController");
			_playerCommand = _objectResolver.Resolve<IPLayerCommand>("LeftPlayerController");
			_playerListener.OnPlayerDataChanged += OnPlayerDataChangedHandler;

			//fill buttons
		}

		private void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		private void AddAction()
		{
			_playerCommand.AddPlayerAction("Attack");
		}

		private void OnPlayerDataChangedHandler()
		{
			Debug.Log("Player Data Changed");
		}

		public void Dispose()
		{
			_playerListener.OnPlayerDataChanged -= OnPlayerDataChangedHandler;
		}
	}
}