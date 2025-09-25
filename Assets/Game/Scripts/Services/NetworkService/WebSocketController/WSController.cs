using System;
using Firesplash.GameDevAssets.SocketIO;
using Game.Scripts.CoreGameplay.Controllers;
using UnityEngine;

namespace Game.Scripts.Services.NetworkService
{
	public class WSController : MonoBehaviour, IWSControllerCommand, IWSControllerListener
	{
		[SerializeField] private SocketIOCommunicator _socketIOCommunicator;

		public event Action OnConnectionEstablished;
		public event Action OnConnectionLost;
		public event Action OnUserConnected;
		public event Action OnMatchmakingReady;
		public event Action OnTurnResult;

		public void CreateConnection()
		{
			_socketIOCommunicator.Instance.Connect();

			_socketIOCommunicator.Instance.On("connected", OnSocketConnected);
			_socketIOCommunicator.Instance.On("disconnected", OnSocketDisconnected);
		}

		public void Disconnect()
		{
			UnsubscribeEvents();
			_socketIOCommunicator.Instance.Close();
		}

		private void OnSocketConnected(string data)
		{
			SubscribeEvents();
			OnConnectionEstablished?.Invoke();
		}

		private void OnSocketDisconnected(string data)
		{
			UnsubscribeEvents();
			OnConnectionLost?.Invoke();
		}

		private void SubscribeEvents()
		{
			//subscribe on all events after connected to socket
			throw new NotImplementedException();
		}

		private void UnsubscribeEvents()
		{
			//unsubscribe after disconnect
			throw new NotImplementedException();
		}

		//ws callback
		public void UserConnected()
		{
			OnUserConnected?.Invoke();
		}

		// ws callback
		public void MatchmakingReady()
		{
			OnMatchmakingReady?.Invoke();
		}

		public void MarkPlayerReady(bool isReady)
		{
			//ws.send (userReady, bool)
		}

		public void PlayerEndTurn() // player turn data
		{
			//ws.send (turn data)
		}

		//ws callback
		public void TurnResult() //battle result data
		{
			OnTurnResult?.Invoke();
		}

		public void OnBattleEnd(BattleResultType result)
		{
			//ws.sent (battleCompleted, result(win/lose)
		}
	}
}