using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        public System.Int32 ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String Last { get; set; }
        private System.Int32 ageStudent;
        public System.Int32 GenderStudent { get; set; } // 0-male, 1-female

        public Student() { }
        public Student(int id, string firstName, string last, int ageStudent, int genderStudent)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.Last = last;
            this.ageStudent = ageStudent;
            this.GenderStudent = genderStudent;
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
