using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEvaluable2
{
    public class Admin : UserBase
    {
        public string Department { get; set; }

        public Admin(int id, string name, string mail, string department) : base(id, name, mail)
        {
            Department = department;
        }

        public override UserType GetUserType()
        {
            return UserType.Admin;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Department,10}";
        }

        public override string GetDetails()
        {
            return ToString();
        }

        public override Admin Clone()
        {
            return new Admin(Id, Name, Mail, Department);
        }
    }
}
