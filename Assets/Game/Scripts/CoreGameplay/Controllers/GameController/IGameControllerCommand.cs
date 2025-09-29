
namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IGameControllerCommand
	{

		public void MarkPlayerReady();
		public void EndOfTurn();

		public void CreateAction();
	}
}