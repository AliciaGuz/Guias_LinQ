using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    public class Habitante
    {
        public int IdHabitante {  get; set; }
        public string Nombre { get; set;}
        public int edad {  get; set; }
        public int idCasa { get; set; }

        public string datosHabitante()
        {
            return $"Soy {Nombre} con edad de {edad} años vividos en {idCasa}";
        }
    }
}
