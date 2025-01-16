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
    public partial class Player2 : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The gameId property</summary>
        public int? GameId { get; set; }
        /// <summary>The gates property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::AEBestGatePath.API.Client.Models.Gate>? Gates { get; set; }
#nullable restore
#else
        public List<global::AEBestGatePath.API.Client.Models.Gate> Gates { get; set; }
#endif
        /// <summary>The guild property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::AEBestGatePath.API.Client.Models.Guild2? Guild { get; set; }
#nullable restore
#else
        public global::AEBestGatePath.API.Client.Models.Guild2 Guild { get; set; }
#endif
        /// <summary>The guildId property</summary>
        public Guid? GuildId { get; set; }
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
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.API.Client.Models.Player2"/> and sets the default values.
        /// </summary>
        public Player2()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.API.Client.Models.Player2"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.API.Client.Models.Player2 CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.API.Client.Models.Player2();
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
                { "gates", n => { Gates = n.GetCollectionOfObjectValues<global::AEBestGatePath.API.Client.Models.Gate>(global::AEBestGatePath.API.Client.Models.Gate.CreateFromDiscriminatorValue)?.AsList(); } },
                { "guild", n => { Guild = n.GetObjectValue<global::AEBestGatePath.API.Client.Models.Guild2>(global::AEBestGatePath.API.Client.Models.Guild2.CreateFromDiscriminatorValue); } },
                { "guildId", n => { GuildId = n.GetGuidValue(); } },
                { "id", n => { Id = n.GetGuidValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
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
            writer.WriteCollectionOfObjectValues<global::AEBestGatePath.API.Client.Models.Gate>("gates", Gates);
            writer.WriteObjectValue<global::AEBestGatePath.API.Client.Models.Guild2>("guild", Guild);
            writer.WriteGuidValue("guildId", GuildId);
            writer.WriteGuidValue("id", Id);
            writer.WriteStringValue("name", Name);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
