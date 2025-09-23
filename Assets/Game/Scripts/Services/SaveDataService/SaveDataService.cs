using Game.Scripts.Enums;
using VContainer;

namespace Game.Scripts.Services.SaveDataService
{
	//Сервис который будет сохранять данные по их типу
	//Сюда прокидывается тип, он берет и сохраняет через сейвер локально либо на сервер

	public class SaveDataService : IDataSaverCommand
	{
		private IDataSaver _saver;

		[Inject]
		public SaveDataService(IDataSaver saver)
		{
			_saver = saver;
		}

		public bool TryLoadData<T>(SaveDataType dataType, out T result)
		{
			result = default(T);
			var data = _saver.LoadData<T>(dataType.ToString());
			if (data == null)
				return false;

			result = data;
			return true;
		}

		public void TrySaveData<T>(T data, SaveDataType dataType)
		{
			_saver.SaveData(data, dataType.ToString()); //todo добавить комманды на сохранения (чтоб постоянно не дергать сейвер)
		}
	}
}