using System;

namespace Game.Scripts.Services.NetworkService
{
	public interface IWSControllerListener
	{

		public event Action OnConnectionEstablished;
		public event Action OnConnectionLost;
		public event Action OnUserConnected;
		public event Action OnMatchmakingReady;

		public event Action OnTurnResult;
	}
}