using Game.Scripts.Services.SaveDataService.DataSerializer;

namespace Game.Scripts.Services.SaveDataService
{
	public interface IDataSaver
	{
		public void SaveData<T>(T data, string fileName);
		public T LoadData<T>(string fileName);
	}
}