using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcIconButtonToggle : MdcButtonComponentBase
    {
        private bool _selected;

        [CascadingParameter(Name = "MdcParentContainerType")] Type ParentContainerType { get; set; }
        [Parameter] public string ToggleIcon { get; set; }
        [Parameter]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    if (SelectedChanged.HasDelegate)
                    {
                        SelectedChanged.InvokeAsync(_selected);
                    }
                    InvokeAsync(async () => await JsSetSelected(_selected));
                }
            }
        }
        [Parameter] public EventCallback<bool> SelectedChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (ParentContainerType == typeof(MdcCardActions))
            {
                CssAttributes.Add("mdc-card__action");
                CssAttributes.Add("mdc-card__action--icon");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JsSetSelected(Selected);
            }
        }

        [JSInvokable("MDCIconButtonToggle:change")]
        public ValueTask MDCIconButtonToggleChange(bool value)
        {

            Selected = value;
            StateHasChanged();
            return ValueTask.CompletedTask;
        }

        private ValueTask JsSetSelected(bool value)
        {
            return JsInvokeVoidAsync("setSelect", value);
        }
    }
}
