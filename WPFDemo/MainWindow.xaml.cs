using System.Windows;
using WPFDemo.Windows;

namespace WPFDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenDataBinding_Click(object sender, RoutedEventArgs e)
    {
        DataBindingWindow dataBindingWindow = new DataBindingWindow();
        dataBindingWindow.Show();
        // Or use ShowDialog() for modal window:
        // dataBindingWindow.ShowDialog();
    }

    private void OpenListBox_Click(object sender, RoutedEventArgs e)
    {
        ListBoxWindow listBoxWindow = new ListBoxWindow();
        listBoxWindow.Show();
    }
}