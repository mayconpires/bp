using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public enum BandeiraTipoModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Visa")]
        Visa,

        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Master")]
        Master
    }
}
