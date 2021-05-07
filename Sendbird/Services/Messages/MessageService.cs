using Sendbird.Core;
using Sendbird.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sendbird.Services.Messages
{
    public class MessageService : Service<MessageBase>
    {
        const string OPEN_CHANNEL_PATH = "open_channels";
        const string GROUP_CHANNEL_PATH = "group_channels";

        public MessageService() : base(null)
        {
        }

        public MessageService(IClient client) : base(client)
        {
        }

        public override string BasePath => null;

        #region TextMessage

        public virtual TextMessage SendMessage(OpenChannel channel, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<TextMessage>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual Task<TextMessage> SendMessageAsync(OpenChannel channel, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<TextMessage>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual TextMessage SendMessage(GroupChannel channel, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<TextMessage>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual Task<TextMessage> SendMessageAsync(GroupChannel channel, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<TextMessage>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual TextMessage SendMessage(string channelType, string channelUrl, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<TextMessage>(HttpMethod.Post, $"/{channelType}/{channelUrl}/messages", options, requestOptions);
        }

        public virtual Task<TextMessage> SendMessageAsync(string channelType, string channelUrl, TextMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<TextMessage>(HttpMethod.Post, $"/{channelType}/{channelUrl}/messages", options, requestOptions);
        }

        public virtual void UpdateMessage(OpenChannel channel, TextMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            this.Request(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual Task UpdateMessageAsync(OpenChannel channel, TextMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            return this.RequestAsync(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual void UpdateMessage(GroupChannel channel, TextMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            this.Request(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual Task UpdateMessageAsync(GroupChannel channel, TextMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            return this.RequestAsync(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        #endregion

        #region AdminMessage

        public virtual AdminMessage SendMessage(OpenChannel channel, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<AdminMessage>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual Task<AdminMessage> SendMessageAsync(OpenChannel channel, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<AdminMessage>(HttpMethod.Post, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual AdminMessage SendMessage(GroupChannel channel, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<AdminMessage>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual Task<AdminMessage> SendMessageAsync(GroupChannel channel, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<AdminMessage>(HttpMethod.Post, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages", options, requestOptions);
        }

        public virtual AdminMessage SendMessage(string channelType, string channelUrl, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<AdminMessage>(HttpMethod.Post, $"/{channelType}/{channelUrl}/messages", options, requestOptions);
        }

        public virtual Task<AdminMessage> SendMessageAsync(string channelType, string channelUrl, AdminMessageOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync<AdminMessage>(HttpMethod.Post, $"/{channelType}/{channelUrl}/messages", options, requestOptions);
        }

        public virtual void UpdateMessage(OpenChannel channel, AdminMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            this.Request(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual Task UpdateMessageAsync(OpenChannel channel, AdminMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            return this.RequestAsync(HttpMethod.Put, $"/{OPEN_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual void UpdateMessage(GroupChannel channel, AdminMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            this.Request(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        public virtual Task UpdateMessageAsync(GroupChannel channel, AdminMessage message, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            options.SetMessageType(message.Type);

            return this.RequestAsync(HttpMethod.Put, $"/{GROUP_CHANNEL_PATH}/{channel.ChannelUrl}/messages/{message.MessageId}", options, requestOptions);
        }

        #endregion

        public virtual void UpdateMessage(string channelType, string channelUrl, long messageId, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            this.Request(HttpMethod.Put, $"/{channelType}/{channelUrl}/messages/{messageId}", options, requestOptions);
        }

        public virtual Task UpdateMessageAsync(string channelType, string channelUrl, long messageId, MessageUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.RequestAsync(HttpMethod.Post, $"/{channelType}/{channelUrl}/messages/{messageId}", options, requestOptions);
        }
    }
}
