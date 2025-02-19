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
    public partial class PlayerPaged : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The count property</summary>
        public long? Count { get; set; }
        /// <summary>The items property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::AEBestGatePath.API.Client.Models.Player>? Items { get; set; }
#nullable restore
#else
        public List<global::AEBestGatePath.API.Client.Models.Player> Items { get; set; }
#endif
        /// <summary>The lastScannedKey property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::AEBestGatePath.API.Client.Models.PlayerPaged_lastScannedKey? LastScannedKey { get; set; }
#nullable restore
#else
        public global::AEBestGatePath.API.Client.Models.PlayerPaged_lastScannedKey LastScannedKey { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Models.PlayerPaged"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.API.Client.Models.PlayerPaged CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.API.Client.Models.PlayerPaged();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "count", n => { Count = n.GetLongValue(); } },
                { "items", n => { Items = n.GetCollectionOfObjectValues<global::AEBestGatePath.API.Client.Models.Player>(global::AEBestGatePath.API.Client.Models.Player.CreateFromDiscriminatorValue)?.AsList(); } },
                { "lastScannedKey", n => { LastScannedKey = n.GetObjectValue<global::AEBestGatePath.API.Client.Models.PlayerPaged_lastScannedKey>(global::AEBestGatePath.API.Client.Models.PlayerPaged_lastScannedKey.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteLongValue("count", Count);
            writer.WriteCollectionOfObjectValues<global::AEBestGatePath.API.Client.Models.Player>("items", Items);
            writer.WriteObjectValue<global::AEBestGatePath.API.Client.Models.PlayerPaged_lastScannedKey>("lastScannedKey", LastScannedKey);
        }
    }
}
#pragma warning restore CS0618
