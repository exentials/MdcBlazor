﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public partial class MdcRadio : MdcInputComponentBase<string>
    {
        private string InputId { get; set; } = MdcComponentHelper.CreateId();
    }
}
