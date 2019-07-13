using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mohsenmou.UI.WPF.Controls
{
    public class Badged:ContentControl
    {
        static Badged()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badged), new FrameworkPropertyMetadata(typeof(Badged)));
        }


        public bool IsBadgeSet
        {
            get { return (bool)GetValue(IsBadgeSetProperty); }
            set { SetValue(IsBadgeSetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBadgeSet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBadgeSetProperty =
            DependencyProperty.Register("IsBadgeSet", typeof(bool), typeof(Badged), new PropertyMetadata(true));




        public object Badge
        {
            get { return (object)GetValue(BadgeProperty); }
            set { SetValue(BadgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Badge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.Register("Badge", typeof(object), typeof(Badged), new PropertyMetadata(null));


    }
}
