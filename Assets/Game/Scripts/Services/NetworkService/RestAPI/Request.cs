using Cysharp.Threading.Tasks;
using Game.Scripts.Configs;
using VContainer;

namespace Game.Scripts.Services.NetworkService.RestAPI
{
	public abstract class Request<TResponseData>
	{
		[Inject]
		NetworkConfig _networkConfig;

		protected string Uri => $"{_networkConfig.GetRestApiUri()}";

		protected abstract string RelativePath { get; }

		protected string FullUri => $"{Uri}{RelativePath}";

		public abstract UniTask<Response<TResponseData>> Make();
	}
}