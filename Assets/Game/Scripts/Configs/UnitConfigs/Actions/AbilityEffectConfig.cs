using Game.Scripts.CoreGameplay.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Abilities/Effect Config",fileName = "EffectConfig")]
	public class AbilityEffectConfig : ScriptableObject
	{
		[SerializeField] private string _id;
		[SerializeField] private Sprite _icon;
		[SerializeField] private EffectType _type;
		[SerializeField] private AffectedStat _targetStat;

		[SerializeField] private int _minValue;
		[SerializeField] private int _maxValue;

		[SerializeField] private float _duration;
		[SerializeField] private bool _isStackable;
		[SerializeField] private bool _blockMagicDamage;
		[SerializeField] private bool _blockPhysicalDamage;

		[SerializeField] private ScalingStat _scalingStat;
		[SerializeField] private float _scalingFactor;

		public AbilityEffectData GetEffectData()
		{
			return new AbilityEffectData()
			{
				Id = _id,
				Icon = _icon,
				Type = _type,
				TargetStat = _targetStat,
				MinValue = _minValue,
				MaxValue = _maxValue,
				Duration = _duration,
				IsStackable = _isStackable,
				BlockMagicDamage = _blockMagicDamage,
				BlockPhysicalDamage = _blockPhysicalDamage,
				ScalingStat = _scalingStat,
				ScalingFactor = _scalingFactor,
			};
		}
	}
}