using System.Windows;
using System.Windows.Controls;

namespace Mohsenmou.UI.WPF.Controls
{
    public class AccordionItem : TreeViewItem
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(AccordionItem), new PropertyMetadata(null));

        public static readonly DependencyProperty ShowIconProperty =
            DependencyProperty.Register("ShowIcon", typeof(bool), typeof(AccordionItem), new PropertyMetadata(false));

        static AccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AccordionItem), new FrameworkPropertyMetadata(typeof(AccordionItem)));
        }

        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value);} 
        }

        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }
    }
}