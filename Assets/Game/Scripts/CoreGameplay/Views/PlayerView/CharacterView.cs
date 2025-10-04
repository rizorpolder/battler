using Game.Scripts.CoreGameplay.Controllers;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Scripts.CoreGameplay.Views
{
	public class CharacterView : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _skeletonAnimation;
		[SerializeField] private Button _skillButton;
		
		[SerializeField] private TUnitControl _unitControl;

		[Inject] private IBattleControllerListener _battleControllerListener; 
		
		public void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		private void AddAction()
		{
		}

		private void OnPlayerDataChangedHandler()
		{
		}

	}

	public enum TUnitControl
	{
		Player,
		Enemy
	}
}