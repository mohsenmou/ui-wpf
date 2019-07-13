using System;
using System.Collections;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mohsenmou.UI.WPF.Controls
{
    public class FrameworkElementAdorner : Adorner
    {
        #region Private Fields

        private FrameworkElement child;
        private AdornerPlacement horizontalAdornerPlacement = AdornerPlacement.Inside;
        private double offsetX = 0.0;
        private double offsetY = 0.0;
        private double positionX = Double.NaN;
        private double positionY = Double.NaN;
        private AdornerPlacement verticalAdornerPlacement = AdornerPlacement.Inside;

        #endregion Private Fields

        #region Public Constructors

        public FrameworkElementAdorner(FrameworkElement adornerChildElement, FrameworkElement adornedElement)
            : base(adornedElement)
        {
            this.child = adornerChildElement;
            base.AddLogicalChild(adornerChildElement);
            base.AddVisualChild(adornerChildElement);
        }

        public FrameworkElementAdorner(FrameworkElement adornerChildElement, FrameworkElement adornedElement,
                                       AdornerPlacement horizontalAdornerPlacement, AdornerPlacement verticalAdornerPlacement,
                                       double offsetX, double offsetY)
            : base(adornedElement)
        {
            this.child = adornerChildElement;
            this.horizontalAdornerPlacement = horizontalAdornerPlacement;
            this.verticalAdornerPlacement = verticalAdornerPlacement;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            adornedElement.SizeChanged += new SizeChangedEventHandler(adornedElement_SizeChanged);
            base.AddLogicalChild(adornerChildElement);
            base.AddVisualChild(adornerChildElement);
        }

        #endregion Public Constructors

        #region Public Properties

        public new FrameworkElement AdornedElement
        {
            get { return (FrameworkElement)base.AdornedElement; }
        }

        public double PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        public double PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                list.Add(this.child);
                return (IEnumerator)list.GetEnumerator();
            }
        }

        protected override Int32 VisualChildrenCount
        {
            get { return 1; }
        }

        #endregion Protected Properties

        #region Public Methods

        public void DisconnectChild()
        {
            base.RemoveLogicalChild(child);
            base.RemoveVisualChild(child);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = PositionX;
            if (Double.IsNaN(x))
            {
                x = DetermineX();
            }
            double y = PositionY;
            if (Double.IsNaN(y))
            {
                y = DetermineY();
            }
            double adornerWidth = DetermineWidth();
            double adornerHeight = DetermineHeight();
            this.child.Arrange(new Rect(x, y, adornerWidth, adornerHeight));
            return finalSize;
        }

        protected override Visual GetVisualChild(Int32 index)
        {
            return this.child;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        #endregion Protected Methods

        #region Private Methods

        private void adornedElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            InvalidateMeasure();
        }

        private double DetermineHeight()
        {
            if (!Double.IsNaN(PositionY))
            {
                return this.child.DesiredSize.Height;
            }

            switch (child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Bottom:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Center:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Stretch:
                    {
                        return AdornedElement.ActualHeight;
                    }
            }

            return 0.0;
        }

        private double DetermineWidth()
        {
            if (!Double.IsNaN(PositionX))
            {
                return this.child.DesiredSize.Width;
            }

            switch (child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Right:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Center:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Stretch:
                    {
                        return AdornedElement.ActualWidth;
                    }
            }

            return 0.0;
        }

        private double DetermineX()
        {
            switch (child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        if (horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -child.DesiredSize.Width + offsetX;
                        }
                        else
                        {
                            return offsetX;
                        }
                    }
                case HorizontalAlignment.Right:
                    {
                        if (horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            double adornedWidth = AdornedElement.ActualWidth;
                            return adornedWidth + offsetX;
                        }
                        else
                        {
                            double adornerWidth = this.child.DesiredSize.Width;
                            double adornedWidth = AdornedElement.ActualWidth;
                            double x = adornedWidth - adornerWidth;
                            return x + offsetX;
                        }
                    }
                case HorizontalAlignment.Center:
                    {
                        double adornerWidth = this.child.DesiredSize.Width;
                        double adornedWidth = AdornedElement.ActualWidth;
                        double x = (adornedWidth / 2) - (adornerWidth / 2);
                        return x + offsetX;
                    }
                case HorizontalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        private double DetermineY()
        {
            switch (child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        if (verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -child.DesiredSize.Height + offsetY;
                        }
                        else
                        {
                            return offsetY;
                        }
                    }
                case VerticalAlignment.Bottom:
                    {
                        if (verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            double adornedHeight = AdornedElement.ActualHeight;
                            return adornedHeight + offsetY;
                        }
                        else
                        {
                            double adornerHeight = this.child.DesiredSize.Height;
                            double adornedHeight = AdornedElement.ActualHeight;
                            double x = adornedHeight - adornerHeight;
                            return x + offsetY;
                        }
                    }
                case VerticalAlignment.Center:
                    {
                        double adornerHeight = this.child.DesiredSize.Height;
                        double adornedHeight = AdornedElement.ActualHeight;
                        double x = (adornedHeight / 2) - (adornerHeight / 2);
                        return x + offsetY;
                    }
                case VerticalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        #endregion Private Methods
    }
}