using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BarberH.clases
{
    public class actividad
    {
        private string NombreActividad;
        private string Encargado;
        private string Hora;
        private DateTime Fecha;

        public actividad()
        {

        }

        public actividad(string NombreActividad, string Encargado, string Hora, DateTime Fecha)
        {
            this.NombreActividad1 = NombreActividad;
            this.Encargado1 = Encargado;
            this.Hora1 = Hora;
            this.Fecha1 = Fecha;
        }

        public string NombreActividad1 { get; set; }
        public string Encargado1 { get; set; }
        public string Hora1 { get; set; }
        public DateTime Fecha1 { get; set; }
    }
}
