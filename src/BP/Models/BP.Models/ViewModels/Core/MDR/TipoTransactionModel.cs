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
        /// <summary>
        /// Transaction do Tipo Débito
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Debito")]
        Debito,

        /// <summary>
        /// Transaction do Tipo Crédito
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [EnumMember(Value = "Credito")]
        Credito
    }
}
