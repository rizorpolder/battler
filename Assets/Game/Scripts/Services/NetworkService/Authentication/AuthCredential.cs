using NetworkService.Authentication.Credentials;
using UnityEngine;

namespace NetworkService.Authentication
{
	public enum AuthCredentialType
	{
		Facebook,
		Apple,
		Device,
		Yandex,
		Ok,
		Vk,
	}

	public abstract class AuthCredential
	{
		public abstract AuthCredentialType Type { get; }

		public LoginCredentialData GetLoginCredential()
		{
			var loginCredential = new LoginCredentialData();

			switch (Type)
			{
				case AuthCredentialType.Apple:
					if (this is AppleCredential appleCredential)
					{
						loginCredential.AppleToken = appleCredential.AppleToken;
					}

					break;
				case AuthCredentialType.Facebook:
					if (this is FacebookCredential facebookCredential)
					{
						loginCredential.FacebookToken = facebookCredential.AccessToken;
					}

					break;
				case AuthCredentialType.Yandex:
					if (this is YandexCredential yandexCredential)
					{
						loginCredential.YandexSignature = yandexCredential.Signature;
					}

					break;
				case AuthCredentialType.Ok:
					if (this is OkCredential okCredential)
					{
						loginCredential.OkPlayerId = okCredential.PlayerId;
					}

					break;
				case AuthCredentialType.Vk:
					if (this is VkCredential vkCredential)
					{
						loginCredential.VkPlayerId = vkCredential.PlayerId;
					}

					break;
				default:
					loginCredential.DeviceId = SystemInfo.deviceUniqueIdentifier;
					break;
			}

			return loginCredential;
		}

		

		public string GetActualString()
		{
			switch (Type)
			{
				case AuthCredentialType.Apple:
					if (this is AppleCredential appleCredential)
					{
						return appleCredential.AppleToken;
					}

					break;
				case AuthCredentialType.Facebook:
					if (this is FacebookCredential facebookCredential)
					{
						return facebookCredential.AccessToken;
					}

					break;
				case AuthCredentialType.Yandex:
					if (this is YandexCredential yandexCredential)
					{
						return yandexCredential.Signature;
					}

					break;
				case AuthCredentialType.Ok:
					if (this is OkCredential okCredential)
					{
						return okCredential.PlayerId;
					}

					break;
				case AuthCredentialType.Vk:
					if (this is VkCredential vkCredential)
					{
						return vkCredential.PlayerId;
					}

					break;
				default:
					return SystemInfo.deviceUniqueIdentifier;
			}

			return "";
		}
	}
}