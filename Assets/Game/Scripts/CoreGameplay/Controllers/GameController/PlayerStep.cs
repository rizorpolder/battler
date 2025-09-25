using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class PlayerStep
	{
		private UnitType _caller;
		private AUnitAction _action;

		public UnitType CallerType => _caller;
		public AUnitAction UnitAction => _action;

		public PlayerStep(UnitType caller, AUnitAction action)
		{
			_caller = caller;
			_action = action;
		}
	}
}