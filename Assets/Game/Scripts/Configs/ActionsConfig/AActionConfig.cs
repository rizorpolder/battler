using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.ActionsConfig
{
	public abstract class AActionConfig : ScriptableObject
	{
		[SerializeField] public int RequiredLevel;
		[SerializeField] public string Name;
		[SerializeField] public int MinValue;
		[SerializeField] public int MaxValue;
		[SerializeField] public Sprite Icon;
		public abstract ActionType ActionType { get; }
	}
}