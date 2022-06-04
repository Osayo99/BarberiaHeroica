using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    internal class Servicio
    {
        private int id_barbero;
        private string nombre_barbero;
        private string tipo_servicio;
        private string fecha;
        private decimal precio;

        public int Id_barbero { get => id_barbero; set => id_barbero = value; }
        public string Nombre_barbero { get => nombre_barbero; set => nombre_barbero = value; }
        public string Tipo_servicio { get => tipo_servicio; set => tipo_servicio = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
