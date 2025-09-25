using Game.Scripts.CoreGameplay.Controllers.Player;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IGameControllerCommand
	{

		public void MarkPlayerReady();
		public void EndOfTurn();
		public void BattleResult();

		public void CreateAction(UnitType caller, AUnitAction action);
	}
}