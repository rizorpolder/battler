namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IBattleControllerCommand
	{
		public void StartTurn();
		public void MarkAsReady();
		public void EndOfTurn();
	}
}