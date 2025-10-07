using System;
using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IBattleControllerListener
	{
		public event Action OnBattleLoaded;
		public event Action OnTurnPointsChanged;
		
		public event Action OnAbilitiesQueueChanged;
	}
}