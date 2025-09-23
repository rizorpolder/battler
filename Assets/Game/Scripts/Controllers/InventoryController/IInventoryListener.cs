using System;
using Game.Scripts.Data;
using Game.Scripts.Data.Inventory;

namespace Game.Scripts.Controllers.Inventory
{
	public interface IInventoryListener
	{
		public event Action<InventoryItemData> OnItemEquipped;
		public event Action<InventoryItemData> OnItemUnequipped;
	}
}