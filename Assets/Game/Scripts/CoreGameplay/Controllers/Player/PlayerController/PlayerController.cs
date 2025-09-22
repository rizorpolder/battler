using System;
using System.Collections.Generic;

namespace Game.Scripts.CoreGameplay.Controllers.PlayerController
{
	public class PlayerController : IPlayerData, IPLayerCommand, IPlayerListener
	{
		public event Action OnPlayerDataChanged;

		private List<string> _playerActionQueue = new List<string>();
		public List<string> PlayerActionQueue => _playerActionQueue;


		public PlayerController(string playerName)
		{
			
		}
		
		public void AddPlayerAction(string actionName)
		{
			_playerActionQueue.Add(actionName);
			OnPlayerDataChanged?.Invoke();
		}

		public void RemovePlayerAction(int index)
		{
			_playerActionQueue.RemoveAt(index);
			OnPlayerDataChanged?.Invoke();
		}
	}
}