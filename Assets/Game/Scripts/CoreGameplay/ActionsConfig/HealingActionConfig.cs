using UnityEngine;

namespace Game.Scripts.CoreGameplay.ActionsConfig
{
	
	[CreateAssetMenu(menuName = "Actions/HealingAction", fileName = "Healing Action")]

	public class HealingActionConfig : AActionConfig
	{
		public override ActionType ActionType  => ActionType.Heal;
	}
}