using System.Collections.Generic;
using Game.Scripts.Configs.InventoryConfigs;
using Game.Scripts.Configs.UnitConfigs;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Configs/Unit/Unit Config",fileName = "UnitConfig")]
	public class UnitConfig : ScriptableObject
	{
		//TODO нужно развести для AI и базового функционала
		
		[SerializeField] private UnitStatsConfig statsConfig;

		[SerializeField] private int baseStrength;
		[SerializeField] private int baseAgility;
		[SerializeField] private int baseIntelligence;

		[SerializeField] private int baseMinDamage;
		[SerializeField] private int baseMaxDamage;

		[SerializeField] private int baseArmor;

		[SerializeField] private int maxHealth;

		[SerializeField] private List<EquipableItemConfig> equippedItems;
		[SerializeField] private List<UnitAbilityConfig> abilities;

		public CharacterData GetCharacterData()
		{
			var data = new CharacterData
			{
				BaseStrength = baseStrength,
				BaseAgility = baseAgility,
				BaseIntelligence = baseIntelligence,
				MinDamage = baseMinDamage,
				MaxDamage = baseMaxDamage,
				Armor = baseArmor,
				MaxHealth = maxHealth
			};

			foreach (var itemSO in equippedItems)
			{
				data.Items.Add(itemSO.GetItemData());
			}

			foreach (var abilitySO in abilities)
			{
				data.Abilities.Add(abilitySO.GetAbilityData());
			}

			return data;
		}
	}
}