﻿using Microsoft.AspNetCore.Components;
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
                    InvokeAsync(async () => await JSSetValue(_value));
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
                if (_disabled != value)
                {
                    _disabled = value;
                    InvokeAsync(async () => await JSSetDisabled(_disabled));
                }
            }
        }

        protected ValueTask<TValue> JSGetValue()
        {
            return JsInvokeAsync<TValue>("getValue");
        }

        protected ValueTask JSSetValue(TValue value)
        {
            return JsInvokeVoidAsync("setValue", value);
        }

        protected  ValueTask<bool> JSGetDisabled()
        {
            return JsInvokeAsync<bool>("getDisabled");
        }

        protected ValueTask JSSetDisabled(bool value)
        {
            return JsInvokeVoidAsync("setDisabled",value);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetValue(Value);
                await JSSetDisabled(Disabled);
            }
        }

        /// <summary>
        /// Change method that should be invoked by the native javascript component
        /// </summary>
        /// <param name="value">the new value</param>
        /// <returns></returns>
        protected ValueTask Change(TValue value)
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
