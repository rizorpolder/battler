using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName =  "Configs/Unit/UnitActionEffectConfig", fileName = "UnitActionEffectConfig")]

	public class UnitActionEffectConfig : ScriptableObject
	{
			[SerializeField] TActionEffect _effect;
			[SerializeField] TActionType _actionType;
			[SerializeField] UnitActionParams _params;
			[SerializeField] private int _roundsTick;
	}

	public enum TActionEffect
	{
		Instant,
		Tickable,
		Scheduled
	}
	
}