using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriatgePeces
{
    public class Peca
    {
        public string Tipus { get; set; }
        public double Area { get; set; }
        public DateTime Data{get; set;}
        public Peca(string tipus, double area)
        {
            Tipus = tipus;
            Area = area;
            Data = DateTime.Now;
        }
    }
}
