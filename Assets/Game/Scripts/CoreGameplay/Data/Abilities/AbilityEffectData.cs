using Game.Scripts.Configs.UnitConfigs;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Data
{
	public class AbilityEffectData
	{
		public string Id;
		public Sprite Icon;
		public EffectType Type;
		public AffectedStat TargetStat;

		public int MinValue;
		public int MaxValue;

		public float Duration;
		public bool IsStackable;

		public bool BlockMagicDamage;
		public bool BlockPhysicalDamage;

		public ScalingStat ScalingStat;
		public float ScalingFactor;
	}
}