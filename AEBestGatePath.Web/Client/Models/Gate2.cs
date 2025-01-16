// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace AEBestGatePath.API.Client.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class Gate2 : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The id property</summary>
        public Guid? Id { get; set; }
        /// <summary>The lastUpdated property</summary>
        public DateTimeOffset? LastUpdated { get; set; }
        /// <summary>The location property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::AEBestGatePath.API.Client.Models.Location? Location { get; set; }
#nullable restore
#else
        public global::AEBestGatePath.API.Client.Models.Location Location { get; set; }
#endif
        /// <summary>The name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The occupied property</summary>
        public bool? Occupied { get; set; }
        /// <summary>The player property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::AEBestGatePath.API.Client.Models.Player2? Player { get; set; }
#nullable restore
#else
        public global::AEBestGatePath.API.Client.Models.Player2 Player { get; set; }
#endif
        /// <summary>The playerId property</summary>
        public Guid? PlayerId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Models.Gate2"/> and sets the default values.
        /// </summary>
        public Gate2()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Models.Gate2"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.API.Client.Models.Gate2 CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.API.Client.Models.Gate2();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "id", n => { Id = n.GetGuidValue(); } },
                { "lastUpdated", n => { LastUpdated = n.GetDateTimeOffsetValue(); } },
                { "location", n => { Location = n.GetObjectValue<global::AEBestGatePath.API.Client.Models.Location>(global::AEBestGatePath.API.Client.Models.Location.CreateFromDiscriminatorValue); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "occupied", n => { Occupied = n.GetBoolValue(); } },
                { "player", n => { Player = n.GetObjectValue<global::AEBestGatePath.API.Client.Models.Player2>(global::AEBestGatePath.API.Client.Models.Player2.CreateFromDiscriminatorValue); } },
                { "playerId", n => { PlayerId = n.GetGuidValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteGuidValue("id", Id);
            writer.WriteDateTimeOffsetValue("lastUpdated", LastUpdated);
            writer.WriteObjectValue<global::AEBestGatePath.API.Client.Models.Location>("location", Location);
            writer.WriteStringValue("name", Name);
            writer.WriteBoolValue("occupied", Occupied);
            writer.WriteObjectValue<global::AEBestGatePath.API.Client.Models.Player2>("player", Player);
            writer.WriteGuidValue("playerId", PlayerId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
