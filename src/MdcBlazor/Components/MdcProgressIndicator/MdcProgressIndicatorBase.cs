using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcProgressIndicatorBase : MdcComponentBase
    {
        private int _value;
        private int _min = 0;
        private int _max = 100;

        private float Progress
        {
            get { return (float)Value / Math.Abs(Max - Min); }
        }

        [Parameter] public string Label { get; set; }
        [Parameter] public bool Determinate { get; set; }

        [Parameter]
        public int Min
        {
            get => _min;
            set
            {
                if (_min > _max) throw new Exception();
                _min = value;
            }
        }
        [Parameter]
        public int Max
        {
            get => _max;
            set
            {
                if (_max < _min) throw new Exception();
                _max = value;
            }
        }
        [Parameter]
        public int Value
        {
            get => _value;
            set
            {
                if ((_value >= _min) && (_value <= _max) && (_value != value))
                {
                    _value = value;
                    InvokeAsync(async () => await JSSetProgress(Progress));
                }
            }
        }

        protected ValueTask JSSetDeterminate(bool value)
        {
            return JsInvokeVoidAsync("setDeterminate", value);
        }

        protected ValueTask JSSetProgress(float value)
        {
            return JsInvokeVoidAsync("setProgress", value);
        }

        public ValueTask Open()
        {
            return JsInvokeVoidAsync("open");
        }

        public ValueTask Close()
        {
            return JsInvokeVoidAsync("close");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSSetDeterminate(Determinate);
                await JSSetProgress(Progress);
            }
        }
    }
}
