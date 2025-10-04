using System;
using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IBattleControllerListener
	{
		public event Action OnBattleLoaded;
		public event Action OnTurnPointsSpend;
		public event Action OnTurnPointsRestore;

		public event Action<AbilityData> OnActionAdded;
		public event Action<AbilityData> OnActionRemoved;
	}
}