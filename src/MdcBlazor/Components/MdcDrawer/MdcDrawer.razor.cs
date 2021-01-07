using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcDrawer : MdcContainerComponentBase
    {
        private bool _open;

        [Inject] private MdcEventService EventService { get; set; }
        [CascadingParameter(Name = "MdcTopAppBarFixed")] protected bool MdcTopAppBarFixed { get; set; }
        [CascadingParameter(Name = "MdcDrawerMode")] protected MdcDrawerMode MdcDrawerMode { get => Mode; set => Mode = value; }
        [Parameter] public MdcDrawerMode Mode { get; set; }

        [Parameter]
        public bool Open
        {
            get { return _open; }
            set
            {
                if (_open != value)
                {
                    _open = value;
                    if (OpenChanged.HasDelegate)
                    {
                        OpenChanged.InvokeAsync(_open);
                    }
                }
            }
        }

        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (MdcTopAppBarFixed)
            {
                CssAttributes.Add("mdc-top-app-bar--fixed-adjust");
            }

            switch (Mode)
            {
                case MdcDrawerMode.Dismissible:
                    CssAttributes.Add("mdc-drawer--dismissible");
                    break;
                case MdcDrawerMode.Modal:
                    CssAttributes.Add("mdc-drawer--modal");
                    break;
            }
        }

        private Action unsubscibeNav;
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                unsubscibeNav = EventService.Subscribe(MdcEvents.TopAppBarNav, () =>
                {
                    _open = !_open;
                    InvokeAsync(StateHasChanged);
                    return ValueTask.CompletedTask;
                });
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await SetOpen(_open);
        }

        public ValueTask SetOpen(bool value)
        {
            return JsInvokeVoidAsync("setOpen", value);
        }

        public override ValueTask DisposeAsync()
        {
            unsubscibeNav?.Invoke();
            return base.DisposeAsync();
        }
    }
}
