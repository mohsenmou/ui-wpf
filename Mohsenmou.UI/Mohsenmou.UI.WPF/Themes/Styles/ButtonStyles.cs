using System.Windows;
using System.Windows.Controls;

namespace Mohsenmou.UI.WPF
{
    public partial class ButtonStyles:ResourceDictionary
    {
        public ButtonStyles()
        {
            InitializeComponent();
        }
        private void OnClearTextClick(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)((FrameworkElement)sender).TemplatedParent;
            if (textbox!=null)
            {
                if (!string.IsNullOrEmpty(textbox.Text))
                {
                    textbox.Text = string.Empty;
                }
            }
        }
    }
}
