using Game.Scripts.Enums.Inventory;
using UnityEngine;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(fileName = "EquipableItemConfig", menuName = "Configs/Inventory/EquipableItemConfig")]
	public class EquipableItemConfig : ScriptableObject
	{
		[SerializeField] private string _id;
		[SerializeField] private TItemPosition _itemPosition;
		[SerializeField] private Sprite _icon;
		[SerializeField] private int _price;
		[SerializeField] private int _requiredLevel;

		public string ID => _id;
	}
}