using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Configs/Unit/UnitLevelsConfig", fileName = "UnitLevelsConfig")]
	public class UnitLevelsConfig : ScriptableObject
	{
		[SerializeField] public List<UnitLevelData> _unitLevels;

		public int GetRequiredExperience(int level)
		{
			foreach (UnitLevelData unitLevelData in _unitLevels)
			{
				if (unitLevelData.Level == level)
				{
					return unitLevelData.RequiredExperience;
				}
			}

			return 0;
		}

		public UnitLevelData GetNextLevelData(int currentLevel)
		{
			foreach (UnitLevelData unitLevelData in _unitLevels)
			{
				if (unitLevelData.Level == currentLevel + 1)
					return unitLevelData;
			}

			return null;
		}
	}

	[Serializable]
	public class UnitLevelData
	{
		public int Level;
		public int RequiredExperience;
	}
}