using Network;
using UnityEngine;

namespace Common
{
	public class ConfigurableRoot : MonoBehaviour
	{
		[SerializeField] private NetworkConfig _networkConfig;

		public NetworkConfig NetworkConfig => _networkConfig;
	}
}