using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/UnitActionEffectConfig", fileName = "UnitActionEffectConfig")]
	public class UnitActionEffectConfig : ScriptableObject
	{
		[SerializeField] private Sprite _effectSprite;
		[SerializeField] private TActionEffect _effect;
		[SerializeField] private TActionType _actionType;
		[SerializeField] private UnitActionParams _params;
		[SerializeField] private int _roundsTick;

		public Sprite Sprite => _effectSprite;
		public TActionEffect Effect => _effect;
		public TActionType ActionType => _actionType;

		public UnitActionParams Params => new()
			{MaxActionValue = _params.MaxActionValue, MinActionValue = _params.MinActionValue};

		public int RoundsTick => _roundsTick;
	}

	public enum TActionEffect
	{
		Instant,
		Tickable,
		Scheduled
	}
}