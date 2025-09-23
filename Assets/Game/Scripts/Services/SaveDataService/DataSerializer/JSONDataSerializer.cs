namespace Game.Scripts.Services.SaveDataService.DataSerializer
{
	public class JSONDataSerializer : IDataSerializer
	{
		public string Serialize<T>(T data)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			return json;
		}

		public T Deserialize<T>(string str)
		{
			var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
			return data;
		}
	}
}