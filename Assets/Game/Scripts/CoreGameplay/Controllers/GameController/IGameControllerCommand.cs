namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IGameControllerCommand
	{

		public void MarkPlayerReady(bool isReady);
		public void EndOfTurn();
		public void BattleResult();
	}
}