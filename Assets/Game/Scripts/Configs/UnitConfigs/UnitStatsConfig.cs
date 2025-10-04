using Game.Scripts.CoreGameplay.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/Unit Stats Config", fileName = "UnitStatsConfig")]
	public class UnitStatsConfig : ScriptableObject
	{
		[SerializeField] private float _armorToHealthMultiplier;

		[SerializeField] private ScalingStat _primaryDamageStat;
		[SerializeField] private float _damageScalingFactor;

		//Dodge
		[SerializeField] private float _baseDodgeChance;
		[SerializeField] private float _dodgePerAgility;

		//Crit
		[SerializeField] private float _baseCritChance;
		[SerializeField] private float _critPerAgility;
		[SerializeField] private float _critMultiplier;

		public CharacterClassData GetClassData()
		{
			return new CharacterClassData()
			{
				ArmorToHealthMultiplier = _armorToHealthMultiplier,
				PrimaryDamageStat = _primaryDamageStat,
				DamageScalingFactor = _damageScalingFactor,
				BaseDodgeChance = _baseDodgeChance,
				DodgePerAgility = _dodgePerAgility,
				
				BaseCritChance = _baseCritChance,
				CritPerAgility = _critPerAgility,
				CritMultiplier = _critMultiplier,
			};
		}
	}
}