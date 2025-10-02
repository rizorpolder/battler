namespace Game.Scripts.Controllers.MatchmakingController
{
	public interface IMatchmakingCommand
	{
		public void FindMatchmaking();
		
		public void MarkPlayerAsReady();
		public void PlayerEndTurn();

		public void CancelMatchmaking();
	}
}