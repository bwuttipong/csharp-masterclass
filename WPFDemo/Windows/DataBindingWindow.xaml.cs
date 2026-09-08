using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemo.Data;

namespace WPFDemo.Windows
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBindingWindow : Window
    {
        /*
        Modes of Data Binding
        269. One-Way data binding
        270. Two Way Databinding
        271. One Way To Source Databinding
        272. One Time Databinding
        */
        Person person = new Person 
        { 
            Name = "John Doe", 
            Age = 30 
        };

        public DataBindingWindow()
        {

            this.DataContext = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string personData = $"Name: {person.Name}, Age: {person.Age}";
            MessageBox.Show(personData);
        }
    }
}