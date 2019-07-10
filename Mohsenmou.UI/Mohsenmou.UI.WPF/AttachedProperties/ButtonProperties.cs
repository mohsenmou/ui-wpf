using System.Windows;

namespace Mohsenmou.UI.WPF.AttachedProperties
{
    public static class ButtonProperties
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius",
                typeof(double),
                typeof(ButtonProperties),
                new FrameworkPropertyMetadata(0d));
        public static double GetCornerRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(CornerRadiusProperty);
        }
        public static void SetCornerRadius(DependencyObject obj, double value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

    }
}
