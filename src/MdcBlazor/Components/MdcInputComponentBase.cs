using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcInputComponentBase<TValue> : MdcComponentBase
    {
        protected string LabelId { get; set; } = MdcComponentHelper.CreateId();

        protected TValue _value;

        [Parameter] public string Label { get; set; }
        [Parameter]
        public virtual TValue Value
        {
            get => _value;
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(_value, value))
                {
                    _value = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(_value);
                    }
                    InvokeAsync(async () => await SetInputValue(_value));
                }
            }
        }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public bool Disabled { get; set; }

        protected abstract ValueTask<TValue> GetInputValue();

        protected abstract ValueTask SetInputValue(TValue value);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await SetInputValue(Value);
            }
        }

        [JSInvokable("ChangeFromNative")]
        public ValueTask ChangeFromNative(TValue value)
        {
            Value = value;
            StateHasChanged();
            return ValueTask.CompletedTask;
        }

    }
}
