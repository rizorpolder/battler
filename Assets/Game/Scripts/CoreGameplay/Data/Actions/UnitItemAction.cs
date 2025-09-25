using Game.Scripts.Configs.ActionsConfig;
using Game.Scripts.Data;

namespace Game.Scripts.CoreGameplay.Data
{
	public abstract class UnitItemAction : AUnitAction
	{
		public UnitItemAction(AActionConfig config) : base(config)
		{
		}

		public override void ExecuteAction(Unit target)
		{
			throw new System.NotImplementedException();
		}
	}
}