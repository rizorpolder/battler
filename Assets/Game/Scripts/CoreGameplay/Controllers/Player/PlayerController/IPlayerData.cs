using System.Collections.Generic;

namespace Game.Scripts.CoreGameplay.Controllers.PlayerController
{
	public interface IPlayerData
	{
		List<string> PlayerActionQueue { get; }
	}
}