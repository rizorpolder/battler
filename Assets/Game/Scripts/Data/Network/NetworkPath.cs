using System;
using Game.Scripts.Enums.Network;

namespace Game.Scripts.Configs
{
	[Serializable]
	public struct NetworkPath
	{
		public NetworkServer server;
		public string adminUri;
		public NetworkProtocol protocol;
		public string uri;
	}
}