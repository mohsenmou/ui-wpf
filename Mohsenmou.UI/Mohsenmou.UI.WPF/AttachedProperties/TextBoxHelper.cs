using System.Windows;
namespace Mohsenmou.UI.WPF.AttachedProperties
{
    public static class TextBoxHelper
    {
        public static readonly DependencyProperty ClearTextButtonProperty =
            DependencyProperty.RegisterAttached("ClearTextButton", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false));

        public static readonly DependencyProperty WatermarkProperty =
                    DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper), new PropertyMetadata(null));

        public static bool GetClearTextButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(ClearTextButtonProperty);
        }

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetClearTextButton(DependencyObject obj, bool value)
        {
            obj.SetValue(ClearTextButtonProperty, value);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
    }
}
