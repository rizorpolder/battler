using Game.Scripts.Services.SaveDataService.DataSerializer;
using VContainer;

namespace Game.Scripts.Services.SaveDataService
{
	public abstract class ADataSaver : IDataSaver
	{
		protected IDataSerializer _serializer;

		[Inject]
		public ADataSaver(IDataSerializer serializer)
		{
			_serializer = serializer;
		}

		public abstract void SaveData<T>(T data, string fileName);

		public abstract T LoadData<T>(string fileName);
	}
}