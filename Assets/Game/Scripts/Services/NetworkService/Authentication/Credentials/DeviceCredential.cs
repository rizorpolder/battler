namespace NetworkService.Authentication.Credentials
{
	public class DeviceCredential : AuthCredential
	{
		public override AuthCredentialType Type => AuthCredentialType.Device;
	}
}