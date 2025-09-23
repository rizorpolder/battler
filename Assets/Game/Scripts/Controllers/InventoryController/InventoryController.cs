using System;
using System.Collections.Generic;
using Game.Scripts.Data.Inventory;

namespace Game.Scripts.Controllers.Inventory
{
	public class InventoryController : IInventoryListener, IInventoryData, IInventoryCommand
	{
		public event Action<InventoryItemData> OnItemEquipped;
		public event Action<InventoryItemData> OnItemUnequipped;
		
		List<InventoryItemData> _items;

		public void Initialize(InventoryData inventoryData)
		{
			
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