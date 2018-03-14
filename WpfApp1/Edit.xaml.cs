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
using System.Windows.Shapes;

namespace WpfApp1
{
    enum Gender
    {
        male,
        female
    }
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Boolean allowSetStudent;
        Student student;        

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(Student student) : this()
        {
            this.student = student;
            firstName.Text = student.FirstName;
            last.Text = student.Last;
            age.Text = student.AgeStudent.ToString();
            gender.TabIndex = student.GenderStudent;
        }

        private void ErrorMessage(TextBox name)
        {
            if (name == age) name.Text = "Допускается от 16 до 100";
            else name.Text = "Введите данные";

            var bc = new BrushConverter();
            name.Background = (Brush)bc.ConvertFrom("#ffafaf");

            allowSetStudent = false;
        }
        private void ClearMessage(TextBox name)
        {
            if (name.Text == "Введите данные" || name.Text == "Допускается от 16 до 100")
            {
                name.Text = "";
                name.Background = Brushes.White;
            }
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            allowSetStudent = true;
            if (student == null)
            {
                student = new Student();
                student.ID = -1;
            }

            if (firstName.Text != "") student.FirstName = firstName.Text;
            else ErrorMessage(firstName);
            if (last.Text != "") student.Last = last.Text;
            else ErrorMessage(last);
            if (age.Text != "")
            {
                int ageStud;
                Int32.TryParse(age.Text, out ageStud);
                if (ageStud > 15 & ageStud < 101)
                {
                    student.AgeStudent = ageStud;
                }
                else ErrorMessage(age);
            }
            else ErrorMessage(age);
            student.GenderStudent = gender.Text == Gender.female.ToString() ? 1 : 0;

            if (allowSetStudent)
            {
                MainWindow mw = new MainWindow(student);
                mw.Show();
                Close();
            }
        }
        private void firstName_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearMessage(firstName);
        }

        private void last_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearMessage(last);
        }

        private void age_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearMessage(age);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
        
    }
}
