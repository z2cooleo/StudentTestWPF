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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Students st = new Students();
            //st.Add(new Student("Denis", "Makhortov", 31, 0));
            //st.Add(new Student("Maxim", "Hovor", 29, 0));

            //File.SetStudent(st, @"D:\OwnCloud\Dev\StudentTestWPF\WpfApp1\WpfApp1\students.xml");

            Students st = File.GetStudents(@"D:\OwnCloud\Dev\StudentTestWPF\WpfApp1\WpfApp1\students.xml");
        }
    }
}
