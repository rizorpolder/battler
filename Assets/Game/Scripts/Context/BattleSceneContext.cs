using Game.Scripts.Context.Abstract;
using Game.Scripts.CoreGameplay.Controllers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Context
{
	public class BattleSceneContext : ASceneContext
	{
		[SerializeField] private GameController _gameController;

		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterComponent(_gameController).AsImplementedInterfaces();
		}
	}
}