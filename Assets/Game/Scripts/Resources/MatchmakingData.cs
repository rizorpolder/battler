using System;

namespace Game.Scripts.Resources
{
	///Сериализуемый тип о ММ котоыре возвращает сервер
	
	[Serializable]
	public class MatchmakingData
	{
		public string RoomID;
		
		public UnitData EnemyData;
		
	}
}