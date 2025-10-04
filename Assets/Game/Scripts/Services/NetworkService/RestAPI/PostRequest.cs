using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Scripts.Services.NetworkService.RestAPI
{
	public abstract class PostRequest <TResponseData> : Request<TResponseData>, IDisposable
	{
		private UnityWebRequest _request;

		public override async UniTask<Response<TResponseData>> Make()
		{
			_request = UnityWebRequest.Post(FullUri, GetForm());
			await _request.SendWebRequest();
			return ParseResponse(_request);
		}

		private Response<TResponseData> ParseResponse(UnityWebRequest request)
		{
			if (request.result != UnityWebRequest.Result.Success)
			{
				return Response<TResponseData>.Failed();
			}

			var data = ParseResponseData(request);
			return Response<TResponseData>.Success(data);
		}

		protected abstract WWWForm GetForm();

		protected abstract TResponseData ParseResponseData(UnityWebRequest request);

		public void Dispose()
		{
			_request?.Dispose();
		}
	}
}