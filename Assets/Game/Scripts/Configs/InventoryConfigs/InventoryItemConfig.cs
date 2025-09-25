using UnityEngine;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(fileName = "InventoryItemConfig", menuName = "Configs/Inventory/InventoryItemConfig")]
	public class InventoryItemConfig : ScriptableObject
	{
		[SerializeField] private string _id;

		[SerializeField] private Sprite _icon;
		[SerializeField] private int _price;
		[SerializeField] private int _requiredLevel;

		public string ID => _id;
	}
}