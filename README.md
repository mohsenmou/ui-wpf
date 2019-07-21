# ui-wpf
A library of reusable styles, themes, icons, controls, and other UI helpers.

Installation

You can install Mohsenmou.UI.WPF via the NuGet GUI (right click on your project, click Manage NuGet Packages, select Browse and search for Mohsenmou.UI.WPF) or with the Package Manager Console:
PM> Install-Package Mohsenmou.UI.WPF

Styling the Window

After installing of Mohsenmou.UI.WPF:
	1. Open MainWindow.xaml
	2. Add this attribute inside the opening Window tag. (It’s how you reference other namespaces in XAML):
	   xmlns:mohsenmou="https://github.com/mohsenmou/ui-wpf"
	   or
	   xmlns:controls="clr-namespace:Mohsenmou.UI.WPF.Controls;assembly=Mohsenmou.UI.WPF"
	3. Set style of MainWindow to Style="{DynamicResource MainWindowStyle}"

Using Built-In Styles

All of Mohsenmou.UI.WPF’s resources are contained within separate resource dictionaries. In order for most of the controls to adopt the Mohsenmou.UI.WPF theme, you will need to add the following ResourceDictionary to your App.xaml.
	
<Application x:Class="Dev.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Mohsenmou.UI.WPF;component/Themes/Mohsenmou.UI.WPF.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>