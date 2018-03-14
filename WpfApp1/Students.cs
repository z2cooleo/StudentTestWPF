using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1
{
    public class Students : IEnumerable
    { 
        private List<Student> students;
        public Students()
        {
            students = new List<Student>();
        }

        public int Count
        {
            get { return students.Count; }
        }
        public Student this[int index]
        {
            get
            {
                return students[index];
            }
            set
            {
                students[index] = value;
            }
        }
        public void Add(Student student)
        {
            students.Add(student);
        }
        public void Remove(Student student)
        {
            students.Remove(student);
        }
        public void Edit(Student student)
        {
            students[student.ID].FirstName = student.FirstName;
            students[student.ID].Last = student.Last;
            students[student.ID].AgeStudent = student.AgeStudent;
            students[student.ID].GenderStudent = student.GenderStudent;
        }
        public void Remove(int indexStudentInstance)
        {
            students.RemoveAt(indexStudentInstance);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
}
