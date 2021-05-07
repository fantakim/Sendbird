using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Core
{
    public interface IClient
    {
        string AppId { get; }

        string ApiToken { get; }

        string ApiVersion { get; }

        string ApiBase { get; }

        Task<T> RequestAsync<T>(
            HttpMethod method, 
            string path, 
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default(CancellationToken)
            ) where T : IEntity;
    }
}
