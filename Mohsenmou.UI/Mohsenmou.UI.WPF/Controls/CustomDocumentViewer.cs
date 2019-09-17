using System.Windows;
using System.Windows.Controls;

namespace Mohsenmou.UI.WPF.Controls
{
    public class CustomDocumnetViewer : DocumentViewer
    {
        static CustomDocumnetViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDocumnetViewer),
                                                     new FrameworkPropertyMetadata(typeof(CustomDocumnetViewer)));
        }
    }
}
