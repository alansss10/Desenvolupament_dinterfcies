using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace PracticaEvaluable2
{
    public class UsersRepository
    {
        private static int NextId = 0;
        private static UsersRepository Instance;
        private List<UserBase> Users;

        private UsersRepository() {    
            Users = new List<UserBase>();
        }

        public static UsersRepository GetInstance() {
            if (Instance == null) {
                Instance = new UsersRepository();
            }
            return Instance;
        }

        public int GetNextUserId() { 
            return ++NextId;
        }

        public void Add(UserBase user) {
            Users.Add(user);
        }

        public bool Update(UserBase user)
        {
            var old = Users.Find(u => u.Id == user.Id);

            if (old != null)
            {
                if (user.GetUserType() == UserType.Admin)
                {
                    Update((Admin)old, (Admin)user);
                }
                if (user.GetUserType() == UserType.Student)
                {
                    Update((Student)old, (Student)user);
                }
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            Users.RemoveAll(u => u.Id == id);
        }

        public UserBase? GetById(int userId)
        {
            return (UserBase?)(Users.Find(u => u.Id == userId)?.Clone());
        }

        public List<UserBase> GetAll() { 
            return Users; 
        }

        public List<UserBase> GetAdmins() {
            return Users.Where(u => u.GetUserType() == UserType.Admin).ToList();
        }

        public List<UserBase> GetStudents()
        {
            return Users.Where(u => u.GetUserType() == UserType.Student).ToList();
        }

        private void Update(Admin old, Admin updated)
        {
            old.Name = updated.Name;
            old.Mail = updated.Mail;
            old.Department = updated.Department;
        }

        private void Update(Student old, Student updated)
        {
            old.Name = updated.Name;
            old.Mail = updated.Mail;
            old.Course = updated.Course;
        }
    }
}
