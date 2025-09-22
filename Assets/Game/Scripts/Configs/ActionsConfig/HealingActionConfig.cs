using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.ActionsConfig
{
	
	[CreateAssetMenu(menuName = "Configs/Actions/HealingAction", fileName = "Healing Action")]

	public class HealingActionConfig : AActionConfig
	{
		public override ActionType ActionType  => ActionType.Heal;
	}
}