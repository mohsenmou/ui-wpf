using System.Windows;

namespace Mohsenmou.UI.WPF.AttachedProperties
{
    public static class ButtonProperties
    {
        public static double GetCornerRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(CornerRadiusProperty);
        }
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }
        public static bool GetShowIcon(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowIconProperty);
        }
        public static void SetCornerRadius(DependencyObject obj, double value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }
        public static void SetShowIcon(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowIconProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =DependencyProperty.RegisterAttached("CornerRadius",
                                                                                                            typeof(double),
                                                                                                            typeof(ButtonProperties),
                                                                                                            new FrameworkPropertyMetadata(0d));

        public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon",
                                                                                                    typeof(object),
                                                                                                    typeof(ButtonProperties),
                                                                                                    new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ShowIconProperty = DependencyProperty.RegisterAttached("ShowIcon",
                                                                                                        typeof(bool),
                                                                                                        typeof(ButtonProperties),
                                                                                                        new FrameworkPropertyMetadata(false));


    }
}
