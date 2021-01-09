using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class Chip
    {
        public Chip() { }
        public string Id { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}
