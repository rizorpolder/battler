using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IBattleControllerData
	{
		public List<AbilityData> AbilitiesQueue { get; }

		public int CurrentTurnPoints { get; }
		public CharacterData PlayerData { get; }
		public CharacterData EnemyData { get; }
	}
}