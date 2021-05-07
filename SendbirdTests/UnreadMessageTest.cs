using Sendbird.Entities;
using Sendbird.Enums;
using Sendbird.Services.Channels;
using Sendbird.Services.Messages;
using Sendbird.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SendbirdTests
{
    public class UnreadMessageTest : BaseTest
    {
        private readonly UserService _userService;
        private readonly ChannelService _channelService;
        private readonly MessageService _messageService;
        private readonly ITestOutputHelper _output;

        public UnreadMessageTest(
            ITestOutputHelper output
            )
        {
            _userService = new UserService(this.TestClient);
            _channelService = new ChannelService(this.TestClient);
            _messageService = new MessageService(this.TestClient);
            _output = output;
        }

        [Fact]
        public async Task UnreadMessageUpdate()
        {
            await foreach (var user in GetAllActiveUsersAsync())
            {
                _output.WriteLine($"[{user.Id}] {user.Nickname}");

                await foreach (var channel in GetAllGroupChannelsAsync(user.Id))
                {
                    var message = channel.LastMessage;
                    var nickname = message.User?.Nickname ?? "Admin";
                    var comment = message.Message;
                    var created = message.CreatedAt;

                    _output.WriteLine($"[{created}] {nickname,-20}: {comment}");

                    var requiredToNotify = (message.Type == MessageType.Message) && (created < DateTime.UtcNow.AddHours(-4)) && (message.Data != "notified");
                    if (requiredToNotify)
                    {
                        await _messageService.UpdateMessageAsync(channel, message, new MessageUpdateOptions { Data = "notified" });
                    }
                }
            }

            _output.WriteLine("finished");
        }

        private async IAsyncEnumerable<User> GetAllActiveUsersAsync()
        {
            var token = string.Empty;
            var hasNext = true;
            while (hasNext)
            {
                var result = await _userService.ListAsync(new UserListOptions { Token = token, ActiveMode = ActiveMode.Activated });
                foreach (var user in result.Users)
                    yield return user;

                token = result.Next;
                hasNext = !string.IsNullOrEmpty(result.Next);
            }
        }

        private async IAsyncEnumerable<GroupChannel> GetAllGroupChannelsAsync(string userId)
        {
            var token = string.Empty;
            var hasNext = true;
            while (hasNext)
            {
                var result = await _userService.MyGroupChannelsAsync(userId, new UserGroupChannelListOptions { Token = token, UnreadFilter = UnreadFilter.UnreadMessage });
                foreach (var channel in result.Channels)
                    yield return channel;

                token = result.Next;
                hasNext = !string.IsNullOrEmpty(result.Next);
            }
        }
    }
}
