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
			_buttonPool = _objectsPoolFactory.CreatePool(_parent, _buttonPrefab);
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
				var btn = _buttonPool.GetItem();
				btn.Initialize(abilityData);
				btn.OnButtonClicked += OnButtonClickedHandler;
			}
		}

		private void OnButtonClickedHandler(AbilityData obj)
		{
			//check turn points
			_battleControllerCommand.AddAbilityToQueue(obj);
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