using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    public class horario
    {
        private string NombrePersona;
        private string HoraInicio;
        private string HoraFinal;
        private DateTime Fecha;

        public horario()
        {

        }

        public horario(string nombrePersona, string horaInicio, string horaFinal, DateTime fecha)
        {
            NombrePersona1 = nombrePersona;
            HoraInicio1 = horaInicio;
            HoraFinal1 = horaFinal;
            Fecha1 = fecha;
        }

        public string NombrePersona1 { get; set; }
        public string HoraInicio1 { get; set; }
        public string HoraFinal1 { get; set; }
        public DateTime Fecha1 { get; set; }
    }
}
