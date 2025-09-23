using Game.Scripts.Data;
using Game.Scripts.Data.Inventory;

namespace Game.Scripts.Controllers.Inventory
{
	public interface IInventoryCommand
	{
		public void EquipItem(InventoryItemData item);
		public void UnequipItem(InventoryItemData item);
		
		public void AddToInventory(InventoryItemData item);
		
	}
}