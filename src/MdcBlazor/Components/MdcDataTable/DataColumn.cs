using System.Collections;

namespace Exentials.MdcBlazor
{
    public class DataColumn
    {
        public string Header { get; set; }
        public string FieldName { get; set; }
        public string Format { get; set; }

        public object GetValue(object item)
        {
            var p = item.GetType().GetProperty(FieldName);
            var result = p?.GetValue(item);
            return result;
        }
    }
}
