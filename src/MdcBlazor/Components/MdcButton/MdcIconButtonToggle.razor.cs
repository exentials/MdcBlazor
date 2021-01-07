using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcIconButtonToggle
    {
        private bool _selected;

        [CascadingParameter(Name = "MdcParentContainerType")] protected Type ContainerType { get; set; }
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
                        InvokeAsync(async () => await SetSelected(_selected));
                    }
                }
            }
        }
        [Parameter] public EventCallback<bool> SelectedChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (ContainerType == typeof(MdcCardActions))
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
                await SetSelected(Selected);
            }
        }

        [JSInvokable("ChangeFromNative")]
        public ValueTask ChangeFromNative(bool value)
        {
            Selected = value;
            return ValueTask.CompletedTask;
        }

        private async ValueTask SetSelected(bool value)
        {
            await JsInvokeVoidAsync("setSelect", value);
        }
    }
}
