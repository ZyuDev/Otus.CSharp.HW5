using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Helpers
{
    public class ValueParser
    {
        public static object Parse(string valueStr, Type valueType)
        {
            object result = null;

            if (valueType == typeof(int))
            {
                if (int.TryParse(valueStr, out var intValue))
                {
                    result = intValue;
                }
                else
                {
                    result = 0;
                }
            }
            else if (valueType == typeof(bool))
            {
                if (bool.TryParse(valueStr, out var boolValue))
                {
                    result = boolValue;
                }
                else
                {
                    result = false;
                }
            }
            else if (valueType == typeof(decimal))
            {
                valueStr = valueStr?.Replace(",", ".");
                if (decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalValue))
                {
                    result = decimalValue;
                }
                else
                {
                    result = 0M;
                }
            }
            else if (valueType == typeof(Guid))
            {
                if (Guid.TryParse(valueStr, out var guidValue))
                {
                    result = guidValue;
                }
                else
                {
                    result = Guid.Empty;
                }
            }
            else if (valueType == typeof(string))
            {
                result = valueStr;
            }

            return result;
        }
    }
}
