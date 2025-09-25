using Game.Scripts.Configs.ActionsConfig;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Data
{
	public class HealingTouchAction : UnitSpellAction
	{
		public HealingTouchAction(AActionConfig config) : base(config)
		{
		}

		public override void ExecuteAction(Unit target)
		{
			target.GetHeal(Random.Range(_minValue, _maxValue));
		}
	}
}