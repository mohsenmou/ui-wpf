using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mohsenmou.UI.WPF.Controls
{
   public class BadgedAdorner:Adorner
    {
        public BadgedAdorner(UIElement element) : base(element)
        {
            IsHitTestVisible = false;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var adornedElementRect = new Rect(AdornedElement.RenderSize);

            const int SIZE = 10;

            var right = adornedElementRect.Right;
            var left = right - SIZE;
            var top = adornedElementRect.Top;
            var bottom = adornedElementRect.Bottom - SIZE;

            var segments = new[]
            {
              new LineSegment(new Point(left, top), true),
              new LineSegment(new Point(right, bottom), true),
              new LineSegment(new Point(right, top), true)
           };

            var figure = new PathFigure(new Point(left, top), segments, true);
            var geometry = new PathGeometry(new[] { figure });
            drawingContext.DrawGeometry(Brushes.Blue, null, geometry);
        }
    }
}
