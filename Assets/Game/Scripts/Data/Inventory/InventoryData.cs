using System.Collections.Generic;

namespace Game.Scripts.Data.Inventory
{
	public class InventoryData
	{
		public List<InventoryItemData> Items;

		public static InventoryData Default => new InventoryData()
		{
			Items = new List<InventoryItemData>()
		};
	}
}