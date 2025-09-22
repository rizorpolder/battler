using System.Collections.Generic;
using Game.Scripts.Enums.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(menuName = "Configs/Inventory/InventoryItemsConfig", fileName = "InventoryItemsConfig")]
	public class InventoryItemsConfig : SerializedScriptableObject
	{
		[SerializeField] private Dictionary<ItemType, List<InventoryItemConfig>> _inventoryItemConfigs;
	}
}