namespace NetworkService.Authentication.Credentials
{
	public class AppleCredential : AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Apple;

		public readonly string AppleToken;

		public AppleCredential(string appleToken)
		{
			AppleToken = appleToken;
		}
	}
}