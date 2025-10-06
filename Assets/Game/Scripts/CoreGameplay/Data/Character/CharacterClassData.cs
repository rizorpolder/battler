using Game.Scripts.Configs.UnitConfigs;

namespace Game.Scripts.CoreGameplay.Data
{
	public class CharacterClassData
	{
		public float ArmorToHealthMultiplier;

		public ScalingStat PrimaryDamageStat;
		public float DamageScalingFactor;

		//Dodge
		public float BaseDodgeChance;
		public float DodgePerAgility;

		//Crit
		public float BaseCritChance;
		public float CritPerAgility;
		public float CritMultiplier;

		public static CharacterClassData Default => new CharacterClassData()
		{
			ArmorToHealthMultiplier = 1.2f,
			PrimaryDamageStat = ScalingStat.None,
			DamageScalingFactor = 1f,
			
			BaseDodgeChance = 0.1f,
			DodgePerAgility = 0.01f,
			
			
			BaseCritChance = 0.15f,
			CritPerAgility = 0.01f,
			CritMultiplier = 2f,
			
			
		};
	}
}