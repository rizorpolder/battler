using System;

namespace Game.Scripts.Controllers
{
	public class UserController : IUserCommand, IUserListener, IUserData
	{
		public event Action<string> OnUserNameChanged;

		private string _username;
		private string _userID;

		public string UserName => _username;
		public string UserID => _userID;

		public void SetUserName(string username)
		{
			_username = username;
			OnUserNameChanged?.Invoke(username);
		}
	}
}