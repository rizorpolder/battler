namespace Game.Scripts.Services.SaveDataService.DataSerializer
{
	public interface IDataSerializer
	{
		public string Serialize<T>(T data);
		public T Deserialize<T>(string str);
	}
}