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
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    enum Gender{
        male,
        female
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Students students;
        public MainWindow()
        {
            students = File.GetStudents(@"G:\Dev\C#\StudentTestWPF\WpfApp1\students1.xml");
            InitializeComponent();
        }
        private void Init(object sender, EventArgs e)
        {
            StudentsDataGrid.ItemsSource = students;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Student st = StudentsDataGrid.SelectedItem as Student;
            if (st != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to remove this row?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    students.Remove(st);
                    StudentsDataGrid.ItemsSource = null;
                    StudentsDataGrid.ItemsSource = students;
                    File.SetStudent(students, @"G:\Dev\C#\StudentTestWPF\WpfApp1\students1.xml");
                }
            }
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            changeInstance setPage = new changeInstance();
            this.Content = setPage;
        }
    }
    public class AddConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
               object parameter, System.Globalization.CultureInfo culture)
        {
            return values[0].ToString() + " " + values[1].ToString();
        }
        public object Convert(object values, Type targetType,
       object parameter, System.Globalization.CultureInfo culture)
        {
            return values.ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString())
            {
                case "0": return "Male";
                case "1": return "Female";              
            }
            return "1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String age = value.ToString();
            switch (age[age.Length - 1])
            {
                case '0':
                case '1':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': return age + " лет";
                case '2':
                case '3':
                case '4': return age + " года";
            }
            return "2";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
