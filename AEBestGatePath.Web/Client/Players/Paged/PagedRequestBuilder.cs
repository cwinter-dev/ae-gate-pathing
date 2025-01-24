// <auto-generated/>
#pragma warning disable CS0618
using AEBestGatePath.API.Client.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace AEBestGatePath.API.Client.Players.Paged
{
    /// <summary>
    /// Builds and executes requests for operations under \players\paged
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class PagedRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PagedRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/players/paged{?asc*,guild*,itemsPerPage*,page*,search*,sort*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public PagedRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/players/paged{?asc*,guild*,itemsPerPage*,page*,search*,sort*}", rawUrl)
        {
        }
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Models.PlayerPaged"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::AEBestGatePath.API.Client.Models.PlayerPaged?> GetAsync(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder.PagedRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::AEBestGatePath.API.Client.Models.PlayerPaged> GetAsync(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder.PagedRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::AEBestGatePath.API.Client.Models.PlayerPaged>(requestInfo, global::AEBestGatePath.API.Client.Models.PlayerPaged.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder.PagedRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder.PagedRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder WithUrl(string rawUrl)
        {
            return new global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder(rawUrl, RequestAdapter);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        #pragma warning disable CS1591
        public partial class PagedRequestBuilderGetQueryParameters 
        #pragma warning restore CS1591
        {
            [QueryParameter("asc")]
            public bool? Asc { get; set; }
            [QueryParameter("guild")]
            public Guid? Guild { get; set; }
            [QueryParameter("itemsPerPage")]
            public int? ItemsPerPage { get; set; }
            [QueryParameter("page")]
            public int? Page { get; set; }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("search")]
            public string? Search { get; set; }
#nullable restore
#else
            [QueryParameter("search")]
            public string Search { get; set; }
#endif
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("sort")]
            public string? Sort { get; set; }
#nullable restore
#else
            [QueryParameter("sort")]
            public string Sort { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class PagedRequestBuilderGetRequestConfiguration : RequestConfiguration<global::AEBestGatePath.API.Client.Players.Paged.PagedRequestBuilder.PagedRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
