using System.Collections.Generic;
using Game.Scripts.Common;
using Game.Scripts.Common.Flappy_Bird.Scripts.Common;
using Game.Scripts.CoreGameplay.Controllers;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Services.SaveDataService;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.HUD
{
	public class BottomPanel : MonoBehaviour
	{
		[SerializeField] private Transform _parent;
		[SerializeField] private BottomIconView _prefab;

		//пусть контейнер каждый раз возвращает новое значение.
		[Inject] IBattleControllerListener _battleControllerListener;
		[Inject] IBattleControllerCommand _battleControllerCommand;
		[Inject] IBattleControllerData _battleControllerData;

		[Inject] private IObjectResolver _resolver;
		[Inject] private ObjectsPoolFactory _poolFactory;

		private ObjectsPool<BottomIconView> _pool;

		private void Start()
		{
			_battleControllerListener.OnAbilitiesChanged += OnAbilitiesChangedHandler;
			_pool = _poolFactory.CreatePool(_parent, _prefab);
			_pool.InitializePool();

			UpdateViews();
		}

		private void UpdateViews()
		{
			foreach (var abilityData in _battleControllerData.AbilitiesQueue)
			{
				var item = _pool.GetItem();
				item.Initialize(abilityData.Icon);
			}
		}

		private void OnAbilitiesChangedHandler()
		{
		}

		private void OnActinAdded(AbilityData data)
		{
		}
	}
}