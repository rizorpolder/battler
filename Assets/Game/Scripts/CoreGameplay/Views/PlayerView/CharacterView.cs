using System;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Data;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;
		[SerializeField] private CharacterAbilityButton _buttonPrefab;
		
		

		[SerializeField] private TUnitControl _unitControl;

		[Inject] private IBattleControllerListener _battleControllerListener;
		[Inject] private IBattleControllerData _battleControllerData;
		[Inject] private IBattleControllerCommand _battleControllerCommand;

		CharacterData _characterData;

		public void Start()
		{
			_battleControllerListener.OnBattleLoaded += OnBattleLoadedHandler;
		}

		private void OnBattleLoadedHandler()
		{
			_characterData = _unitControl == TUnitControl.Player
				? _battleControllerData.PlayerData
				: _battleControllerData.EnemyData;

			UpdateActions();
		}

		private void UpdateActions()
		{
			foreach (var abilityData in _characterData.Abilities)
			{
				var btn = Instantiate(_buttonPrefab, this.transform);
				btn.Initialize(abilityData);
				btn.OnButtonClicked+= OnButtonClicked;
			}
		}

		private void OnButtonClicked(AbilityData obj)
		{
			//check turn points
			_battleControllerCommand.AddAbilityToQueue(obj);
		}

		private void AddAction()
		{
		}

		private void OnDestroy()
		{
			_battleControllerListener.OnBattleLoaded -= OnBattleLoadedHandler;
		}
	}

	public enum TUnitControl
	{
		Player,
		Enemy
	}
}