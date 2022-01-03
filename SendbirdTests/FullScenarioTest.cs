using Sendbird.Enums;
using Sendbird.Services.Channels;
using Sendbird.Services.Messages;
using Sendbird.Services.Users;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SendbirdTests
{
    public class FullScenarioTest : BaseTest
    {
        private readonly UserService _userService;
        private readonly ChannelService _channelService;
        private readonly MessageService _messageService;
        private readonly ITestOutputHelper _output;

        public FullScenarioTest(
            ITestOutputHelper output
            )
        {
            _userService = new UserService(this.TestClient);
            _channelService = new ChannelService(this.TestClient);
            _messageService = new MessageService(this.TestClient);
            _output = output;
        }

        [Fact]
        public async Task Run_full_scenarios()
        {
            // Create users.
            var user1 = await CreateTestUserAsync("TEST-Fanta");
            var user2 = await CreateTestUserAsync("TEST-Coke");
            var user3 = await CreateTestUserAsync("TEST-Qoo");

            _output.WriteLine("Create users.");

            // Create channel.
            var channel = await _channelService.CreateAsync(new GroupChannelCreateOptions { 
                Name = "TEST-ROOM", 
                InviterId = user1,
                UserIds = new[] { user1 },
                OperatorIds = new[] { user1 } 
            });

            _output.WriteLine("Create channel.");

            // Invite users.
            channel = await _channelService.InviteAsync(channel.ChannelUrl, new GroupChannelInviteOptions
            {
                UserIds = new[] { user2, user3 }
            });

            _output.WriteLine("Invite users.");

            // Delete channel.
            channel = await _channelService.DeleteAsync(channel.ChannelUrl, new GroupChannelDeleteOptions());
            Assert.Null(channel.ChannelUrl);

            _output.WriteLine("Delete channel.");

            // Clean.
            await DeleteTestUserAsync(user1);
            await DeleteTestUserAsync(user2);
            await DeleteTestUserAsync(user3);

            _output.WriteLine("Clean.");
        }

        [Fact]
        public async Task Get_my_group_channel_test()
        {
            // Create users.
            var me = await CreateTestUserAsync("TEST-Fanta");
            var friend1 = await CreateTestUserAsync("TEST-Coke");
            var friend2 = await CreateTestUserAsync("TEST-Qoo");

            // Create channels.
            var channel1 = await CreateTestChannelAsync(me);
            var channel2 = await CreateTestChannelAsync(me);
            var channel3 = await CreateTestChannelAsync(me);

            // Get my channel list
            var channelList = await _userService.MyGroupChannelsAsync(me, new UserGroupChannelListOptions { Order = OrderMode.Chronological });

            // Invite friends.
            await _channelService.InviteAsync(channel1, new GroupChannelInviteOptions { UserIds = new[] { friend1, friend2 } });

            // Send message from channel2
            await _messageService.SendMessageAsync("group_channels", channel2, new AdminMessageOptions { Message = "hello" });

            // Get channel list
            channelList = await _userService.MyGroupChannelsAsync(me, new UserGroupChannelListOptions { Order = OrderMode.LatestLastMessage });
            
            // Get first channel
            var firstChannel = channelList.Channels.FirstOrDefault();
            
            // Compare fist channel.
            Assert.Equal(channel2, firstChannel.ChannelUrl);

            // Clean.
            await DeleteTestChannelAsync(channel1);
            await DeleteTestChannelAsync(channel2);
            await DeleteTestChannelAsync(channel3);
            await DeleteTestUserAsync(me);
            await DeleteTestUserAsync(friend1);
            await DeleteTestUserAsync(friend2);
        }

        [Fact]
        public async Task Invite_and_leave_the_channel_test()
        {
            var me = await CreateTestUserAsync("TEST-Fanta");
            var friend1 = await CreateTestUserAsync("TEST-Coke");
            var friend2 = await CreateTestUserAsync("TEST-Qoo");

            // Create channel.
            var channelUrl = await CreateTestChannelAsync(me);

            // Invite friends.
            var groupChannel = await _channelService.InviteAsync(channelUrl, new GroupChannelInviteOptions { UserIds = new[] { friend1, friend2 } });

            Assert.Equal(3, groupChannel.MemberCount);

            // Leave friend.
            groupChannel = await _channelService.LeaveAsync(channelUrl, new GroupChannelLeaveOptions { UserIds = new[] { friend2 } });

            // Get channel.
            groupChannel = await _channelService.GetAsync(channelUrl, new GroupChannelGetOptions { ShowMember = true });

            Assert.Equal(2, groupChannel.MemberCount);

            // Clean.
            await DeleteTestChannelAsync(channelUrl);
            await DeleteTestUserAsync(me);
            await DeleteTestUserAsync(friend1);
            await DeleteTestUserAsync(friend2);
        }

        private async Task<string> CreateTestUserAsync(string nickname)
        {
            string id = $"TEST-{Guid.NewGuid()}";
            var user = await _userService.CreateAsync(new UserCreateOptions { Id = id, Nickname = nickname });

            return user.Id;
        }

        private async Task DeleteTestUserAsync(string userId)
        {
            await _userService.DeleteAsync(userId);
        }

        private async Task<string> CreateTestChannelAsync(string creator)
        {
            string name = $"TEST-Channel-{Guid.NewGuid()}";
            var channel = await _channelService.CreateAsync(new GroupChannelCreateOptions { Name = name, InviterId = creator, UserIds = new[] { creator }, OperatorIds = new[] { creator } });
            await _messageService.SendMessageAsync(channel, new AdminMessageOptions { Message = "welcome.." });

            return channel.ChannelUrl;
        }

        private async Task DeleteTestChannelAsync(string channelUrl)
        {
            await _channelService.DeleteAsync(channelUrl, new GroupChannelDeleteOptions { });
        }
    }
}
