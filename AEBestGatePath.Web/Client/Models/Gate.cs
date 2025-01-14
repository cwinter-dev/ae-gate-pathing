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
    public partial class Gate : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The astro property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::AEBestGatePath.Web.Client.Models.Astro? Astro { get; set; }
#nullable restore
#else
        public global::AEBestGatePath.Web.Client.Models.Astro Astro { get; set; }
#endif
        /// <summary>The id property</summary>
        public int? Id { get; set; }
        /// <summary>The lastUpdated property</summary>
        public DateTimeOffset? LastUpdated { get; set; }
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
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.Web.Client.Models.Gate"/> and sets the default values.
        /// </summary>
        public Gate()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.Web.Client.Models.Gate"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.Web.Client.Models.Gate CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.Web.Client.Models.Gate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "astro", n => { Astro = n.GetObjectValue<global::AEBestGatePath.Web.Client.Models.Astro>(global::AEBestGatePath.Web.Client.Models.Astro.CreateFromDiscriminatorValue); } },
                { "id", n => { Id = n.GetIntValue(); } },
                { "lastUpdated", n => { LastUpdated = n.GetDateTimeOffsetValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "occupied", n => { Occupied = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::AEBestGatePath.Web.Client.Models.Astro>("astro", Astro);
            writer.WriteIntValue("id", Id);
            writer.WriteDateTimeOffsetValue("lastUpdated", LastUpdated);
            writer.WriteStringValue("name", Name);
            writer.WriteBoolValue("occupied", Occupied);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618