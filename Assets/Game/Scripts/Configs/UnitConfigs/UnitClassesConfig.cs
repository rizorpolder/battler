using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Configs.UnitConfigs
{
	[CreateAssetMenu(menuName = "Configs/Unit/UnitClassesConfig", fileName = "UnitClassesConfig")]
	public class UnitClassesConfig : ScriptableObject
	{
		[SerializeField] private List<UnitClassWrapper> _classes;

		public bool GetClassConfig(TUnitClass type, out UnitClassConfig classConfig)
		{
			classConfig = null;
			var wrapper = _classes.FirstOrDefault(x => x.Type.Equals(type));
			if (wrapper == null)
				return false;

			classConfig = wrapper.unitClassConfigs;
			return true;
		}
	}

	[Serializable]
	public class UnitClassWrapper
	{
		public TUnitClass Type;
		public UnitClassConfig unitClassConfigs;
	}
}