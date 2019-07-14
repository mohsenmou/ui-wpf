using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mohsenmou.UI.WPF.Controls
{
    public class Badged : ContentControl
    {
        public static readonly DependencyProperty BadgePlacementModeProperty = DependencyProperty.Register(
            "BadgePlacementMode", typeof(BadgePlacement), typeof(Badged),
            new FrameworkPropertyMetadata(BadgePlacement.TopRight));

        public static readonly DependencyProperty BadgeProperty =
            DependencyProperty.Register("Badge", typeof(object), typeof(Badged), new PropertyMetadata(null));

        public static readonly DependencyProperty IsBadgeSetProperty =
            DependencyProperty.Register("IsBadgeSet", typeof(bool), typeof(Badged), new PropertyMetadata(true));

        static Badged()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badged), new FrameworkPropertyMetadata(typeof(Badged)));
        }



        public override void OnApplyTemplate()
        {

            if (GetTemplateChild("translate") is TranslateTransform translate)
            {
                switch (BadgePlacementMode)
                {
                    case BadgePlacement.left:
                        translate.X = -10;
                        break;
                    case BadgePlacement.Top:
                        translate.Y = -10;
                        break;
                    case BadgePlacement.Right:
                        translate.X = 10;
                        break;
                    case BadgePlacement.Bottom:
                        translate.Y = 10;
                        break;
                    case BadgePlacement.TopLeft:
                        translate.X = -10;
                        translate.Y = -10;
                        break;
                    case BadgePlacement.TopRight:
                        translate.X = 10;
                        translate.Y = -10;
                        break;
                    case BadgePlacement.BottomLeft:
                        translate.X = -10;
                        translate.Y = 10;
                        break;
                    case BadgePlacement.BottomRight:
                        translate.X = 10;
                        translate.Y = 10;
                        break;
                    default:
                        break;
                }
            }
            base.OnApplyTemplate();

        }
        public object Badge
        {
            get { return (object)GetValue(BadgeProperty); }
            set { SetValue(BadgeProperty, value); }
        }

        public BadgePlacement BadgePlacementMode
        {
            get { return (BadgePlacement)GetValue(BadgePlacementModeProperty); }
            set { SetValue(BadgePlacementModeProperty, value); }
        }

        public bool IsBadgeSet
        {
            get { return (bool)GetValue(IsBadgeSetProperty); }
            set { SetValue(IsBadgeSetProperty, value); }
        }

    }
}
