using Game.Scripts.CoreGameplay.Controllers.PlayerController;
using Spine.Unity;
using UnityEngine;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;

		[Inject]
		public void InitializeCharacter(PlayerController playerController)
		{
			playerController.OnPlayerDataChanged += OnPlayerDataChangedHandler;
		}

		private void OnPlayerDataChangedHandler()
		{
			Debug.Log("Player Data Changed");
		}
	}
}