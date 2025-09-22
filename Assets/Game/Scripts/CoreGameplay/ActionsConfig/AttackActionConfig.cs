using UnityEngine;

namespace Game.Scripts.CoreGameplay.ActionsConfig
{
	[CreateAssetMenu(menuName = "Actions/AttackAction", fileName = "Attack Action")]
	public class AttackActionConfig : AActionConfig
	{
		public override ActionType ActionType => ActionType.Attack;
		[SerializeField] public AttackType AttackType;
	}
}