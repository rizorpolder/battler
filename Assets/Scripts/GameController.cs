using Network;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] NetworkConfig _networkConfig;

		[SerializeField] private PlayerController _playerOne;
		[SerializeField] private PlayerController _playerTwo;

		public void Start()
		{
			_playerOne.OnPlayerButtonClicked += SendDataToServer;
			_playerTwo.OnPlayerButtonClicked += SendDataToServer;
		}

		private void SendDataToServer()
		{
			//отправка на сервер данных по удар/защита  и ожидание результата вычислений
		}

		public void ServerDataResponse()
		{
			//возврат данных с сервера и отображение у пользователя
		}

		public void UserReadyRequest()
		{
			//отправка данных на сервер что ход закончен и пользователь готов к выбору (анимации закончились)
		}

		public void UserReadyResponse()
		{
			//ответ от сервера что оба пользователя готовы \\ стартует выбор удара и таймер
		}
	}
}