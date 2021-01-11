using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcInputComponentBase<TValue> : MdcComponentBase
    {
        private TValue _value;
        private bool _disabled;
        protected string LabelId { get; set; } = MdcComponentHelper.CreateId();

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
                    InvokeAsync(async () => await JSSetInputValue(_value));
                }
            }
        }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                if (_disabled == value) return;
                _disabled = value;
                InvokeAsync(async () => await JSSetDisabled(_disabled));
            }
        }

        protected abstract ValueTask<TValue> JSGetInputValue();

        protected abstract ValueTask JSSetInputValue(TValue value);

        protected virtual ValueTask<bool> JSGetDisabled()
        {
            return ValueTask.FromResult(false);
        }

        protected virtual ValueTask JSSetDisabled(bool value)
        {
            return ValueTask.CompletedTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetInputValue(Value);
            }
        }

        [JSInvokable("ChangeFromNative")]
        public ValueTask ChangeFromNative(TValue value)
        {
            if (!EqualityComparer<TValue>.Default.Equals(Value, value))
            {
                Value = value;
                StateHasChanged();
            }
            return ValueTask.CompletedTask;
        }

    }
}
