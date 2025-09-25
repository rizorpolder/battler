using System;

namespace Game.Scripts.CoreGameplay.Controllers.Player
{
	public interface IPlayerListener
	{
		public event Action<int, int> OnPlayerHealthChanged;
		public event Action OnPlayerDeath;
		public event Action OnStepPointsChanged;

	}
}