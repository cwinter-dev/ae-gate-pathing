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
    public partial class Astro : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The cluster property</summary>
        public int? Cluster { get; set; }
        /// <summary>The galaxy property</summary>
        public int? Galaxy { get; set; }
        /// <summary>The gateLevel property</summary>
        public int? GateLevel { get; set; }
        /// <summary>The locationX property</summary>
        public int? LocationX { get; set; }
        /// <summary>The locationY property</summary>
        public int? LocationY { get; set; }
        /// <summary>The logiCommander property</summary>
        public int? LogiCommander { get; set; }
        /// <summary>The regionX property</summary>
        public int? RegionX { get; set; }
        /// <summary>The regionY property</summary>
        public int? RegionY { get; set; }
        /// <summary>The ring property</summary>
        public int? Ring { get; set; }
        /// <summary>The ringPosition property</summary>
        public int? RingPosition { get; set; }
        /// <summary>The server property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Server { get; set; }
#nullable restore
#else
        public string Server { get; set; }
#endif
        /// <summary>The speed property</summary>
        public double? Speed { get; set; }
        /// <summary>The systemX property</summary>
        public int? SystemX { get; set; }
        /// <summary>The systemY property</summary>
        public int? SystemY { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::AEBestGatePath.Web.Client.Models.Astro"/> and sets the default values.
        /// </summary>
        public Astro()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::AEBestGatePath.Web.Client.Models.Astro"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::AEBestGatePath.Web.Client.Models.Astro CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::AEBestGatePath.Web.Client.Models.Astro();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "cluster", n => { Cluster = n.GetIntValue(); } },
                { "galaxy", n => { Galaxy = n.GetIntValue(); } },
                { "gateLevel", n => { GateLevel = n.GetIntValue(); } },
                { "locationX", n => { LocationX = n.GetIntValue(); } },
                { "locationY", n => { LocationY = n.GetIntValue(); } },
                { "logiCommander", n => { LogiCommander = n.GetIntValue(); } },
                { "regionX", n => { RegionX = n.GetIntValue(); } },
                { "regionY", n => { RegionY = n.GetIntValue(); } },
                { "ring", n => { Ring = n.GetIntValue(); } },
                { "ringPosition", n => { RingPosition = n.GetIntValue(); } },
                { "server", n => { Server = n.GetStringValue(); } },
                { "speed", n => { Speed = n.GetDoubleValue(); } },
                { "systemX", n => { SystemX = n.GetIntValue(); } },
                { "systemY", n => { SystemY = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("cluster", Cluster);
            writer.WriteIntValue("galaxy", Galaxy);
            writer.WriteIntValue("gateLevel", GateLevel);
            writer.WriteIntValue("locationX", LocationX);
            writer.WriteIntValue("locationY", LocationY);
            writer.WriteIntValue("logiCommander", LogiCommander);
            writer.WriteIntValue("regionX", RegionX);
            writer.WriteIntValue("regionY", RegionY);
            writer.WriteIntValue("ring", Ring);
            writer.WriteIntValue("ringPosition", RingPosition);
            writer.WriteStringValue("server", Server);
            writer.WriteDoubleValue("speed", Speed);
            writer.WriteIntValue("systemX", SystemX);
            writer.WriteIntValue("systemY", SystemY);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
