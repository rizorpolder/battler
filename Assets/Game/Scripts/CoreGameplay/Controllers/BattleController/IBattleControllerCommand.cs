using Game.Scripts.CoreGameplay.Data;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public interface IBattleControllerCommand
	{
		public void AddAbilityToQueue(AbilityData data);
		public void RemoveAbilityFromQueue(AbilityData data);
	}
}