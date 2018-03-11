using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        public System.String firstName { get; set; }
        public System.String lastName { get; set; }
        private System.Int32 ageStudent;
        public System.Int32 genderStudent { get; set; } // 0-male, 1-female

        public Student() { }
        public Student(string firstName, string lastName, int ageStudent, int genderStudent)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ageStudent = ageStudent;
            this.genderStudent = genderStudent;
        } 
        
        public int AgeStudent
        {
            get { return ageStudent; }
            set
            {
                if (value >= 16 && value <= 100)
                {
                    this.ageStudent = value;
                }
            }
        }
    }
}
