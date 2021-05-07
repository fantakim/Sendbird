using Sendbird.Core;
using Sendbird.Entities;
using Sendbird.Services.Channels;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Services.Users
{
    public class UserService : Service<User>
    {
        public UserService() : base(null)
        {
        }

        public UserService(IClient client) : base(client)
        {
        }

        public override string BasePath => "/users";

        public virtual User Create(UserCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }
        public virtual Task<User> CreateAsync(UserCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual User Update(string userId, UserUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(userId, options, requestOptions);
        }

        public virtual Task<User> UpdateAsync(string userId, UserUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.UpdateEntityAsync(userId, options, requestOptions, cancellationToken);
        }

        public virtual User Delete(string userId, UserDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(userId, options, requestOptions);
        }

        public virtual Task<User> DeleteAsync(string userId, UserDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.DeleteEntityAsync(userId, options, requestOptions, cancellationToken);
        }

        public virtual User Get(string userId, UserGetOptions options, RequestOptions requestOptions = null)
        {
            return this.GetEntity(userId, options, requestOptions);
        }

        public virtual Task<User> GetAsync(string userId, UserGetOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(userId, options, requestOptions, cancellationToken);
        }

        public virtual UserList List(UserListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<UserList>(HttpMethod.Get, BasePath, options, requestOptions);
        }

        public virtual Task<UserList> ListAsync(UserListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<UserList>(HttpMethod.Get, BasePath, options, requestOptions, cancellationToken);
        }

        public virtual GroupChannelList MyGroupChannels(string userId, UserGroupChannelListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannelList>(HttpMethod.Get, $"{this.InstanceUrl(userId)}/my_group_channels", options, requestOptions);
        }

        public virtual Task<GroupChannelList> MyGroupChannelsAsync(string userId, UserGroupChannelListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannelList>(HttpMethod.Get, $"{this.InstanceUrl(userId)}/my_group_channels", options, requestOptions, cancellationToken);
        }

        public virtual PushPreference GetPushPreference(string userId, RequestOptions requestOptions = null)
        {
            return this.Request<PushPreference>(HttpMethod.Get, $"{this.InstanceUrl(userId)}/push_preference", null, requestOptions);
        }

        public virtual Task<PushPreference> GetPushPreferenceAsync(string userId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<PushPreference>(HttpMethod.Get, $"{this.InstanceUrl(userId)}/push_preference", null, requestOptions, cancellationToken);
        }
    }
}
