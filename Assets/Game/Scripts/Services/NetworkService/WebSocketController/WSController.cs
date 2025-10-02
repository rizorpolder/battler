using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Firesplash.GameDevAssets.SocketIO;
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

		private SocketIOInstance Instance => _socketIOCommunicator.Instance;

		public void CreateConnection()
		{
			Debug.Log($"Status : {Instance.Status}");
			if (Instance.IsConnected())
				return;

			var addr = "http://127.0.0.1:8080";
			Instance.Connect(addr, false);
			Instance.On("connected", OnSocketConnected);
			Instance.On("disconnected", OnSocketDisconnected);
		}

		public void Disconnect()
		{
			if (!Instance.IsConnected())
			{
				Debug.Log("Not connected");
				return;
			}

			Instance.Close();
			UnsubscribeEvents();
		}

		private void OnSocketConnected(string data)
		{
			Debug.Log("Connection established " + data);

			SubscribeEvents();
			OnConnectionEstablished?.Invoke();
		}

		private void OnSocketDisconnected(string data)
		{
			Debug.Log("Disconnected " + data);

			UnsubscribeEvents();
			OnConnectionLost?.Invoke();
		}

		private void SubscribeEvents()
		{
			//subscribe on all events after connected to socket
			Instance.On("userConnected", UserConnected);
			Instance.On("matchmakingReady", MatchmakingReady);
		}

		private void UnsubscribeEvents()
		{
			//unsubscribe after disconnect
			Instance.Off("connected", OnSocketConnected);
			Instance.Off("disconnected", OnSocketDisconnected);

			Instance.Off("userConnected", UserConnected);
			Instance.Off("matchmakingReady", MatchmakingReady);
		}

		//ws callback
		public void UserConnected(string data)
		{
			OnUserConnected?.Invoke();
		}

		// ws callback
		public void MatchmakingReady(string data)
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

		public void OnBattleEnd()
		{
			//ws.sent (battleCompleted, result(win/lose)
		}
	}
}