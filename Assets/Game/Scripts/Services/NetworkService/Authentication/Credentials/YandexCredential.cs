namespace NetworkService.Authentication.Credentials
{
	public class YandexCredential:AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Yandex;

		public readonly string Signature;

		public YandexCredential(string signature)
		{
			Signature = signature;
		}
	}
}