using Game.Scripts.CoreGameplay.Controllers;
using Spine.Unity;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;


		private void Start()
		{
		}

		private void OnCharacterDeathHandler()
		{
			
		}
	}
}