﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcList
    {
        private int[] _selectedIndex = Array.Empty<int>();
        private bool _singleSelection;
        internal readonly List<MdcListItem> Items = new List<MdcListItem>();

        [Parameter] public bool Dense { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public MdcListType ListType { get; set; }
        [Parameter] public bool Avatar { get; set; }
        [Parameter]
        public int[] SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (!Enumerable.SequenceEqual(SelectedIndex, value))
                {
                    _selectedIndex = value;
                    if (SelectedIndexChanged.HasDelegate)
                    {
                        SelectedIndexChanged.InvokeAsync(_selectedIndex);
                    }
                    for (int i = 0, len = Items.Count; i < len; i++)
                    {
                        Items[i].SetSelected(_selectedIndex.Contains(i));
                    }
                    // InvokeAsync(async () => await JSSetSelectedIndex(_selectedIndex));
                }
            }
        }
        [Parameter] public EventCallback<int[]> SelectedIndexChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Dense)
            {
                CssAttributes.Add("mdc-list--dense");
            }
            if (Avatar)
            {
                CssAttributes.Add("mdc-list--avatar-list");
            }
            if (ListType == MdcListType.TwoLine)
            {
                CssAttributes.Add("mdc-list--two-line");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                switch (ListType)
                {
                    case MdcListType.SingleLine:
                    case MdcListType.TwoLine:
                    case MdcListType.RadioGroup:
                        _singleSelection = true;
                        break;
                    case MdcListType.Checkbox:
                        _singleSelection = false;
                        break;
                }
                await JSSetSingleSelection(_singleSelection);
                if (SelectedIndex.Length > 0)
                {
                    await JSSetSelectedIndex(SelectedIndex);
                }
            }
        }

        internal string Role
        {
            get
            {
                return ListType switch
                {
                    MdcListType.SingleLine => "listbox",
                    MdcListType.TwoLine => "listbox",
                    MdcListType.RadioGroup => "radiogroup",
                    MdcListType.Checkbox => "group",
                    _ => "",
                };
            }
        }

        private ValueTask JSSetSingleSelection(bool value)
        {
            return JsInvokeVoidAsync("setSingleSelection", value);
        }

        private ValueTask<int[]> JSGetSelectedIndex()
        {
            return JsInvokeAsync<int[]>("getSelectedIndex");
        }

        private ValueTask JSSetSelectedIndex(int[] value)
        {
            return (_singleSelection) ? JsInvokeVoidAsync("setSelectedIndex", value?[0]) : JsInvokeVoidAsync("setSelectedIndex", value);
        }

        [JSInvokable("MDCList:action")]
        public ValueTask MDCListAction(int[] index)
        {
            SelectedIndex = index;
            return ValueTask.CompletedTask;
        }

    }
}