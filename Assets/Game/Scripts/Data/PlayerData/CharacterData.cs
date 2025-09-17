namespace Game.Scripts.Data
{
	public class CharacterData
	{
		public int MaxHealthPoints;
		public int CurrentHealthPoints;
		public int AttackValue;

		public static CharacterData Default => new CharacterData()
		{
			MaxHealthPoints = 100,
			CurrentHealthPoints = 100,
			AttackValue = 10,
		};
	}
}