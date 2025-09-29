using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using Game.Scripts.Enums.Inventory;

namespace Game.Scripts.Resources
{
	[Serializable]
	public class UnitData //данные пользовательского персонажа
	{
		public int Level;
		public int Experience;
		
		public int UnitHealht;

		public TUnitClass UnitClass;

		public List<ItemData> EquippedItems;

		public List<UnitActionData> Actions;

		public static UnitData Default => new UnitData()
		{
			Level = 1,
			UnitHealht = 100,
			
			UnitClass = TUnitClass.Warrior,
			EquippedItems = new List<ItemData>(),
			Actions = new List<UnitActionData>(),
		};
	}

	[Serializable]
	public class ItemData
	{
		public TItemPosition Position;
		public string itemID;
	}

	[Serializable]
	public class UnitActionData
	{
		public int Level;
		public string ActionID;
	}
}