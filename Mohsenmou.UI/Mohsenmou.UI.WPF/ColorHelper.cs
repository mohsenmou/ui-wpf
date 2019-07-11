using System.Windows.Media;

namespace Mohsenmou.UI.WPF
{
    public static class ColorHelper
    {
        public  static Color GetColorDarker(this Color color, double factor)
        {
            // The factor value cannot be greater than 1 or smaller than 0.
            // Otherwise return the original color
            if (factor < 0 || factor > 1)
                return color;

            byte r = (byte)(factor * color.R);
            byte g = (byte)(factor * color.G);
            byte b = (byte)(factor * color.B);
            return Color.FromRgb(r, g, b);
        }
        public static Color GetColorLighter(this Color color, double factor)
        {
            // The factor value cannot be greater than 1 or smaller than 0.
            // Otherwise return the original color
            if (factor < 0 || factor > 1)
                return color;

            byte r = (byte)(factor * color.R + (1 - factor) * 255);
            byte g = (byte)(factor * color.G + (1 - factor) * 255);
            byte b = (byte)(factor * color.B + (1 - factor) * 255);
            return Color.FromRgb(r, g, b);
        }
    }
}
