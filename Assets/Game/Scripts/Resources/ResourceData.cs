
namespace Game.Scripts.Resources
{
	public class ResourceData
	{
		public int Soft;
		public int Hard;
		public int Level;
		public int Experience;
		
		public static ResourceData Default = new ResourceData()
		{
			Soft = 0,
			Hard = 0,
			Level = 1,
			Experience = 0,
		};
	}

}