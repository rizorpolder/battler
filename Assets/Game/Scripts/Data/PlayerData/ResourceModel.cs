namespace Game.Scripts.Data
{
	public class ResourceModel
	{
		private int _soft;
		private int _hard;
		private int _level;
		private int _experience;

		public int Soft => _soft;

		public int Hard => _hard;

		public int Level => _level;
		public int Experience => _experience;

		public void SetSoft(int value)
		{
			_soft = value;
		}

		public void SetHard(int value)
		{
			_hard = value;
		}

		public void SetLevel(int value)
		{
			_level = value;
		}

		public void SetExperience(int value)
		{
			_experience = value;
		}
	}
}