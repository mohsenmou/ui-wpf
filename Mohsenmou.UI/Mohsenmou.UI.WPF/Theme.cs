using System;
using System.Windows;
using System.Windows.Media;

namespace Mohsenmou.UI.WPF
{
    public sealed class Theme
    {
        [ThreadStatic]
        private static ResourceDictionary resourceDictionary;
        public static ThemeType ThemeType { get; set; } = ThemeType.Dark;
        internal static ResourceDictionary ResourceDictionary
        {
            get
            {
                if (resourceDictionary != null)
                {
                    return resourceDictionary;
                }
                resourceDictionary = new ResourceDictionary();
                LoadThemeType(ThemeType.Light);
                return resourceDictionary;
            }
        }
        public static object GetResource(ThemeResourceKey resourceKey)
        {
            return ResourceDictionary.Contains(resourceKey.ToString()) ?
                ResourceDictionary[resourceKey.ToString()] : null;
        }
        internal static Color ColorFromHex(string colorHex)
        {
            return (Color?)ColorConverter.ConvertFromString(colorHex) ?? Colors.Transparent;
        }
        internal static void SetResource(object key, object resource)
        {
            ResourceDictionary[key] = resource;
        }
        private static LinearGradientBrush GetWindowHeaderGradient()
        {
            return new LinearGradientBrush
            {
                StartPoint = new Point(0, 0.5),
                EndPoint = new Point(1, 0.5),
                GradientStops = new GradientStopCollection
                    {
                        new GradientStop { Offset = 0, Color = ColorFromHex("#FF833AB4") },
                        new GradientStop { Offset = 1, Color = ColorFromHex("#FFFD1D1D") }
                    }
            };
        }
        public static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;

            switch (type)
            {
                case ThemeType.Light:
                    InitializeLightTheme(Colors.DarkOrange);
                    break;
                case ThemeType.Dark:
                    InitializeDarkTheme(Colors.DarkOrange);
                    break;
            }
        }
        private static void InitializeLightTheme(Color accentColor,
                                                 string backgroundColor = "#FFFFFFFF",
                                                 string foregroundColor = "#FF3F3F3F")
        {
            //Set resource for disabled controls
            SetResource(ThemeResourceKey.ControlDisabledOpacity.ToString(), 0.8d);

            //Set window resource keys
            SetResource(ThemeResourceKey.WindowHeaderBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.WindowHeaderForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));
            SetResource(ThemeResourceKey.WindowControlMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.1)));
            SetResource(ThemeResourceKey.WindowBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));
            SetResource(ThemeResourceKey.WindowActiveBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 1)));

            //Set content resource Keys
            SetResource(ThemeResourceKey.ContentBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.ContentForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set controls resource Keys  

            //controls default state
            SetResource(ThemeResourceKey.ControlDefaultBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.9)));

            //controls focus state
            SetResource(ThemeResourceKey.ControlFocusBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9))); 
            
            //controls content 
            SetResource(ThemeResourceKey.ControlContentBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));

            //controls highlight states
            SetResource(ThemeResourceKey.ControlHighlightBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.7)));

            //controls default states
            SetResource(ThemeResourceKey.ControlBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.ControlBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));
            SetResource(ThemeResourceKey.ControlForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //controls mouse over states
            SetResource(ThemeResourceKey.ControlMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor,0.1)));
            SetResource(ThemeResourceKey.ControlMouseOverBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));

            //controls pressed states
            SetResource(ThemeResourceKey.ControlPressedBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));
            SetResource(ThemeResourceKey.ControlPressedBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.3)));


            //Set Lists resource keys
            SetResource(ThemeResourceKey.ListMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.1)));
            SetResource(ThemeResourceKey.ListMouseOverBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));
            SetResource(ThemeResourceKey.ListSelectedBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.2)));
            SetResource(ThemeResourceKey.ListSelectedBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.3)));
            SetResource(ThemeResourceKey.ListSelectedForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set glyph resource Keys
            SetResource(ThemeResourceKey.GlyphForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set groupbox  resource Keys
            SetResource(ThemeResourceKey.GroupBoxHeaderBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 1)));
            SetResource(ThemeResourceKey.GroupBoxHeaderForeground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 1)));
        }
        private static void InitializeDarkTheme(Color accentColor,
                                                string backgroundColor = "#FF222529",
                                                string foregroundColor = "#FFF4F6F9")
        {
            //Set resource for disabled controls
            SetResource(ThemeResourceKey.ControlDisabledOpacity.ToString(), 0.7d);

            //Set window resource keys
            SetResource(ThemeResourceKey.WindowHeaderBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.WindowHeaderForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));
            SetResource(ThemeResourceKey.WindowControlMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.8)));
            SetResource(ThemeResourceKey.WindowBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.2)));
            SetResource(ThemeResourceKey.WindowActiveBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 1)));

            //Set content resource Keys
            SetResource(ThemeResourceKey.ContentBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.ContentForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set controls resource Keys  

            //controls default state
            SetResource(ThemeResourceKey.ControlDefaultBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.9)));

            //controls focus state
            SetResource(ThemeResourceKey.ControlFocusBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 1)));

            //controls content 
            SetResource(ThemeResourceKey.ControlContentBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));

            //controls highlight states
            SetResource(ThemeResourceKey.ControlHighlightBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.7)));

            //controls default states
            SetResource(ThemeResourceKey.ControlBackground.ToString(), new SolidColorBrush(ColorFromHex(backgroundColor)));
            SetResource(ThemeResourceKey.ControlBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9)));
            SetResource(ThemeResourceKey.ControlForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //controls mouse over states
            SetResource(ThemeResourceKey.ControlMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.8)));
            SetResource(ThemeResourceKey.ControlMouseOverBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9)));

            //controls pressed states
            SetResource(ThemeResourceKey.ControlPressedBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.7)));
            SetResource(ThemeResourceKey.ControlPressedBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorLighter(accentColor, 0.8)));


            //Set Lists resource keys
            SetResource(ThemeResourceKey.ListMouseOverBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9)));
            SetResource(ThemeResourceKey.ListMouseOverBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.8)));
            SetResource(ThemeResourceKey.ListSelectedBackground.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.8)));
            SetResource(ThemeResourceKey.ListSelectedBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.7)));
            SetResource(ThemeResourceKey.ListSelectedForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set glyph resource Keys
            SetResource(ThemeResourceKey.GlyphForeground.ToString(), new SolidColorBrush(ColorFromHex(foregroundColor)));

            //Set groupbox resource Keys
            SetResource(ThemeResourceKey.GroupBoxHeaderBorder.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9)));
            SetResource(ThemeResourceKey.GroupBoxHeaderForeground.ToString(), new SolidColorBrush(ColorHelper.GetColorDarker(accentColor, 0.9)));
        }


    }
}
