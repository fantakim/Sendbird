using Sendbird.Entities;
using Sendbird.Enums;
using Sendbird.Services.Channels;
using Sendbird.Services.Messages;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task GetTextMessagesTest()
        {
            await foreach (var channel in GetAllChannels())
            {
                _output.WriteLine($"# {channel.Name}");

                var messages = await GetChannelMessages(channel, MessageType.Message);
                foreach (var message in messages)
                {
                    _output.WriteLine($"- {message.User?.Nickname, -10} {message.Message} ({message.CreatedAt})");
                }
            }
        }

        [Fact]
        public async Task GetMessageFileSaveTest()
        {
            await foreach (var channel in GetAllChannels())
            {
                _output.WriteLine($"# {channel.Name}");

                var messages = await GetChannelMessages(channel, MessageType.File);
                foreach (var message in messages)
                {
                    _output.WriteLine($"- {message.File.Name, -10} {message.File.Url} ({message.File.Size})");

                    // Save in my documents folder
                    var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    var filePath = Path.Combine(folder, message.File.Name);

                    message.File.SaveAs(filePath);
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

        private async Task<IList<TextMessage>> GetChannelMessages(GroupChannel channel, MessageType messageType)
        {
            var service = new MessageService();
            var result = await service.ListAsync(channel, new MessageListOptions { CreatedBefore = DateTime.Now, MessageType = messageType });

            return result.Messages;
        }
    }
}
