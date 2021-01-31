using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo
{
    public static class EnumHelpers
    {
        public static Dictionary<string, string> GetItems<T>() where T : struct, Enum
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            var enumType = typeof(T);

            foreach (var x in Enum.GetValues(enumType))
            {
                valuePairs.Add(x.ToString(), Enum.GetName(enumType, x));
            }
            return valuePairs;
        }
    }
}
