using Game.Scripts.Services.SaveDataService.DataSerializer;
using UnityEngine;

namespace Game.Scripts.Services.SaveDataService
{
	public class PlayerPrefsDataSaver : ADataSaver
	{
		public PlayerPrefsDataSaver(IDataSerializer serializer) : base(serializer)
		{
		}

		public override void SaveData<T>(T data, string fileName)
		{
			var str = _serializer.Serialize(data);
			PlayerPrefs.SetString(fileName, str);
			PlayerPrefs.Save();
		}

		public override T LoadData<T>(string fileName)
		{
			var data = PlayerPrefs.GetString(fileName, string.Empty);

			if (string.IsNullOrEmpty(data))
				return default;


			var result = _serializer.Deserialize<T>(data);
			return result;
		}
	}
}