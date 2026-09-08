using System.Collections.Generic;
using System.Windows;

namespace WPFDemo.Windows
{
    /// <summary>
    /// Interaction logic for ListBoxWindow.xaml
    /// </summary>
    public partial class ListBoxWindow : Window
    {
        public ListBoxWindow()
        {
            InitializeComponent();

            ListBoxNames.ItemsSource = new List<string>
            {
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Eve"
            };
        }
    }
}