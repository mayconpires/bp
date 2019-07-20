using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BP.Models.Shared.Json
{
    public class DecimalFormatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal));
        }

        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
            //writer.WriteValue(string.Format("{0:N2}", value));
            //writer.WriteValue(Math.Round((decimal)value, 2, MidpointRounding.ToEven));
            //writer.WriteRawValue($"{value:0.00}"

            //if (DecimalFormatConverter.IsWholeValue(value))
            //{
            //    writer.WriteRawValue(JsonConvert.ToString(Convert.ToInt64(value)));
            //}
            //else
            //{
            //    writer.WriteRawValue(JsonConvert.ToString(value));
            //}

            writer.WriteRawValue(((decimal)value).ToString("F2", CultureInfo.InvariantCulture));


        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType,
                                     object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private static bool IsWholeValue(object value)
        {
            if (value is decimal)
            {
                decimal decimalValue = (decimal)value;
                int precision = (Decimal.GetBits(decimalValue)[3] >> 16) & 0x000000FF;
                return precision == 0;
            }
            else if (value is float || value is double)
            {
                double doubleValue = (double)value;
                return doubleValue == Math.Truncate(doubleValue);
            }

            return false;
        }
    }
}
