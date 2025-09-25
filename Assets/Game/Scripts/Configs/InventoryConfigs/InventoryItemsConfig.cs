using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums.Inventory;
using UnityEngine;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(menuName = "Configs/Inventory/InventoryItemsConfig", fileName = "InventoryItemsConfig")]
	public class InventoryItemsConfig : ScriptableObject
	{
		//TODO переделать потом в AssetReferences (чтоб заполнялось по загрузке бандла)
		
		[SerializeField] private List<InventoryItemWrapper> _inventoryItems;

		private bool GetItemByType(ItemType itemType, out List<InventoryItemConfig> result)
		{
			result = null;
			var wrapper = _inventoryItems.FirstOrDefault(x => x.Type.Equals(itemType));
			if (wrapper == null)
				return false;

			result = wrapper.Items;
			return true;
		}

		public bool GetItemByID(ItemType type, string id, out InventoryItemConfig config)
		{
			config = null;
			if (GetItemByType(type, out List<InventoryItemConfig> result))
			{
				var item = result.FirstOrDefault(x => x.ID.Equals(id));
				if (item == null)
					return false;

				config = item;
				return true;
			}

			return false;
		}
	}

	[Serializable]
	public class InventoryItemWrapper
	{
		public ItemType Type;
		public List<InventoryItemConfig> Items;
	}
}