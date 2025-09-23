using Game.Scripts.Enums;

namespace Game.Scripts.Services.SaveDataService
{
	public interface IDataSaverCommand
	{
		public bool TryLoadData<T>(SaveDataType dataType, out T result);
		public void TrySaveData<T>(T data, SaveDataType dataType);
	}
}