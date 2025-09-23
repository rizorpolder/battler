using Game.Scripts.CoreGameplay.Controllers;

namespace Game.Scripts.Services.NetworkService
{
	public interface IWSControllerCommand
	{
		public void CreateConnection();
		public void Disconnect();

		public void MarkPlayerReady(bool isReady);

		public void PlayerEndTurn();

		public void OnBattleEnd(BattleResultType result);

	}
}