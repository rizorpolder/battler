using System.Collections.Generic;
using Game.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Configs.CharacterClassConfig
{
	[CreateAssetMenu(menuName = "Configs/Character/CharacterClassesConfig", fileName = "CharacterClassesConfig")]
	public class CharacterClassesConfig : SerializedScriptableObject
	{
		[SerializeField] private Dictionary<CharacterClassType, CharacterClassConfig> _classesConfigs;
	}
}