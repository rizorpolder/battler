namespace NetworkService.Authentication.Credentials
{
	public class OkCredential : AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Ok;
        
		public readonly string PlayerId;

		public OkCredential(string playerId)
		{
			PlayerId = playerId;
		}
	}
}