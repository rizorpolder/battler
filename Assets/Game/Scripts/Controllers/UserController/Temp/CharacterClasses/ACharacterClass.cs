using Game.Scripts.Enums;

namespace Game.Scripts.Controllers.Temp
{
	public abstract class ACharacterClass
	{
		public abstract CharacterClassType CharacterClassType { get; }
		
		public abstract float StrengthCoeff { get; }
		public abstract float AgilityCoeff { get; }
		public abstract float IntelligenceCoeff { get; }
		
	}
}