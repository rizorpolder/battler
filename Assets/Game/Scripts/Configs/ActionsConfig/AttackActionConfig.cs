using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.ActionsConfig
{
	[CreateAssetMenu(menuName = "Configs/Actions/AttackAction", fileName = "Attack Action")]
	public class AttackActionConfig : AActionConfig
	{
		public override ActionType ActionType => ActionType.Attack;
		[SerializeField] public AttackType AttackType;
	}
}