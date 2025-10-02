using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums.Inventory;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(menuName = "Configs/Inventory/InventoryItemsConfig", fileName = "InventoryItemsConfig")]
	public class InventoryItemsConfig : ScriptableObject
	{
		//TODO переделать потом в AssetReferences (чтоб заполнялось по загрузке бандла)
		//TODO Формировать конфиг в рантайме 
		[SerializeField] private List<InventoryItemWrapper> _inventoryItems;

		private bool GetItemByType(TItemPosition tItemPosition, out List<EquipableItemConfig> result)
		{
			result = null;
			var wrapper = _inventoryItems.FirstOrDefault(x => x.position.Equals(tItemPosition));
			if (wrapper == null)
				return false;

			result = wrapper.Items;
			return true;
		}

		public bool GetItemByID(TItemPosition position, string id, out EquipableItemConfig config)
		{
			config = null;
			if (GetItemByType(position, out List<EquipableItemConfig> result))
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
		[FormerlySerializedAs("Type")] public TItemPosition position;
		public List<EquipableItemConfig> Items;
	}
}