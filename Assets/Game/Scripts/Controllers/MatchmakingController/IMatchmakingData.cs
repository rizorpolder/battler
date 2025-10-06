using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.Controllers.MatchmakingController
{
	public interface IMatchmakingData
	{
		public List<CharacterBattleData> CharacterBattleData { get; }
	}

	public class CharacterBattleData
	{
		public bool IsPlayer;
		public CharacterData PlayerData;
	}
}