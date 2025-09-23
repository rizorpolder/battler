using System;
using System.Collections.Generic;
using Game.Scripts.Data.Inventory;
using Game.Scripts.Enums;
using Game.Scripts.Services.SaveDataService;
using VContainer;

namespace Game.Scripts.Controllers.Inventory
{
	public class InventoryController : IInventoryListener, IInventoryData, IInventoryCommand
	{
		public event Action<InventoryItemData> OnItemEquipped;
		public event Action<InventoryItemData> OnItemUnequipped;

		InventoryData _inventoryData;

		[Inject]
		public void Initialize(IDataSaverCommand saverCommand)
		{
			if (!saverCommand.TryLoadData(SaveDataType.Inventory, out _inventoryData))
			{
				_inventoryData = InventoryData.Default;
				_inventoryData.Items.Add(new InventoryItemData()
				{
					ItemID = "Носок",
				});
				saverCommand.TrySaveData(_inventoryData, SaveDataType.Inventory);
			}
		}

		public void EquipItem(InventoryItemData item)
		{
			OnItemEquipped?.Invoke(item);
		}

		public void UnequipItem(InventoryItemData item)
		{
			OnItemUnequipped?.Invoke(item);
		}

		public void AddToInventory(InventoryItemData item)
		{
		}
	}
}