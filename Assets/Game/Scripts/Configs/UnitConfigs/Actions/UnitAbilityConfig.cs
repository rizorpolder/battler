using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Abilities/Unit Ability Config",fileName = "AbilityConfig")]
	public class UnitAbilityConfig : ScriptableObject
	{
		[SerializeField] private string _id;
		[SerializeField] private Sprite _icon;
		[SerializeField] private int _minBaseDamage;
		[SerializeField] private int _maxBaseDamage;
		[SerializeField] private bool _isMagic;

		[SerializeField] private ScalingStat _scalingStat;
		[SerializeField] private float scalingFactor;

		[SerializeField] private List<AbilityEffectConfig> _effects;

		public AbilityData GetAbilityData()
		{
			var result = new AbilityData()
			{
				Id = _id,
				Icon = _icon,
				MinBaseDamage = _minBaseDamage,
				MaxBaseDamage = _maxBaseDamage,
				IsMagic = _isMagic,
				ScalingStat = _scalingStat,
				ScalingFactor = scalingFactor,
			};

			foreach (var effect in _effects)
			{
				result.Effects.Add(effect.GetEffectData());
			}

			return result;
		}
	}
}