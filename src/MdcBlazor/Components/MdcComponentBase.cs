using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcComponentBase : ComponentBase, IAsyncDisposable
    {
        private string _id;
        private DotNetObjectReference<MdcComponentBase> dotNetObjectRef;
        protected CssAttributes CssAttributes { get; private set; } = new CssAttributes();
        protected ElementReference? Ref { get; set; }

        [Inject] protected IJSRuntime Js { get; set; }
        [Parameter] public string Id 
        {
            get 
            { 
                if (!Has(_id))
                {
                    _id = MdcComponentHelper.CreateId();
                }
                return _id;
            } 
            set
            {
                if (Has(value))
                {
                    _id = value;
                }
            }
        } 
        [Parameter] public string CssClass { get; set; }


        private string GetJsFunctionNamespace(string functioName)
        {
            string className = GetType().Name.Split('`')[0];
            return $"exentials.mdcBlazor.{className}.{functioName}";
        }

        private object[] MergeRefToParameters(object[] args)
        {
            var parameters = new List<object>();
            parameters.Add(Ref);
            parameters.AddRange(args);
            return parameters.ToArray();
        }

        protected static bool Has(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        protected ValueTask JsInvokeVoidAsync(string function, params object[] args)
        {
            return Js.InvokeVoidAsync(GetJsFunctionNamespace(function), MergeRefToParameters(args));
        }

        protected ValueTask<T> JsInvokeAsync<T>(string function, params object[] args)
        {
            return Js.InvokeAsync<T>(GetJsFunctionNamespace(function), MergeRefToParameters(args));
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CssAttributes.Add(CssClass);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (Ref != null)
                {
                    dotNetObjectRef = DotNetObjectReference.Create(this);
                    await JsInvokeVoidAsync("init", dotNetObjectRef);
                }
            }
            await base.OnInitializedAsync();
        }

        public virtual ValueTask DisposeAsync()
        {
            if (Ref != null)
            {
                dotNetObjectRef?.Dispose();
                return JsInvokeVoidAsync("destroy", Ref);
            }
            return ValueTask.CompletedTask;
        }
    }
}
