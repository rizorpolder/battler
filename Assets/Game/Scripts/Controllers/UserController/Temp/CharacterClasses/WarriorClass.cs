using Game.Scripts.Enums;

namespace Game.Scripts.Controllers.Temp
{
	public class WarriorClass : ACharacterClass
	{
		public override CharacterClassType CharacterClassType => CharacterClassType.Warrior;

		public override float StrengthCoeff => 0.5f;
		public override float AgilityCoeff => 0.2f;
		public override float IntelligenceCoeff => 0.1f;

		//от силы зависит урон (
	}
}