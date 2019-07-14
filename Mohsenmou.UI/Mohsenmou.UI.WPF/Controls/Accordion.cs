using System.Windows.Controls;
using System.Windows;

namespace Mohsenmou.UI.WPF.Controls
{
    public class Accordion:TreeView
    {
        static Accordion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Accordion), new FrameworkPropertyMetadata(typeof(Accordion)));
        }
    }
}
