//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------


using StreamChat.Core.DTO.Responses;
using StreamChat.Core.DTO.Events;
using StreamChat.Core.DTO.Models;

namespace StreamChat.Core.DTO.Requests
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0))")]
    internal partial class ExportChannelsRequestDTO
    {
        /// <summary>
        /// Export options for channels
        /// </summary>
        [Newtonsoft.Json.JsonProperty("channels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ChannelExportRequestDTO> Channels { get; set; }

        /// <summary>
        /// Set if deleted message text should be cleared
        /// </summary>
        [Newtonsoft.Json.JsonProperty("clear_deleted_message_text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ClearDeletedMessageText { get; set; }

        [Newtonsoft.Json.JsonProperty("export_users", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ExportUsers { get; set; }

        /// <summary>
        /// Set if you want to include truncated messages
        /// </summary>
        [Newtonsoft.Json.JsonProperty("include_truncated_messages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeTruncatedMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Version { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }

}

