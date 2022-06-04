using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    class Cliente
    {
        
        public string Barbero { get; set; }

        public string Nombre { get; set; }

        public string Servicio { get; set; }

        public string Telefono { get; set; }

        public string Temperatura { get; set; }

        public DateTime Fecha { get; set; }

        public Cliente(string barbero, string nombre, string servicio, string telefono, string temperatura, DateTime fecha)
        {
            Barbero = barbero;
            Nombre = nombre;
            Servicio = servicio;
            Telefono = telefono;
            Temperatura = temperatura;
            Fecha = fecha;
        }
    }
}
