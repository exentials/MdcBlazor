using System.Collections;
using System.Reflection;

namespace Exentials.MdcBlazor
{
    public class DataColumn
    {
        private PropertyInfo _fieldPropertyInfo;
        public string Header { get; set; }
        public string FieldName { get; set; }
        public string Format { get; set; }
        public bool Numeric { get; set; }

        public object GetValue(object item)
        {
            if (_fieldPropertyInfo == null)
            {
                _fieldPropertyInfo = item.GetType().GetProperty(FieldName);
            }
            return _fieldPropertyInfo?.GetValue(item);
        }

        public string GetFormattedValue(object item)
        {
            if (string.IsNullOrEmpty(Format))
            {
                return GetValue(item).ToString();
            }
            else
            {
                var format = "{0:"+ Format +"}";
                return string.Format(format, GetValue(item));
            }
        }
    }
}
