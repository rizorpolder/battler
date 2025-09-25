using System;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Controllers.Player;
using Game.Scripts.Enums;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour, IDisposable
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;
		[SerializeField] private Button _skillButton;
		[SerializeField] private UnitType type;

		[Inject] IGameControllerCommand _gameControllerCommand;
		IPlayerCommand _playerCommand;
		IPlayerData _playerData;
		
		public void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		[Inject]
		public void ResolvePlayerCommand(IObjectResolver resolver)
		{
			_playerCommand = resolver.Resolve<IPlayerCommand>(type);
			_playerData = resolver.Resolve<IPlayerData>(type);
			
		}

		private void AddAction()
		{
			//_gameControllerCommand.CreateAction();
		}

		private void OnPlayerDataChangedHandler()
		{
		}

		public void Dispose()
		{
		}
	}
}