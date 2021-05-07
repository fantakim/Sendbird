using Microsoft.Extensions.Configuration;
using Sendbird;
using Sendbird.Core;
using Xunit;

namespace SendbirdTests
{
    [Collection("Sendbird tests")]
    public class BaseTest
    {
        public BaseTest()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<BaseTest>();

            var config = builder.Build();

            SendbirdConfiguration.SetAppId(config["SendbirdConfiguration:AppId"]);
            SendbirdConfiguration.SetApiToken(config["SendbirdConfiguration:ApiToken"]);

            this.TestClient = SendbirdConfiguration.Client;
        }

        protected IClient TestClient { get; }
    }
}
