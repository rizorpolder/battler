using System;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IGameControllerListener
	{
		public event Action<bool> OnPlayerReady;
		public event Action OnPlayerTurn;

		public event Action<BattleResultType> OnBattleComplete;
	}
}