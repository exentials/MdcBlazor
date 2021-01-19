using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcListItem : MdcComponentBase
    {
        private string _inputId;
        private bool _selected;

        [CascadingParameter] MdcList MdcList { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public string SecondaryLabel { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public RenderFragment Avatar { get; set; }
        [Parameter] public string IconButton { get; set; }
        [Parameter] public string MetaText { get; set; }
        [Parameter]
        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    if (SelectedChanged.HasDelegate)
                    {
                        SelectedChanged.InvokeAsync(_selected);
                    }
                    InvokeAsync(async () => await JsSetActive(_selected));
                }
            }
        }
        [Parameter] public EventCallback<bool> SelectedChanged { get; set; }

        private string InputId
        {
            get
            {
                if (_inputId != null)
                {
                    _inputId = Value;
                }
                return _inputId;
            }
        }

        private string Name
        {
            get { return MdcList?.Name; }
        }


        internal string Role
        {
            get
            {
                if (MdcList != null)
                {
                    switch (MdcList.Role)
                    {
                        case "listbox": return "option";
                        case "radiogroup": return "radio";
                        case "group": return "checkbox";
                    }
                }
                return null;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JsSetActive(Selected);
                await JsSetDisabled(Disabled);
            }
        }

        protected ValueTask JsSetActive(bool value)
        {
            return value ? JsInvokeVoidAsync("activate") : JsInvokeVoidAsync("deactivate");
        }
        protected ValueTask<bool> JsGetDisabled()
        {
            return JsInvokeAsync<bool>("getDisabled");
        }

        protected ValueTask JsSetDisabled(bool value)
        {
            return JsInvokeVoidAsync("setDisabled", value);
        }


    }
}
