using Game.Scripts.Configs.InventoryConfigs;
using Game.Scripts.Configs.UnitConfigs;
using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Configs/ConfigsRepository", fileName = "ConfigsRepository")]
	public class ConfigsRepository : ScriptableObject
	{
		[SerializeField] public NetworkConfig networkConfig;

		[SerializeField] public CoreConfig coreConfig;
		[SerializeField] public InventoryItemsConfig itemsConfig;
		[SerializeField] public UnitClassesConfig unitClassesConfig;
		[SerializeField] public UnitLevelsConfig unitLevelsConfig;
	}
}