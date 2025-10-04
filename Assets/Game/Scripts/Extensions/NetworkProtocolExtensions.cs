using Game.Scripts.Enums.Network;

namespace Game.Scripts.Extensions
{
	public static class NetworkProtocolExtensions
	{
		public static string ToUriString(this NetworkProtocol protocol)
		{
			switch (protocol)
			{
				case NetworkProtocol.Https:
					return "https://";
				case NetworkProtocol.Http:
				default:
					return "http://";
			}
		}
	}
}