using System.Collections.Generic;
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
	}
}