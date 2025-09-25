using System;

namespace Game.Scripts.Controllers
{
	public interface IUserListener
	{
		public event Action<string> OnUserNameChanged;
	}
}