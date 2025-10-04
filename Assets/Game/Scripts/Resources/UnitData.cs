using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using Game.Scripts.Enums.Inventory;

namespace Game.Scripts.Resources
{
	///Сериализуемый тип пользовательского персонажа
	[Serializable]
	public class UnitData
	{
		public TUnitClass UnitClass;
		
		public List<ItemData> EquippedItems;
		public List<UnitActionData> Actions;

		public static UnitData Default => new UnitData()
		{
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
		public string ActionID;
		public int Level;
	}
}