using System.Collections.Generic;
using Game.Scripts.Configs.UnitConfigs;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Data
{
	public class AbilityData
	{
		public string Id;
		public Sprite Icon;
		public int MinBaseDamage;
		public int MaxBaseDamage;
		public bool IsMagic;
		public ScalingStat ScalingStat;
		public float ScalingFactor;
		public List<AbilityEffectData> Effects;
	}
}