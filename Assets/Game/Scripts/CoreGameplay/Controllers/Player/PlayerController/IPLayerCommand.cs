namespace Game.Scripts.CoreGameplay.Controllers.PlayerController
{
	public interface IPLayerCommand
	{
		public void AddPlayerAction(string actionName); //temp (прокидывать сам Action)
		public void RemovePlayerAction(int index);
	}
}