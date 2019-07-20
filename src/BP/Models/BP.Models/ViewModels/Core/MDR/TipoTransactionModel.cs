using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public enum TipoTransactionModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Debito")]
        Debito,

        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Credito")]
        Credito
    }
}
