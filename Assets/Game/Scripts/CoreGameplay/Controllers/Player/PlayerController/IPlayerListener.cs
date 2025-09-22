using System;

namespace Game.Scripts.CoreGameplay.Controllers.PlayerController
{
	public interface IPlayerListener
	{
		public event Action OnPlayerDataChanged;
	}
}