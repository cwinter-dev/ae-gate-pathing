// <auto-generated/>
#pragma warning disable CS0618
using AEBestGatePath.Web.Client.Route.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace AEBestGatePath.Web.Client.Route
{
    /// <summary>
    /// Builds and executes requests for operations under \route
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class RouteRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the AEBestGatePath.Web.Client.route.item collection</summary>
        /// <param name="position">Unique identifier of the item</param>
        /// <returns>A <see cref="global::AEBestGatePath.Web.Client.Route.Item.WithOriginItemRequestBuilder"/></returns>
        public global::AEBestGatePath.Web.Client.Route.Item.WithOriginItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("origin", position);
                return new global::AEBestGatePath.Web.Client.Route.Item.WithOriginItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.Web.Client.Route.RouteRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RouteRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.Web.Client.Route.RouteRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public RouteRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/route", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618