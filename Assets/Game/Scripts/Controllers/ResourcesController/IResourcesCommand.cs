using Game.Scripts.Data;

namespace Game.Scripts.Controllers.Resources
{
	public interface IResourcesCommand
	{
		public void AddResource(Resource resource);
		public bool SpendResource(Resource resource);
		public bool HasEnough(Resource resource);
	}
}