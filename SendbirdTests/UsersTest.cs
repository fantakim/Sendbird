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
using FluentAssertions;

namespace SendbirdTests
{
    public class UsersTest : BaseTest
    {
        private readonly UserService _userService;
        private readonly ITestOutputHelper _output;

        public UsersTest(ITestOutputHelper output)
        {
            _userService = new UserService(this.TestClient);
            _output = output;
        }

        [Fact]
        public async Task Users_Create()
        {
            // Act
            var user = await _userService.CreateAsync(new UserCreateOptions
            {
                Id = $"test-user-{Guid.NewGuid()}",
                Nickname = $"nickname-{Guid.NewGuid()}"
            });

            // Assert
            user.Should().NotBeNull();
        }

        [Fact]
        public async Task Users_List()
        {
            // Act
            var users = await _userService.ListAsync();

            // Assert
            users.Should().NotBeNull();
        }

        [Fact]
        public async Task Users_Delete()
        {
            // Arrange
            var userId = $"test-user-{Guid.NewGuid()}";

            // Act
            var user = await _userService.CreateAsync(new UserCreateOptions
            {
                Id = userId,
                Nickname = $"nickname-{Guid.NewGuid()}"
            });
            var deletedUser = await _userService.DeleteAsync(userId);

            // Assert
            deletedUser.Should().NotBeNull();
        }
    }
}
