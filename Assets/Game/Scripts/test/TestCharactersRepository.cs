using System.Collections.Generic;
using Game.Scripts.Configs;
using UnityEngine;

namespace Game.Scripts.test
{
	[CreateAssetMenu(menuName = "Configs/Test/CharactersRepo", fileName = "Characters Repo")]
	public class TestCharactersRepository : ScriptableObject
	{
		public List<UnitConfig> configs;
	}
}