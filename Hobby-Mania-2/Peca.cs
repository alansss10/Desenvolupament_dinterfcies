using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Mania_2
{
    internal class Peca
    {
        // El tipus guarda el tipo de figura triangulo cuadrado circulo...
        // data guarda la fecha y la hora 
        // creamos constructor 
        // DateTime.Now → pone automáticamente la fecha y hora actual
        public string Tipus { get; set; }
        public DateTime Data { get; set; }

        public Peca(string tipus)
        {
            Tipus = tipus;
            Data = DateTime.Now;
        }
    }
}
