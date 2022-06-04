using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.clases
{
    internal class Barbero
    {
        private int id_barbero;
        private string nombre;
        private string apellido;
        private string telefono;
        private string genero;
        private string ciudad;

        public int Id_barbero { get => id_barbero; set => id_barbero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
    }
}
