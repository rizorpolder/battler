using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums.Inventory;
using UnityEngine;

namespace Game.Scripts.Configs.InventoryConfigs
{
	[CreateAssetMenu(menuName = "Configs/Inventory/Equipable Item Config",fileName = "EquipableItemConfig")]
	public class EquipableItemConfig : ScriptableObject
	{
		[SerializeField] private string _id;
		[SerializeField] private TItemPosition _itemPosition;
		[SerializeField] private Sprite _icon;
		[SerializeField] private int _price;

		[SerializeField] private int _requiredLevel;
		[SerializeField] private int bonusStrength;
		[SerializeField] private int bonusAgility;
		[SerializeField] private int bonusIntelligence;
		[SerializeField] private int armor;
		[SerializeField] private int bonusMinDamage;
		[SerializeField] private int bonusMaxDamage;

		public string ID => _id;

		public ItemData GetItemData()
		{
			return new ItemData()
			{
				Id = _id,
				ItemPosition = _itemPosition,
				Icon = _icon,
				Price = _price,
				RequiredLevel = _requiredLevel,
				BonusStrength = bonusStrength,
				BonusAgility = bonusAgility,
				BonusIntelligence = bonusIntelligence,
				Armor = armor,
				BonusMaxDamage = bonusMaxDamage,
				BonusMinDamage = bonusMinDamage,
			};
		}
	}
}