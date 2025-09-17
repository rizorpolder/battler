using System;
using Game.Scripts.Network.WebSocketController;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class GameController : MonoBehaviour, IGameControllerCommand, IGameControllerListener, IGameControllerData
	{
		public event Action<bool> OnPlayerReady;
		public event Action OnPlayerTurn;
		public event Action<BattleResultType> OnBattleComplete;

		// [Inject] IWSControllerListener _listener;
		// [Inject] IWSControllerCommand _command;

		public void Hit()
		{
			Debug.Log("HIT");
		}

		public void BattleResult()
		{
		}

		public void MarkPlayerReady(bool isReady)
		{
			OnPlayerReady?.Invoke(isReady);
		}

		public void OnTurnCompleted()
		{
			OnPlayerTurn?.Invoke();
		}
	}

	public enum BattleResultType
	{
		Draw,
		Win,
		Lose
	}
}