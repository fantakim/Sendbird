using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Core
{
    public interface IHttpClient
    {
        Task<SendbirdResponse> MakeRequestAsync(
          SendbirdRequest request,
          CancellationToken cancellationToken = default(CancellationToken)
            );
    }
}
