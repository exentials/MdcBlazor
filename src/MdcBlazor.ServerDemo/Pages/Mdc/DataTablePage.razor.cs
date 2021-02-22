using Exentials.MdcBlazor.ServerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor.ServerDemo.Pages.Mdc
{
    public partial class DataTablePage
    {
        private List<DataModel> items;
        private DataTableSource dataSource;

        MdcDataTablePagination pager;
        int currentPage =1;

        public DataTablePage()
        {
            items = new List<DataModel>();

            items.Add(new DataModel() { Id = 1, StringValue = "String 1", BoolValue = true, DecimalValue = 1002.6M });
            items.Add(new DataModel() { Id = 2, StringValue = "String 2", BoolValue = true, DecimalValue = 12.6M });
            items.Add(new DataModel() { Id = 3, StringValue = "String 3", BoolValue = false, DecimalValue = 33 });
            items.Add(new DataModel() { Id = 4, StringValue = "String 4", BoolValue = false, DecimalValue = 0.5M });
            items.Add(new DataModel() { Id = 5, StringValue = "String 5", BoolValue = true, DecimalValue = 1.6M });
            items.Add(new DataModel() { Id = 6, StringValue = "String 5", BoolValue = true, DecimalValue = 12.3M });
            items.Add(new DataModel() { Id = 7, StringValue = "String 5", BoolValue = true, DecimalValue = 42.6M });
            items.Add(new DataModel() { Id = 8, StringValue = "String 5", BoolValue = true, DecimalValue = 12.6M });
            items.Add(new DataModel() { Id = 9, StringValue = "String 5", BoolValue = true, DecimalValue = 152.4M });
            items.Add(new DataModel() { Id = 10, StringValue = "String 5", BoolValue = true, DecimalValue = 102.2M });
            items.Add(new DataModel() { Id = 11, StringValue = "String 5", BoolValue = true, DecimalValue = 142.1M });

            dataSource = new DataTableSource(items);
        }

    }
}
