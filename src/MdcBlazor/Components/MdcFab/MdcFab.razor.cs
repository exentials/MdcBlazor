﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcFab : MdcButtonComponentBase
    {
        [Parameter] public MdcFabType FabType { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Exited { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            switch (FabType)
            {
                case MdcFabType.Regular:
                    break;
                case MdcFabType.Mini:
                    CssAttributes.Add("mdc-fab--mini");
                    break;
                case MdcFabType.Extended:
                    CssAttributes.Add("mdc-fab--extended");
                    break;
            }
            if (Exited)
            {
                CssAttributes.Add("mdc-fab--exited");
            }
        }

    }
}
