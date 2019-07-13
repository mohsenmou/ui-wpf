using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Mohsenmou.UI.WPF.Controls
{
    public class AdornedControl : ContentControl
    {
        #region Public Fields

        public static readonly DependencyProperty AdornerContentProperty =
            DependencyProperty.Register("AdornerContent", typeof(FrameworkElement), typeof(AdornedControl),
                        new FrameworkPropertyMetadata(AdornerContent_PropertyChanged));

        public static readonly DependencyProperty AdornerOffsetXProperty =
            DependencyProperty.Register("AdornerOffsetX", typeof(double), typeof(AdornedControl));

        public static readonly DependencyProperty AdornerOffsetYProperty =
            DependencyProperty.Register("AdornerOffsetY", typeof(double), typeof(AdornedControl));

        public static readonly RoutedCommand HideAdornerCommand = new RoutedCommand("HideAdorner", typeof(AdornedControl));

        public static readonly DependencyProperty HorizontalAdornerPlacementProperty =
            DependencyProperty.Register("HorizontalAdornerPlacement", typeof(AdornerPlacement), typeof(AdornedControl),
                        new FrameworkPropertyMetadata(AdornerPlacement.Inside));

        public static readonly DependencyProperty IsAdornerVisibleProperty =
            DependencyProperty.Register("IsAdornerVisible", typeof(bool), typeof(AdornedControl),
                new FrameworkPropertyMetadata(IsAdornerVisible_PropertyChanged));

        public static readonly RoutedCommand ShowAdornerCommand = new RoutedCommand("ShowAdorner", typeof(AdornedControl));

        public static readonly DependencyProperty VerticalAdornerPlacementProperty =
            DependencyProperty.Register("VerticalAdornerPlacement", typeof(AdornerPlacement), typeof(AdornedControl),
                new FrameworkPropertyMetadata(AdornerPlacement.Inside));

        #endregion Public Fields

        #region Private Fields

        private static readonly CommandBinding HideAdornerCommandBinding = new CommandBinding(HideAdornerCommand, HideAdornerCommand_Executed);
        private static readonly CommandBinding ShowAdornerCommandBinding = new CommandBinding(ShowAdornerCommand, ShowAdornerCommand_Executed);
        private FrameworkElementAdorner adorner = null;
        private AdornerLayer adornerLayer = null;

        #endregion Private Fields

        #region Public Constructors

        static AdornedControl()
        {
            CommandManager.RegisterClassCommandBinding(typeof(AdornedControl), ShowAdornerCommandBinding);
            CommandManager.RegisterClassCommandBinding(typeof(AdornedControl), HideAdornerCommandBinding);
        }

        public AdornedControl()
        {
            this.Focusable = false;
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(AdornedControl_DataContextChanged);
        }

        #endregion Public Constructors

        #region Public Properties

        public FrameworkElement AdornerContent
        {
            get { return (FrameworkElement)GetValue(AdornerContentProperty); }
            set { SetValue(AdornerContentProperty, value); }
        }

        public double AdornerOffsetX
        {
            get { return (double)GetValue(AdornerOffsetXProperty); }
            set { SetValue(AdornerOffsetXProperty, value); }
        }

        public double AdornerOffsetY
        {
            get { return (double)GetValue(AdornerOffsetYProperty); }
            set { SetValue(AdornerOffsetYProperty, value); }
        }

        public AdornerPlacement HorizontalAdornerPlacement
        {
            get { return (AdornerPlacement)GetValue(HorizontalAdornerPlacementProperty); }
            set { SetValue(HorizontalAdornerPlacementProperty, value); }
        }

        public bool IsAdornerVisible
        {
            get { return (bool)GetValue(IsAdornerVisibleProperty); }
            set { SetValue(IsAdornerVisibleProperty, value); }
        }

        public AdornerPlacement VerticalAdornerPlacement
        {
            get { return (AdornerPlacement)GetValue(VerticalAdornerPlacementProperty); }
            set { SetValue(VerticalAdornerPlacementProperty, value); }
        }

        #endregion Public Properties

        #region Public Methods

        public void HideAdorner()
        {
            IsAdornerVisible = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ShowOrHideAdornerInternal();
        }

        public void ShowAdorner()
        {
            IsAdornerVisible = true;
        }

        #endregion Public Methods

        #region Private Methods

        private static void AdornerContent_PropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            AdornedControl c = (AdornedControl)o;
            c.ShowOrHideAdornerInternal();
        }

        private static void HideAdornerCommand_Executed(object target, ExecutedRoutedEventArgs e)
        {
            AdornedControl c = (AdornedControl)target;
            c.HideAdorner();
        }

        private static void IsAdornerVisible_PropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            AdornedControl c = (AdornedControl)o;
            c.ShowOrHideAdornerInternal();
        }

        private static void ShowAdornerCommand_Executed(object target, ExecutedRoutedEventArgs e)
        {
            AdornedControl c = (AdornedControl)target;
            c.ShowAdorner();
        }

        private void AdornedControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateAdornerDataContext();
        }

        private void HideAdornerInternal()
        {
            if (this.adornerLayer == null || this.adorner == null)
            {
                return;
            }

            this.adornerLayer.Remove(this.adorner);
            this.adorner.DisconnectChild();

            this.adorner = null;
            this.adornerLayer = null;
        }

        private void ShowAdornerInternal()
        {
            if (this.adorner != null)
            {
                return;
            }

            if (this.AdornerContent != null)
            {
                if (this.adornerLayer == null)
                {
                    this.adornerLayer = AdornerLayer.GetAdornerLayer(this);
                }

                if (this.adornerLayer != null)
                {
                    this.adorner = new FrameworkElementAdorner(this.AdornerContent, this, this.HorizontalAdornerPlacement, this.VerticalAdornerPlacement,
                                                     this.AdornerOffsetX, this.AdornerOffsetY);
                    this.adornerLayer.Add(this.adorner);

                    UpdateAdornerDataContext();
                }
            }
        }

        private void ShowOrHideAdornerInternal()
        {
            if (IsAdornerVisible)
            {
                ShowAdornerInternal();
            }
            else
            {
                HideAdornerInternal();
            }
        }

        private void UpdateAdornerDataContext()
        {
            if (this.AdornerContent != null)
            {
                this.AdornerContent.DataContext = this.DataContext;
            }
        }

        #endregion Private Methods
    }
}