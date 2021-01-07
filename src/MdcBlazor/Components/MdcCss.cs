using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public static class MdcCss
    {
        public static readonly string MaterialIconsFilled = "material-icons";
        public static readonly string MaterialIconsOutlined = "material-icons-outlined";
        public static readonly string MaterialIconsRounded = "material-icons-round";
        public static readonly string MaterialIconsSharp = "material-icons-sharp";
        public static readonly string MaterialIconsTwoTone = "material-icons-two-tone";
        public static string MaterialIcons { get; private set; } = MaterialIconsFilled;

        public static void SetMaterialIcons(string materialIcons)
        {
            MaterialIcons = materialIcons;
        }       

    }
}
