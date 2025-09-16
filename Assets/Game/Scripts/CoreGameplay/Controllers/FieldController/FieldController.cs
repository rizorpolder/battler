using Game.Scripts.CoreGameplay.Views;
using UnityEngine;

namespace Game.Scripts.CoreGameplay.Controllers
{
	public class FieldController : MonoBehaviour
	{
		[SerializeField] private CharacterView _playerOneView;
		[SerializeField] private CharacterView _playerTwoView;
	}
}