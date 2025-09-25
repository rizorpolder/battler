using Game.Scripts.Configs.CharacterClassConfig;
using Game.Scripts.Configs.InventoryConfigs;
using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Configs/ConfigsRepository", fileName = "ConfigsRepository")]
	public class ConfigsRepository : ScriptableObject
	{
		[SerializeField] public CoreConfig coreConfig;
		[SerializeField] public InventoryItemsConfig itemsConfig;
		[SerializeField] public CharacterClassesConfig characterClassesConfig;
	}
}