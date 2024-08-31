using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    public class Casa
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int numeroHabitaciones {  get; set; }
        public string dameDatosCasa() {
            return $"Direccion es {Direccion} en la cuidad {Ciudad} con numero de habitaciones de {numeroHabitaciones}";
                }


    }
}
