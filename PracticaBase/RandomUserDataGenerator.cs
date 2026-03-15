using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEvaluable2
{
    using System;
    using System.Collections.Generic;
    public class RandomUserDataGenerator
    {
        private static Random random = new Random();

        private static List<string> names = new List<string>
            {
                "John", "Mary", "James", "Jennifer", "Robert", "Linda", "Michael", "Elizabeth",
                "David", "Patricia", "William", "Susan", "Joseph", "Jessica", "Charles", "Sarah",
                "Thomas", "Karen", "Christopher", "Nancy", "Daniel", "Betty", "Matthew", "Margaret",
                "Anthony", "Sandra", "Mark", "Ashley", "Donald", "Kimberly", "Steven", "Emily",
                "Paul", "Sharon", "Andrew", "Cynthia", "Joshua", "Helen", "Kevin", "Deborah",
                "Brian", "Rachel", "Timothy", "Dorothy", "Jason", "Laura", "Brian", "Angela",
                "Jacob", "Kim", "Gary", "Diana", "Tina", "Eric", "Grace", "Benjamin", "Helen",
                "Nicholas", "Amanda", "Gregory", "Judy", "Henry", "Brenda", "Frank", "Nicole",
                "Tracy", "Jack", "Janet", "George", "Martha", "Kyle", "Alicia", "Walter", "Holly",
                "Ethan", "Debbie", "Steven", "Jessica", "Tyler", "Catherine", "Jeffrey", "Terry",
                "Todd", "Melanie", "Kyle", "Vanessa", "Raymond", "Pamela", "Shawn", "Clara",
                "Dennis", "Julia", "Barry", "Katie", "Arthur", "Emily", "Leonard", "Carmen",
                "Wayne", "Isabelle", "Gary", "Paula", "Alan", "Carol", "Fred", "Ruth", "Scott",
                "Megan", "Roger", "Ava", "Samuel", "Victoria", "Cheryl", "Sophia", "Vincent",
                "Isabella", "Daniela", "Lindsay", "Derek", "Rita", "Beverly", "Jill"
            };

        private static List<string> surnames = new List<string>
         {
                "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson",
                "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin",
                "Thompson", "Garcia", "Martinez", "Roberts", "Lee", "Walker", "Hall", "Allen",
                "Young", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Adams", "Baker",
                "Nelson", "Carter", "Mitchell", "Perez", "Robinson", "Lewis", "Evans", "Clark",
                "Morris", "Ward", "Collins", "Murphy", "Rivera", "Cook", "Rogers", "Morgan",
                "Cooper", "Reed", "Bailey", "Gomez", "James", "Hernandez", "Kim", "Gonzalez",
                "Murray", "Fox", "Riley", "Patterson", "Sullivan", "Butler", "Foster", "Sanders",
                "Graham", "Stewart", "Perez", "Chavez", "Mendoza", "Ford", "Woods", "Dickson",
                "Hudson", "Shaw", "Simpson", "Wallace", "Burns", "Fisher", "Gibson", "George",
                "Vasquez", "Michaels", "Simmons", "Austin", "Jameson", "Wagner", "Davidson",
                "Gordon", "Douglas", "Harrison", "Hughes", "Bryant", "Griffin", "Wells", "Chavez",
                "Austin", "Freeman", "Jenkins", "Perry", "Russell", "Hunter", "Curtis", "Cameron",
                "Bishop", "Snyder", "Fowler", "Henderson", "Hamilton", "Day", "Greene", "Robertson"
            };

        private static List<string> courses = new List<string> { "DAM", "ASIX", "CETI" };


        public static string GetRandomName()
        {
            string nombre = names[random.Next(names.Count)];
            string apellido = surnames[random.Next(surnames.Count)];
            return $"{nombre} {apellido}";
        }

        public static string NameToMail(string name)
        {
            return $"{name.Replace(" ", ".").ToLower()}@xtec.cat";
        }

        public static string NameToCourse(string name)
        {
            return courses[Math.Abs(name.GetHashCode()) % courses.Count];
        }
    }
}
