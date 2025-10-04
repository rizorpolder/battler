namespace NetworkService.Authentication.Credentials
{
	public class FacebookCredential : AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Facebook;

		public readonly string AccessToken;

		public FacebookCredential(string accessToken)
		{
			AccessToken = accessToken;
		}
	}
}