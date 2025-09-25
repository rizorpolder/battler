using System.Collections.Generic;
using Game.Scripts.CoreGameplay.Data;
using Game.Scripts.Enums;

namespace Game.Scripts.Data
{
	public class Unit
	{
		private int _health;
		private int _maxHealth;

		private int _armorValue;

		private CharacterClassType _type;
		private UnitType _unitType;

		public UnitType UnitType => _unitType;

		private List<string> items;

		private List<AUnitAction> _unitSkills;

		public bool IsDeath => _health <= 0;

		public Unit()
		{
		}

		public Unit(UnitType unitType)
		{
			_unitType = unitType;
		}

		public void GetDamage(int damage)
		{
			_health -= damage;
			if (_health <= 0)
			{
				_health = 0;
			}
		}

		public void GetHeal(int heal)
		{
			var prevHealth = _health;
			_health += heal;
			if (_health > _maxHealth)
			{
				_health = _maxHealth;
			}
		}
	}
}