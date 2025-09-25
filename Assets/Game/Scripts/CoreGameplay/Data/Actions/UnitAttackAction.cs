using Game.Scripts.Configs.ActionsConfig;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Data
{
	public abstract class UnitAttackAction : AUnitAction
	{
		public UnitAttackAction(AActionConfig config) : base(config)
		{
		}

		public override void ExecuteAction(Unit target)
		{
			var random = Random.Range(0, 100);
			var result = Random.Range(_minValue, _maxValue);
			target.GetDamage(result);
		}
	}
}