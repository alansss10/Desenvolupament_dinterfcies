using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEvaluable2
{
    public class Student : UserBase
    {
        public string Course { get; set; }

        public Student(int id, string name, string mail, string course) : base(id, name, mail)
        {
            Course = course;
        }

        public override UserType GetUserType()
        {
            return UserType.Student;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Course,10}";
        }

        public override string GetDetails()
        {
            return ToString();
        }

        public override Student Clone()
        {
            return new Student(Id, Name, Mail, Course);
        }
    }
}
