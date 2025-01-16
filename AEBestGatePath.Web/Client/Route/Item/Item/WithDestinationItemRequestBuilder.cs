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
namespace AEBestGatePath.API.Client.Route.Item.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \route\{origin}\{destination}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WithDestinationItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithDestinationItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route/{origin}/{destination}{?commanderLevel*,gameVersion*,gateLevel*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithDestinationItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route/{origin}/{destination}{?commanderLevel*,gameVersion*,gateLevel*}", rawUrl)
        {
        }
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Models.Stop"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::AEBestGatePath.API.Client.Models.Stop?> GetAsync(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder.WithDestinationItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::AEBestGatePath.API.Client.Models.Stop> GetAsync(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder.WithDestinationItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::AEBestGatePath.API.Client.Models.Stop>(requestInfo, global::AEBestGatePath.API.Client.Models.Stop.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder.WithDestinationItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder.WithDestinationItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder(rawUrl, RequestAdapter);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        #pragma warning disable CS1591
        public partial class WithDestinationItemRequestBuilderGetQueryParameters 
        #pragma warning restore CS1591
        {
            [QueryParameter("commanderLevel")]
            public int? CommanderLevel { get; set; }
            [QueryParameter("gameVersion")]
            public double? GameVersion { get; set; }
            [QueryParameter("gateLevel")]
            public int? GateLevel { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WithDestinationItemRequestBuilderGetRequestConfiguration : RequestConfiguration<global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder.WithDestinationItemRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
