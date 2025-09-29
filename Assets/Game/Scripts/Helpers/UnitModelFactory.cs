using Game.Scripts.Configs.UnitConfigs;
using Game.Scripts.Controllers.Inventory;
using Game.Scripts.Data;
using Game.Scripts.Resources;
using UnityEngine;

namespace Game.Scripts.Helpers
{
	public class UnitModelFactory
	{
		private IInventoryCommand _inventoryCommand;
		private UnitClassesConfig _unitClassesConfig;

		public UnitModelFactory(IInventoryCommand inventoryCommand, UnitClassesConfig unitClassesConfig)
		{
			_inventoryCommand = inventoryCommand;
			_unitClassesConfig = unitClassesConfig;
		}

		public PlayerUnitModel Build(UnitData unitData)
		{
			//строит на базе данных игровые представления 

			if (!_unitClassesConfig.GetClassConfig(unitData.UnitClass, out var classConfig))
			{
				Debug.Log($"No class {unitData.UnitClass} found");
				return null;
			}

			var result = new PlayerUnitModel();
			foreach (var equippedItem in unitData.EquippedItems)
			{
				_inventoryCommand.GetItemByID(equippedItem.itemID);
			}

			return result;
		}
	}
}