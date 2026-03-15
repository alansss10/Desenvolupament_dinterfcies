using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEvaluable2
{
    public abstract class UserBase : ICloneable
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public UserBase(int id, string name, string mail)
        {
            Id = id;
            Name = name;
            Mail = mail;
        }

        public abstract UserType GetUserType();

        public abstract string GetDetails();

        public override string ToString()
        {
            return $"{Id,-10}" + $"{Name,-25}" + $"{Mail,-30}";
        }

        public abstract Object Clone();
    }

    public enum UserType { Student, Admin }
}
