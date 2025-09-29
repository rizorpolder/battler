using Game.Scripts.Data;
using Game.Scripts.Data.Inventory;

namespace Game.Scripts.Controllers.Inventory
{
	public interface IInventoryCommand
	{
		public void EquipItem(InventoryItem item);
		public void UnequipItem(InventoryItem item);
		
		public void AddToInventory(InventoryItem item);

		public void GetItemByID(string itemID);

	}
}