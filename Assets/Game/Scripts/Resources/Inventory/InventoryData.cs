using System;
using System.Collections.Generic;

namespace Game.Scripts.Data.Inventory
{
	///Сериализуемый класс для сохранения данных на сервер/локально
	[Serializable]
	public class InventoryData 
	{
		public List<InventoryItemData> Items;

		public static InventoryData Default => new InventoryData()
		{
			Items = new List<InventoryItemData>()
		};
	}
}