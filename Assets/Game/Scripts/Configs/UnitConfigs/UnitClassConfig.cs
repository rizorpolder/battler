using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/UnitClassConfig", fileName = "UnitClassConfig")]
	public class UnitClassConfig : ScriptableObject
	{
		public int HealthPerStrength = 100;
		public int StrengthForHealht = 10;

		//классовые множители (базовая характеристика конкретного класса дает больше урона от статы)
		[Space, Header("Stats Multipliers")]
		// от силы зависит количество жизни персонажа (+100 за каждые 10) + физический урон у воина
		public float StrengthMultiplier; 
		
		// от ловкостти зависит (шанс и размер крита физических аттак), (шанс уклона) и (снижается шанс промаха)
		public float AgilityMultiplier; 

		//магу добавить щит который поглащает урон размер зависит от интелекта
		//от интеллекта зависит размер магического урона, шанс крита и размер магических аттак
		public float IntelligenceMultiplier; 

		[Space, Header("Misses")]
		public float MissCoeff;
		public float MissChance;

		[Space, Header("Dodge")]
		public float DodgeCoeff;

		public float DodgeChance;

		[Space, Header("Critical")]
		public float CritCoef;

		public float CritChance;
		public float CtitMultiplier;

		[Space, Header("Block")]
		[Tooltip("Коэффициент для классов")]
		public float BlockCoef;
		public float BlockChance;
		
		[Tooltip("Процентов от брони")]
		public float BlockValue;

		
		//calculation
		//warrior  resultStrength (для рассчета урона) = (strength(base) + strength (items)) * StrengthMultiplier
		//			resultAgility (для рассчета шансов) = (agility(base) + agility(items)) * AgilityMultiplier; 
		//			resultIntelligence  (для рассчета маг аттак) = (intelligence(base) + intelligence (items)) * IntelligenceMultiplier

		//			blockValue = Armor * BlockCoeff; 

		//если условно всем дается 10% от силы в атаку, то 
		// warrior attackValue = (items attack value (random min/max) * (resultStrength * 0.1);
		// warrior missChance =  resultAgility * MissCoeff;
		// warrior critChance = resultAgility * CritCoeff;
	}
}