using Sendbird.Entities;
using Sendbird.Enums;
using Sendbird.Services.Channels;
using Sendbird.Services.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SendbirdTests
{
    public class FeaturesTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public FeaturesTests(
            ITestOutputHelper output
            )
        {
            _output = output;
        }

        [Fact]
        public async Task GetAllMessagesTest()
        {
            await foreach (var channel in GetAllChannels())
            {
                _output.WriteLine($"# {channel.Name}");

                var messages = await GetChannelMessages(channel);
                foreach (var message in messages)
                {
                    _output.WriteLine($"- {message.User.Nickname,-10} {message.Message} ({message.CreatedAt})");
                }
            }
        }

        private async IAsyncEnumerable<GroupChannel> GetAllChannels()
        {
            var service = new ChannelService();
            var token = string.Empty;
            var hasNext = true;
            while (hasNext)
            {
                var result = await service.ListAsync(new GroupChannelListOptions { Token = token });
                foreach (var channel in result.Channels)
                    yield return channel;

                token = result.Next;
                hasNext = !string.IsNullOrEmpty(result.Next);
            }
        }

        private async Task<IList<TextMessage>> GetChannelMessages(GroupChannel channel)
        {
            var service = new MessageService();
            var result = await service.ListAsync(channel, new MessageListOptions { CreatedBefore = DateTime.Now, MessageType = MessageType.Message });

            return result.Messages;
        }
    }
}
