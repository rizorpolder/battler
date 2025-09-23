using System;
using System.Collections.Generic;

namespace Game.Scripts.Resources
{
	public class UserData
	{
		public string UserID;
		public string UserName;
		public List<KeyValueData> KeyValues;

		public static UserData Default => new UserData()
		{
			UserID = "",
			UserName = "",
			KeyValues = new List<KeyValueData>()
			
			//todo timers and other 
		};
	}

	[Serializable]
	public class KeyValueData
	{
		public string key;
		public string value;

		public KeyValueData(string k, string v)
		{
			key = k;
			value = v;
		}
	}
}