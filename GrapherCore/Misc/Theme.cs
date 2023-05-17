using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Misc
{
    public static class Theme
    {
        private static readonly int opaque = 0xff;
        private static Color FromRGB(int rgb) => Color.FromArgb(opaque, Color.FromArgb(rgb));


        // ///////////////////////////
        public static Color Main_background /*          */=> FromRGB(0x545761);//steel gray
        public static Color Main_fields_background /*   */=> FromRGB(1);
        public static Color Main_fields_border /*       */=> FromRGB(1);
        // ....

        // ///////////////////////////
        public static Color Editor_3d_background /*     */=> FromRGB(0x002449);
        public static Color Editor_3d_gridlines /*      */=> FromRGB(0xf1f227);
        public static Color Editor_3d_griddots /*       */=> FromRGB(0xf1f227);
        public static Color Editor_3d_gridlines_back /* */=> FromRGB(0xcea227);//abd225
        public static Color Editor_3d_gridlines_off /*  */=> FromRGB(0xff2975);
        public static Color Editor_3d_labels /*         */=> FromRGB(1);
        public static Color Editor_3d_axis_width /*     */=> FromRGB(1);
        public static Color Editor_3d_axis_length /*    */=> FromRGB(1);
        public static Color Editor_3d_axis_height /*    */=> FromRGB(1);
        public static Color E => FromRGB(1);
        public static Color E2 => FromRGB(1);
    }
}
