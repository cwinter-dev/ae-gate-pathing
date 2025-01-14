// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace AEBestGatePath.Web.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class Guild3 : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The gameId property</summary>
        public int? GameId { get; set; }
        /// <summary>The id property</summary>
        public Guid? Id { get; set; }
        /// <summary>The name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The players property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::AEBestGatePath.Web.Client.Models.Gate3>? Players { get; set; }
#nullable restore
#else
        public List<global::AEBestGatePath.Web.Client.Models.Gate3> Players { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.Web.Client.Models.Guild3"/> and sets the default values.
        /// </summary>
        public Guild3()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.Web.Client.Models.Guild3"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.Web.Client.Models.Guild3 CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.Web.Client.Models.Guild3();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "gameId", n => { GameId = n.GetIntValue(); } },
                { "id", n => { Id = n.GetGuidValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "players", n => { Players = n.GetCollectionOfObjectValues<global::AEBestGatePath.Web.Client.Models.Gate3>(global::AEBestGatePath.Web.Client.Models.Gate3.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("gameId", GameId);
            writer.WriteGuidValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteCollectionOfObjectValues<global::AEBestGatePath.Web.Client.Models.Gate3>("players", Players);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
