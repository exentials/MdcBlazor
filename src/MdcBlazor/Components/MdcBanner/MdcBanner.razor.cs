﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcBanner
    {
        [Parameter] public bool Centered { get; set; }
        [Parameter] public bool Fixed { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public string PrimaryActionLabel { get; set; }
        [Parameter] public string SecondaryActionLabel { get; set; }
        [Parameter] public EventCallback OnPrimaryActionClick { get; set; }
        [Parameter] public EventCallback OnSecondaryActionClick { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Centered)
            {
                CssAttributes.Add("mdc-banner--centered");
            }
        }

        public ValueTask Open()
        {
            return JsInvokeVoidAsync("open");
        }

        public ValueTask Close()
        {
            return JsInvokeVoidAsync("close");
        }

        private Task PrimaryClickHandle(MouseEventArgs args)
        {
            if (OnPrimaryActionClick.HasDelegate)
            {
                return OnPrimaryActionClick.InvokeAsync();
            }
            return Task.CompletedTask;
        }

        private Task SecondaryClickHandle(MouseEventArgs args)
        {
            if (OnSecondaryActionClick.HasDelegate)
            {
                return OnSecondaryActionClick.InvokeAsync();
            }
            return Task.CompletedTask;
        }

    }
}
