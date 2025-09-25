using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.CharacterClassConfig
{
	[CreateAssetMenu(menuName = "Configs/Character/CharacterClassesConfig", fileName = "CharacterClassesConfig")]
	public class CharacterClassesConfig : ScriptableObject
	{
		[SerializeField] private List<CharacterClassWrapper> _classes;

		public bool GetClassConfig(CharacterClassType type, out CharacterClassConfig classConfig)
		{
			classConfig = null;
			var wrapper = _classes.FirstOrDefault(x => x.Type.Equals(type));
			if (wrapper == null)
				return false;

			classConfig = wrapper.CharacterClassConfigs;
			return true;
		}
	}

	[Serializable]
	public class CharacterClassWrapper
	{
		public CharacterClassType Type;
		public CharacterClassConfig CharacterClassConfigs;
	}
}