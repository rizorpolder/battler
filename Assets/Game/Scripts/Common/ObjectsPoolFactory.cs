using Game.Scripts.Common.Flappy_Bird.Scripts.Common;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Common
{
	public class ObjectsPoolFactory
	{
		private IObjectResolver _objectResolver;

		[Inject]
		public ObjectsPoolFactory(IObjectResolver objectResolver)
		{
			_objectResolver = objectResolver;
		}

		public ObjectsPool<T> CreatePool<T>(Transform parent, T prefab) where T : MonoBehaviour
		{
			var result = new ObjectsPool<T>(parent, prefab);
			_objectResolver.Inject(result);
			return result;
		}
	}
}