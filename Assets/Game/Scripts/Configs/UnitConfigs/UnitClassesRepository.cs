using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/Unit Classes Repository", fileName = "UnitClassesConfig")]
	public class UnitClassesRepository : ScriptableObject
	{
		[SerializeField] private List<UnitClassWrapper> _classes;

		public bool GetClassConfig(TUnitClass type, out UnitConfig statsConfig)
		{
			statsConfig = null;
			var wrapper = _classes.FirstOrDefault(x => x.Type.Equals(type));
			if (wrapper == null)
				return false;

			statsConfig = wrapper.UnitConfig;
			return true;
		}
	}

	[Serializable]
	public class UnitClassWrapper
	{
		public TUnitClass Type;
		public UnitConfig UnitConfig;
	}
}