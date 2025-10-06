using Game.Scripts.Common;
using Game.Scripts.Common.Flappy_Bird.Scripts.Common;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BottomPanel : MonoBehaviour
	{
		[SerializeField] private Transform _parent;
		[SerializeField] private BottomIconView _prefab;

		[Inject] private IBattleControllerCommand _battleControllerCommand;
		[Inject] private IBattleControllerData _battleControllerData;
		[Inject] private IBattleControllerListener _battleControllerListener;
		[Inject] private ObjectsPoolFactory _poolFactory;
		[Inject] private IObjectResolver _resolver;

		private ObjectsPool<BottomIconView> _pool;

		private void Start()
		{
			_battleControllerListener.OnAbilitiesQueueChanged += OnAbilitiesChangedHandler;
			_pool = _poolFactory.CreatePool(_parent, _prefab);
			_pool.InitializePool();

			UpdateViews();
		}

		private void UpdateViews()
		{
			UnsubscribeEvents();
			_pool.ResetPool();

			foreach (var abilityData in _battleControllerData.AbilitiesQueue)
			{
				var item = _pool.GetItem();
				item.Initialize(abilityData);
				item.OnButtonClicked += OnAbilityClickHandler;
			}
		}

		private void UnsubscribeEvents()
		{
			foreach (var view in _pool.GetActiveItems())
			{
				view.OnButtonClicked -= OnAbilityClickHandler;
			}
		}

		private void OnAbilityClickHandler(AbilityData data)
		{
			_battleControllerCommand.RemoveAbilityFromQueue(data);
		}

		private void OnAbilitiesChangedHandler()
		{
			UpdateViews();
		}

		private void OnDestroy()
		{
			_battleControllerListener.OnAbilitiesQueueChanged += OnAbilitiesChangedHandler;
		}
	}
}