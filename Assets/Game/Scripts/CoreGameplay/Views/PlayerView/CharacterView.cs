using Game.Scripts.Common;
using Game.Scripts.Common.Flappy_Bird.Scripts.Common;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Data;
using Spine.Unity;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;

		[SerializeField] private CharacterAbilityButton _buttonPrefab;
		[SerializeField] private Transform _parent;

		[SerializeField] private TUnitControl _unitControl;

		[Inject] private IBattleControllerListener _battleControllerListener;
		[Inject] private IBattleControllerData _battleControllerData;
		[Inject] private IBattleControllerCommand _battleControllerCommand;
		[Inject] private ObjectsPoolFactory _objectsPoolFactory;

		private ObjectsPool<CharacterAbilityButton> _buttonPool;

		CharacterData _characterData;

		public void Start()
		{
			_battleControllerListener.OnBattleLoaded += OnBattleLoadedHandler;
		}

		private void OnPointsChangedHandler()
		{
			UpdateActionsView();
		}

		private void OnBattleLoadedHandler()
		{
			_characterData = _unitControl == TUnitControl.Player
				? _battleControllerData.PlayerData
				: _battleControllerData.EnemyData;

			if (_unitControl != TUnitControl.Player)
				return;

			_battleControllerListener.OnTurnPointsChanged += OnPointsChangedHandler;
			_buttonPool = _objectsPoolFactory.CreatePool(_parent, _buttonPrefab);

			InitializePlayerActions();
		}

		private void InitializePlayerActions()
		{
			foreach (var abilityData in _characterData.Abilities)
			{
				var btn = _buttonPool.GetItem();
				btn.Initialize(abilityData);
				btn.OnButtonClicked += OnButtonClickedHandler;
			}
		}

		private void UpdateActionsView()
		{
			var activeItems = _buttonPool.GetActiveItemsList();
			for (int index = 0; index < _characterData.Abilities.Count; index++)
			{
				var abilityData = _characterData.Abilities[index];
				activeItems[index].SetInteractable(abilityData.Price <= _battleControllerData.CurrentTurnPoints);
			}
		}

		private void OnButtonClickedHandler(AbilityData obj)
		{
			_battleControllerCommand.AddAbilityToQueue(obj);
		}

		private void OnDestroy()
		{
			_battleControllerListener.OnBattleLoaded -= OnBattleLoadedHandler;
			_battleControllerListener.OnTurnPointsChanged -= OnPointsChangedHandler;
		}
	}

	public enum TUnitControl
	{
		Player,
		Enemy
	}
}