// <auto-generated/>
#pragma warning disable CS0618
using AEBestGatePath.API.Client.Route.Item.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace AEBestGatePath.API.Client.Route.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \route\{origin}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WithOriginItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the AEBestGatePath.API.Client.route.item.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder"/></returns>
        public global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("destination", position);
                return new global::AEBestGatePath.API.Client.Route.Item.Item.WithDestinationItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Route.Item.WithOriginItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithOriginItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route/{origin}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Route.Item.WithOriginItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithOriginItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route/{origin}", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
