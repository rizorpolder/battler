using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Network
{
	[CreateAssetMenu(fileName = "NetworkConfig", menuName = "Project/NetworkConfig")]
	public class NetworkConfig : ScriptableObject
	{
		[SerializeField] private List<NetworkConfigData> networks;
		[SerializeField] private NetworkServer _currentServer;

		public NetworkServer PriorityServer => _currentServer;

		public NetworkConfigData GetNetworkPath()
		{
			return networks.First(x => x.server == _currentServer);
		}

		public string GetRestApiUri()
		{
			var path = GetNetworkPath();
			return $"{path.protocol.ToUriString()}{path.url}";
		}
	}

	[Serializable]
	public struct NetworkConfigData
	{
		public NetworkServer server;
		public NetworkProtocol protocol;
		public string url;
		public string key;
	}
}