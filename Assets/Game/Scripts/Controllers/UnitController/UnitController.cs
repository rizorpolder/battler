using Game.Scripts.Configs.UnitConfigs;
using Game.Scripts.Controllers.Inventory;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Game.Scripts.Helpers;
using Game.Scripts.Resources;
using Game.Scripts.Services.SaveDataService;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Controllers
{
	public class UnitController : IUnitData, IUnitListener, IUnitCommand, IInitializable
	{
		private PlayerUnitModel _playerUnitModel;
		private UnitModelFactory _unitModelFactory;

		public void Initialize()
		{
		}

		[Inject]
		public void Initialize(IDataSaverCommand dataSaverCommand, UnitModelFactory unitModelFactory)
		{
			_unitModelFactory = unitModelFactory;

			if (!dataSaverCommand.TryLoadData(SaveDataType.Unit, out UnitData data))
			{
				data = UnitData.Default;
			}

			CreatePlayerUnitModel(data);
		}
		private void CreatePlayerUnitModel(UnitData data)
		{
			_playerUnitModel = _unitModelFactory.Build(data);
		}
	}
}