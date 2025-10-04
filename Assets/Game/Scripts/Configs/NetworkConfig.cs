using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enums.Network;
using Game.Scripts.Extensions;
using UnityEngine;

namespace Game.Scripts.Configs
{
	[CreateAssetMenu(menuName = "Configs/Network/NetworkConfig", fileName = "NetworkConfig")]
	public class NetworkConfig : ScriptableObject
	{
		[SerializeField] private List<NetworkPath> networks;

		[SerializeField] private NetworkServer _currentServer;
		public NetworkServer PriorityServer => _currentServer;

		public bool SyncProgressForEditor;

		[Tooltip("Test certain remote data in Editor (when SyncProgressForEditor enabled)")]
		public string ForceSocialId;

		public NetworkPath GetNetworkPath()
		{
			return networks.First(); //(x => x.server == Contexts.CurrentServer);
		}

		public string GetRestApiUri()
		{
			var path = GetNetworkPath();
			return $"{path.protocol.ToUriString()}{path.uri}";
		}

		public bool TryGetNetworkPathByEnv(NetworkServer server, out NetworkPath path)
		{
			path = new NetworkPath();

			foreach (var networkPath in networks)
			{
				if (networkPath.server == server)
				{
					path = networkPath;
					return true;
				}
			}

			return false;
		}

		public void SetNetwork(NetworkServer server)
		{
			_currentServer = server;
		}
	}
}