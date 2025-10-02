using Game.Scripts.Configs.UnitConfigs;
using UnityEngine;

namespace Game.Scripts.Data
{
	public class UnitActonEffects
	{
		private Sprite _effectSprite;
		private TActionEffect _effect;
		private TActionType _type;
		private UnitActionParams _params;
		private int _roundsTick;

		public UnitActonEffects(UnitActionEffectConfig _config)
		{
			_effectSprite = _config.Sprite;
			_effect = _config.Effect;
			_type = _config.ActionType;
			_params = _config.Params;
			_roundsTick = _config.RoundsTick;
		}
	}
}