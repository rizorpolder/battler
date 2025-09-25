using Game.Scripts.Configs.ActionsConfig;
using Game.Scripts.Data;
using Game.Scripts.Enums;

namespace Game.Scripts.CoreGameplay.Data
{
	public abstract class AUnitAction
	{
		public int Price { get; protected set; }
		public ActionType ActionType { get; protected set; }

		protected int _minValue;
		protected int _maxValue;

		protected AUnitAction(AActionConfig config)
		{
			ActionType = config.ActionType;
			Price = config.Price;
			_minValue = config.MinValue;
			_maxValue = config.MaxValue;
		}

		public abstract void ExecuteAction(Unit target);
	}
}