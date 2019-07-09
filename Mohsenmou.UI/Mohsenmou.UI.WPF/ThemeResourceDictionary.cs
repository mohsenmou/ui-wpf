using System.Windows;

namespace Mohsenmou.UI.WPF
{
    public sealed class ThemeResourceDictionary:ResourceDictionary
    {
        public ThemeResourceDictionary()
        {
            MergedDictionaries.Add(Theme.ResourceDictionary);
        }
    }
}
