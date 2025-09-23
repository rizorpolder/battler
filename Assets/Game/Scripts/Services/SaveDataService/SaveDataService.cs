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
	}
}