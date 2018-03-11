using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp1
{
    static public class File
    {
        static public Students GetStudents(string path)
        {
            Students students = new Students();

            XmlDataDocument xmldoc = new XmlDataDocument();
            FileStream fs = new FileStream(@"D:\OwnCloud\Dev\StudentTestWPF\WpfApp1\WpfApp1\students.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            XmlNodeList xmlnodes = xmldoc.GetElementsByTagName("Student");
            foreach (XmlNode xn in xmlnodes)
            {
                Student student = new Student();
                foreach (XmlNode node in xn.ChildNodes)
                {
                    switch (node.Name.ToString())
                    {
                        case "FirstName":
                            student.firstName = node.InnerText; break;
                        case "LastName":
                            student.lastName = node.InnerText; break;
                        case "Age":
                            student.AgeStudent = Int32.Parse(node.InnerText); break;
                        case "Gender":
                            student.genderStudent = Int32.Parse(node.InnerText); break;
                    }
                }
                students.Add(student);                
            }
            return students;
        }
        static public void SetStudent(Students students, string path)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.IndentChars = "\t";
            xmlWriterSettings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create( path, xmlWriterSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Students");

                for(int i = 0; i < students.Count; i++)
                {
                    writer.WriteStartElement("Student");
                    writer.WriteAttributeString("ID", i.ToString());
                    writer.WriteElementString("FirstName", students[i].firstName);
                    writer.WriteElementString("LastName", students[i].lastName);
                    writer.WriteElementString("Age", students[i].AgeStudent.ToString());
                    writer.WriteElementString("Gender", students[i].genderStudent.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
