using System;
using System.Windows;
using System.Windows.Media;

namespace Mohsenmou.UI.WPF
{
    public sealed class Theme
    {
        [ThreadStatic]
        private static ResourceDictionary resourceDictionary;
        public static ThemeType ThemeType { get; set; } = ThemeType.Light;
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
        private static void LoadThemeType(ThemeType type)
        {
            ThemeType = type;
            switch (type)
            {
                case ThemeType.Light:
                    break;
                case ThemeType.Dark:
                    break;
                default:
                    break;
            }
        }
    }
}
