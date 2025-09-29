using System;

namespace Game.Scripts.Data.Inventory
{
	///Сериализуемый тип об объекте инвентаря
	[Serializable]
	public class InventoryItemData
	{
		public string ItemID;
		public bool IsEqipped;
	}
}