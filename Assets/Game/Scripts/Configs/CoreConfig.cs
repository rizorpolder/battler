using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Game/Configs/CoreConfig", fileName = "CoreConfig")]
	public class CoreConfig : ScriptableObject
	{
		[SerializeField] public int PlayerWaitingInterval = 30;
		[SerializeField] public int StartTurnPoints = 2;
		[SerializeField] public int IncreaseTurnPoints = 2;
		[SerializeField] public int MaxTurnPoints = 8;
	}
}