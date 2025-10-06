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
		[Inject] private UnitClassesRepository _unitClassesRepository;

		public CharacterData CreateFromConfig(UnitConfig config)
		{
			var characterData = config.GetCharacterData();

			return RecalculateCharacterStats(characterData);
		}

		public CharacterData CreateFromData(UnitData data)
		{
			CharacterData characterData;
			if (!_unitClassesRepository.GetClassConfig(data.UnitClass, out var baseConfig))
			{
				Debug.LogAssertionFormat("No class config for " + data.UnitClass);
				characterData = CharacterData.Default;
				return characterData;
			}

			characterData = baseConfig.GetCharacterData();

			characterData.Items.Clear();

			foreach (var dataEquippedItem in data.EquippedItems)
			{
				//todo ItemsRepository.GetItem(Position,ID)
				//characterData.Items.Add(result);
			}

			characterData.Abilities.Clear();
			foreach (var unitActionData in data.Actions)
			{
				//todo ActionsRepository.GetItem(UnitActionID,Level)
				//characterData.Actions.Add(result);
			}

			return RecalculateCharacterStats(characterData);
		}

		private CharacterData RecalculateCharacterStats(CharacterData characterData)
		{
			return characterData;
		}
	}
}