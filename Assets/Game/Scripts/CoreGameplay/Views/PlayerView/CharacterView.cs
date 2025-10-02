using Game.Scripts.Controllers;
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

		public void Start()
		{
			_skillButton.onClick.AddListener(AddAction);
		}

		[Inject]
		public void ResolvePlayerCommand(IObjectResolver resolver)
		{
			var unitData =  resolver.Resolve<IUnitData>();
			foreach (var action in unitData.UnitAction)
			{
				
			}
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