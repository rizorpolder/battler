using System.Collections.Generic;
using Game.Scripts.Configs.UnitConfigs;

namespace Game.Scripts.CoreGameplay.Data
{
	public class CharacterData
	{
		public int MaxHealth;
		public int Health;
		
		public CharacterClassData CharacterClass;

		public int BaseStrength;
		public int BaseAgility;
		public int BaseIntelligence;

		public int MinDamage;
		public int MaxDamage;

		public int Armor;

		public List<ItemData> Items = new();
		public List<AbilityData> Abilities = new();
	}
}