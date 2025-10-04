using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.Controllers.MatchmakingController
{
	public interface IMatchmakingData
	{
		public CharacterData PlayerData { get; }
		public CharacterData OpponentData { get; }
	}
}