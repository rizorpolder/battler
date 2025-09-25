using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.CoreGameplay.Controllers.Player
{
	public interface IPlayerCommand
	{
		public void ActionImpact(AUnitAction action);
		public void ActionCall(AUnitAction action);
		public void IncreaseStepPoints();
	}
}