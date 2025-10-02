namespace Game.Scripts.Data
{
	public class PlayerUnitModel //создается из UnitData
	{
		private int _health;
		private int _maxHealth;
		public int Health => _health;

		public int Armor;

		public bool IsDeath => _health <= 0;

		public void SetHealth(int health)
		{
			_health = health;
		}

		public void AddDamage(int value)
		{
			_health -= value;
			{
				if (_health < 0)
				{
					_health = 0;
				}
			}
		}

		public void AddHeal(int value)
		{
			_health += value;
			if (_health > _maxHealth)
			{
				_health = _maxHealth;
			}
		}
	}
}