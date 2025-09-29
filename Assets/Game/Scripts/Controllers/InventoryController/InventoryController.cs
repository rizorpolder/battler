using System;
using Game.Scripts.Data.Inventory;
using Game.Scripts.Enums;
using Game.Scripts.Services.SaveDataService;
using VContainer;

namespace Game.Scripts.Controllers.Inventory
{
	
	//Хранит в себе все приобретенные вещи игрока, то что одето - лежит в Unit
	public class InventoryController : IInventoryListener, IInventoryData, IInventoryCommand
	{
		public event Action<InventoryItem> OnItemEquipped;
		public event Action<InventoryItem> OnItemUnequipped;

		InventoryModel _inventoryModel;

		[Inject]
		public void Initialize(IDataSaverCommand saverCommand)
		{
			if (!saverCommand.TryLoadData(SaveDataType.Inventory, out InventoryData data))
			{
				data = InventoryData.Default;
				data.Items.Add(new InventoryItemData()
				{
					ItemID = "Носок",
				});
				saverCommand.TrySaveData(data, SaveDataType.Inventory);
			}

			_inventoryModel = new InventoryModel(data);
		}

		public void EquipItem(InventoryItem item)
		{
			_inventoryModel.AddItem(item);
			OnItemEquipped?.Invoke(item);
		}

		public void UnequipItem(InventoryItem item)
		{
			_inventoryModel.RemoveItem(item);
			OnItemUnequipped?.Invoke(item);
		}

		public void AddToInventory(InventoryItem item)
		{
		}

		public void GetItemByID(string itemID)
		{
		}
	}
}