using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sendbird.Core
{
    public abstract class Service<TEntityReturned> where TEntityReturned : IEntity
    {
        private IClient client;

        protected Service()
        {
        }

        protected Service(IClient client)
        {
            this.client = client;
        }

        public abstract string BasePath { get; }

        public virtual string BaseUrl => this.Client.ApiBase;

        public IClient Client
        {
            get => this.client ?? SendbirdConfiguration.Client;
            set => this.client = value;
        }

        protected TEntityReturned CreateEntity(BaseOptions options, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Post, this.ClassUrl(), options, requestOptions);
        }

        protected Task<TEntityReturned> CreateEntityAsync(BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Post, this.ClassUrl(), options, requestOptions, cancellationToken);
        }

        protected TEntityReturned UpdateEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Put, this.InstanceUrl(id), options, requestOptions);
        }

        protected Task<TEntityReturned> UpdateEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Put, this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected TEntityReturned DeleteEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Delete, this.InstanceUrl(id), options, requestOptions);
        }

        protected Task<TEntityReturned> DeleteEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Delete, this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected TEntityReturned GetEntity(string id, BaseOptions options, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Get, this.InstanceUrl(id), options, requestOptions);
        }

        protected Task<TEntityReturned> GetEntityAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Get, this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected TEntityReturned Request(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions)
        {
            return this.Request<TEntityReturned>(method, path, options, requestOptions);
        }

        protected Task<TEntityReturned> RequestAsync(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<TEntityReturned>(method, path, options, requestOptions, cancellationToken);
        }

        protected T Request<T>(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions)
            where T : IEntity
        {
            return this.RequestAsync<T>(method, path, options, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> RequestAsync<T>(HttpMethod method, string path, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken = default)
            where T : IEntity
        {
            requestOptions = this.SetupRequestOptions(requestOptions);
            return await this.Client.RequestAsync<T>(method, path, options, requestOptions, cancellationToken)
                .ConfigureAwait(false);
        }

        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            requestOptions.BaseUrl = requestOptions.BaseUrl ?? this.BaseUrl;

            return requestOptions;
        }

        protected virtual string ClassUrl()
        {
            return this.BasePath;
        }

        protected virtual string ClassUrl(string parentId)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                throw new ArgumentException(
                    "The parent resource Id cannot be null or whitespace.",
                    nameof(parentId));
            }

            return this.BasePath.Replace("{PARENT_ID}", parentId);
        }

        protected virtual string InstanceUrl(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("The resource Id cannot be null or whitespace.", nameof(id));
            }

            return $"{this.ClassUrl()}/{WebUtility.UrlEncode(id)}";
        }

        protected virtual string InstanceUrl(string parentId, string id)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                throw new ArgumentException("The parent resource ParentId cannot be null or whitespace.", nameof(parentId));
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("The resource Id cannot be null or whitespace.", nameof(id));
            }

            return $"{this.ClassUrl(parentId)}/{WebUtility.UrlEncode(id)}";
        }
    }
}
