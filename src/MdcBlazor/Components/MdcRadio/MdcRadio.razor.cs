using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcRadio : MdcInputComponentBase<string>
    {
        private bool _checked;
        private readonly string _inputId = MdcComponentHelper.CreateId();
        private MdcComponentBase FormField { get; set; }

        [CascadingParameter] MdcRadioGroup MdcRadioGroup { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public bool NoWrap { get; set; }
        [Parameter] public bool AlignEnd { get; set; }
        [Parameter]
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (CheckedChanged.HasDelegate)
                    {
                        CheckedChanged.InvokeAsync(_checked);
                    }
                    if (MdcRadioGroup != null)
                    {
                        MdcRadioGroup.SetValue(Value);
                    }
                    InvokeAsync(async () => await JsSetChecked(_checked));
                }
            }
        }
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (MdcRadioGroup != null)
            {
                MdcRadioGroup.Radios.Add(this);
                Name = MdcRadioGroup.Name;

                Checked = MdcRadioGroup.Value == Value;
            }
        }

        public override ValueTask DisposeAsync()
        {
            MdcRadioGroup?.Radios.Remove(this);
            return base.DisposeAsync();
        }

        internal ValueTask Uncheck()
        {
            return JsSetChecked(false);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (FormField != null)
                {
                    await JsInvokeVoidAsync("initFormField", FormField.Ref);
                }
                await JsSetChecked(Checked);
                await JSSetDisabled(Disabled);
            }
        }

        protected ValueTask<bool> JsGetChecked()
        {
            return JsInvokeAsync<bool>("getChecked");
        }

        protected ValueTask JsSetChecked(bool value)
        {
            return JsInvokeVoidAsync("setChecked", value);
        }

        [JSInvokable("MDCRadio:change")]
        public ValueTask MDCRadioChange(bool isChecked)
        {
            if (Checked != isChecked)
            {
                if (MdcRadioGroup == null)
                {
                    Checked = isChecked;
                }
                else
                {
                    foreach (var radio in MdcRadioGroup.Radios)
                    {
                        radio.Checked = (radio.Value == Value);
                    }
                    MdcRadioGroup.SetValue(Value);
                }
                StateHasChanged();
            }
            return ValueTask.CompletedTask;
        }
    }
}
