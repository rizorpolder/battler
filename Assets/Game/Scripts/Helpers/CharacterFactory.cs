using Game.Scripts.Configs;
using Game.Scripts.Configs.UnitConfigs;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Resources;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Helpers
{
	public class CharacterFactory
	{
		
		public CharacterData CreateFromConfig(UnitConfig config)
		{
			var characterData = config.GetCharacterData();
			// if (!_classesConfig.GetClassConfig(config.ClassType, out var classConfig))
			// {
			// 	characterData.CharacterClass = CharacterClassData.Default;
			// }

			//characterData.CharacterClass = 
			characterData.MaxHealth +=
				Mathf.RoundToInt(characterData.Armor * characterData.CharacterClass.ArmorToHealthMultiplier);

			return characterData;
		}

		public CharacterData CreateFromData(UnitData data)
		{
			
			return new CharacterData();
		}
		
		
	}
}