using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDataTablePagination
    {
        private int _page = 1;
        private int _itemsCount = 0;
        private int _pageSize = 10;
        private string _rowsPerPageLabel = "Rows per page";
        private string _paginationTotalFormat = "{0}-{1} of {2}";

        [Parameter] public int ItemsCount { get => _itemsCount; set => _itemsCount = value; }
        [Parameter]
        public int Page
        {
            get => _page;
            set
            {
                if (_page != value)
                {
                    _page = value;
                    if (_page < 1)
                    {
                        _page = 1;
                    }
                    if (PageChanged.HasDelegate)
                    {
                        PageChanged.InvokeAsync(_page);
                    }
                }
            }
        }
        /// <summary>
        /// Set/Get the 'rows per page' label text
        /// </summary>
        [Parameter] public string RowsPerPageLabel { get => _rowsPerPageLabel; set => _rowsPerPageLabel = value; }
        /// <summary>
        /// Set/Get the pager total formatter as '{0}-{1} of {2}'
        /// </summary>
        [Parameter] public string PaginationTotalFormat { get => _paginationTotalFormat; set => _paginationTotalFormat = value; }

        [Parameter] public EventCallback<int> PageChanged { get; set; }
        [Parameter] public EventCallback<int> OnPageSizeChanged { get; set; }

        public int PageSize
        {
            get { return _pageSize; }
            private set
            {
                if (_pageSize != value)
                {
                    Page = ((Page - 1) * _pageSize) / value + 1;
                    _pageSize = value;
                    if (OnPageSizeChanged.HasDelegate)
                    {
                        OnPageSizeChanged.InvokeAsync(_pageSize);
                    }
                }
            }
        }

        private string PaginationTotal
        {
            get
            {
                int offset = _pageSize * (Page - 1);
                return string.Format(PaginationTotalFormat, offset + 1, offset + PageSize, ItemsCount);
            }
        }

        private bool FirstPageButtonDisabled
        {
            get { return Page <= 1; }
        }

        private bool LeftPageButtonDisabled
        {
            get { return Page <= 1; }
        }

        private bool RightPageButtonDisabled
        {
            get { return Page * PageSize >= ItemsCount; }
        }

        private bool LastPageButtonDisabled
        {
            get { return Page  * PageSize >= ItemsCount; }
        }

        private Task FirstPageClick()
        {
            if (Page > 1)
            {
                Page = 1;
            }
            return Task.CompletedTask;
        }

        private Task LeftPageClick()
        {
            if (Page > 1)
            {
                Page--;
            }
            return Task.CompletedTask;
        }

        private Task RightPageClick()
        {
            if ((Page - 1) * PageSize < ItemsCount)
            {
                Page++;
            }
            return Task.CompletedTask;
        }

        private Task LastPageClick()
        {
            if ((Page - 1) * PageSize < ItemsCount)
            {
                Page = ItemsCount / PageSize + 1;
            }
            return Task.CompletedTask;
        }

    }
}
