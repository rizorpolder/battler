namespace NetworkService.Authentication.Credentials
{
	public class VkCredential : AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Vk;

		public readonly string PlayerId;

		public VkCredential(string playerId)
		{
			PlayerId = playerId;
		}
	}
}