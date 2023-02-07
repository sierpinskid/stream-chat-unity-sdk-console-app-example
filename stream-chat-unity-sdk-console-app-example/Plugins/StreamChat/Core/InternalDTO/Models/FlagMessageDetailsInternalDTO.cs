﻿//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------


using StreamChat.Core.InternalDTO.Responses;
using StreamChat.Core.InternalDTO.Requests;
using StreamChat.Core.InternalDTO.Events;

namespace StreamChat.Core.InternalDTO.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v9.0.0.0))")]
    internal partial class FlagMessageDetailsInternalDTO
    {
        [Newtonsoft.Json.JsonProperty("pin_changed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PinChanged { get; set; }

        [Newtonsoft.Json.JsonProperty("should_enrich", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ShouldEnrich { get; set; }

        [Newtonsoft.Json.JsonProperty("skip_push", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? SkipPush { get; set; }

        [Newtonsoft.Json.JsonProperty("updated_by_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UpdatedById { get; set; }

        private System.Collections.Generic.Dictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.Dictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
            set { _additionalProperties = value; }
        }

    }

}
