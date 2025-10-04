using Game.Scripts.Enums.Inventory;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Data
{
	public class ItemData
	{
		public string Id;
		public TItemPosition ItemPosition;
		public Sprite Icon;
		public int Price;
		public int RequiredLevel;
		
		public int BonusStrength;
		public int BonusAgility;
		public int BonusIntelligence;
		public int Armor;
		
		public int BonusMinDamage;
		public int BonusMaxDamage;
	}
}