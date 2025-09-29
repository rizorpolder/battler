using System.Collections.Generic;

namespace Game.Scripts.Data.Inventory
{
	public class InventoryModel
	{
		public List<InventoryItem> _items;

		public InventoryModel(InventoryData result)
		{
			_items = new List<InventoryItem>();
			foreach (var dataItem in result.Items)
			{
				_items.Add(new InventoryItem(dataItem));
			}
		}

		public void AddItem(InventoryItem item)
		{
			if (!ContainsItem(item))
				_items.Add(item);
		}

		public void RemoveItem(InventoryItem item)
		{
			if (ContainsItem(item))
				_items.Remove(item);
		}

		public bool ContainsItem(InventoryItem item)
		{
			return _items.Contains(item);
		}
	}

	public class InventoryItem //объект экипировки который создается на базе конфига
	{
		public string ID;
		
		public InventoryItem(InventoryItemData dataItem)
		{
			ID = dataItem.ItemID;
		}
	}
}