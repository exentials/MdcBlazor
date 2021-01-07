using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public abstract class MdcComponentBase : ComponentBase, IAsyncDisposable
    {
        private DotNetObjectReference<MdcComponentBase> dotNetObjectRef;
        protected CssAttributes CssAttributes { get; private set; } = new CssAttributes();
        protected ElementReference? Ref { get; set; }

        [Inject] protected IJSRuntime Js { get; set; }
        [Parameter] public string Id { get; set; } = CreateId("_mdc_");
        [Parameter] public string CssClass { get; set; }


        private static string CreateId(string prefix)
        {
            return $"{prefix}{Guid.NewGuid()}";
        }

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
