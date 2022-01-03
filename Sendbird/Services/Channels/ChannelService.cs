using Sendbird.Core;
using Sendbird.Entities;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Services.Channels
{
    public class ChannelService : Service<ChannelBase>
    {
        const string OPEN_CHANNEL_PATH = "open_channels";
        const string GROUP_CHANNEL_PATH = "group_channels";

        public ChannelService() : base(null)
        {
        }

        public ChannelService(IClient client) : base(client)
        {
        }

        public override string BasePath => null;

        #region OpenChannel
        public virtual OpenChannel Create(OpenChannelCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<OpenChannel>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}", options, requestOptions);
        }

        public virtual Task<OpenChannel> CreateAsync(OpenChannelCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<OpenChannel>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}", options, requestOptions, cancellationToken);
        }

        public virtual OpenChannel Update(string channelUrl, OpenChannelUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<OpenChannel>(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<OpenChannel> UpdateAsync(string channelUrl, OpenChannelUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<OpenChannel>(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual OpenChannel Delete(string channelUrl, OpenChannelDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<OpenChannel>(HttpMethod.Delete, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<OpenChannel> DeleteAsync(string channelUrl, OpenChannelDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<OpenChannel>(HttpMethod.Delete, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual OpenChannel Get(string channelUrl, OpenChannelGetOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<OpenChannel>(HttpMethod.Get, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<OpenChannel> GetAsync(string channelUrl, OpenChannelGetOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<OpenChannel>(HttpMethod.Get, $"/{OPEN_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual OpenChannelList List(OpenChannelListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<OpenChannelList>(HttpMethod.Get, $"/{OPEN_CHANNEL_PATH}", options, requestOptions);
        }

        public virtual Task<OpenChannelList> ListAsync(OpenChannelListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<OpenChannelList>(HttpMethod.Get, $"/{OPEN_CHANNEL_PATH}", options, requestOptions, cancellationToken);
        }
        #endregion

        #region GroupChannel
        public virtual GroupChannel Create(GroupChannelCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}", options, requestOptions);
        }

        public virtual Task<GroupChannel> CreateAsync(GroupChannelCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannel Update(string channelUrl, GroupChannelUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<GroupChannel> UpdateAsync(string channelUrl, GroupChannelUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannel Delete(string channelUrl, GroupChannelDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Delete, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<GroupChannel> DeleteAsync(string channelUrl, GroupChannelDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Delete, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannel Get(string channelUrl, GroupChannelGetOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Get, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions);
        }

        public virtual Task<GroupChannel> GetAsync(string channelUrl, GroupChannelGetOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Get, $"/{GROUP_CHANNEL_PATH}/{channelUrl}", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannelList List(GroupChannelListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannelList>(HttpMethod.Get, $"/{GROUP_CHANNEL_PATH}", options, requestOptions);
        }

        public virtual Task<GroupChannelList> ListAsync(GroupChannelListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannelList>(HttpMethod.Get, $"/{GROUP_CHANNEL_PATH}", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannel Invite(string channelUrl, GroupChannelInviteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channelUrl}/invite", options, requestOptions);
        }

        public virtual Task<GroupChannel> InviteAsync(string channelUrl, GroupChannelInviteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channelUrl}/invite", options, requestOptions, cancellationToken);
        }

        public virtual GroupChannel Leave(string channelUrl, GroupChannelLeaveOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<GroupChannel>(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channelUrl}/leave", options, requestOptions);
        }

        public virtual Task<GroupChannel> LeaveAsync(string channelUrl, GroupChannelLeaveOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<GroupChannel>(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channelUrl}/leave", options, requestOptions, cancellationToken);
        }
        #endregion
    }
}
