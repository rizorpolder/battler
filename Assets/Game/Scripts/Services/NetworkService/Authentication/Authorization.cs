using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NetworkService.Authentication.Credentials;
using UnityEngine;

namespace NetworkService.Authentication
{
	public abstract class Authorization
	{
		private const string TokenKey = "auth_token";
		private const string CredentialKey = "credential";

		private const int ReTryAuthTimeOut = 1000; // in mc

		private bool _needSyncData = false;

		private async UniTask StartLoadUser(bool needSyncData = true)
		{
			await LoadUser();
		}

		private async UniTask LoadUser(CancellationTokenSource token = null)
		{
			var credential = await GetAuthCredential();
			if (credential == null)
				return;

			if (PlayerPrefs.HasKey(CredentialKey))
			{
				var savedCredential = PlayerPrefs.GetString(CredentialKey);
				if (credential.GetActualString() != savedCredential) //other device
				{
					PlayerPrefs.DeleteKey(TokenKey);
				}
			}

			//есть токен, авторизация по нему
			if (PlayerPrefs.HasKey(TokenKey))
			{
				var authToken = PlayerPrefs.GetString(TokenKey);
				var userData = await Auth(authToken); //todo UnitWebRequest
				token?.Token.ThrowIfCancellationRequested();

				if (userData == null)
				{
					ResetToken();
					await LoadUser();
				}
				else
				{
					await OnSuccessAuth();
				}
			}
			else
			{
				var authToken = await Login(credential);
				token?.Token.ThrowIfCancellationRequested();
				if (string.IsNullOrEmpty(authToken))
				{
					await TryAgainLoadUser();
				}
				else
				{
					PlayerPrefs.SetString(TokenKey, authToken);
					PlayerPrefs.SetString(CredentialKey, credential.GetActualString());
					await LoadUser();
				}
			}
		}

		private async UniTask TryAgainLoadUser()
		{
			await UniTask.Delay(ReTryAuthTimeOut);

			var loadUserToken = new CancellationTokenSource();
			loadUserToken.CancelAfter(TimeSpan.FromMilliseconds(10000));
			var loadUserTask = LoadUser(loadUserToken);
			await UniTask.WhenAny(loadUserTask, UniTask.Delay(10000));
		}

		private void ResetToken()
		{
			//AuthToken = string.Empty;
			PlayerPrefs.DeleteKey(TokenKey);
			PlayerPrefs.DeleteKey(CredentialKey);
		}

		private async UniTask<AuthCredential> GetAuthCredential()
		{
			//difference between device logic

			var credential = new DeviceCredential();
			return credential;
		}

		private async UniTask OnSuccessAuth()
		{
			Debug.Log($"On Success Auth - user is loaded");
			//TODO синхронизировать локальные и серверные данные
		}

		protected async UniTask<string> Auth(string authToken) //возвращает user data
		{
			//return restApiClient.Auth(token);
			return null;
		}

		protected async UniTask<string> Login(AuthCredential credential)
		{
			//return await restApiClient.Login(crdential)

			return null;
		}
	}
}