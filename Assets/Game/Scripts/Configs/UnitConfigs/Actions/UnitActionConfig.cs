using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/UnitActionConfig", fileName = "UnitActionConfig")]
	public class UnitActionConfig : ScriptableObject
	{
		[SerializeField] private Sprite _icon;
		[SerializeField] private TActionType _actionType;
		[SerializeField] private UnitActionParams _params;
		[SerializeField] List<UnitActionEffectConfig> _effects;

		public Sprite Icon => _icon;
		public TActionType ActionType => _actionType;

		public UnitActionParams Params => new()
			{MinActionValue = _params.MinActionValue, MaxActionValue = _params.MaxActionValue};

		public List<UnitActonEffects> GetEffects()
		{
			return _effects.Select(config => new UnitActonEffects(config)).ToList();
		}
	}
}