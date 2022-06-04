using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BarberH.clases
{
    internal class AdministradorDB
    {
        private int id_administrador;
        private string nombre;
        private string apellido;
        private string telefono;
        private string genero;
        private string ciudad;
        private string contraseña;
        private string usuario;
        private int id_control;

        public int Id_administrador { get => id_administrador; set => id_administrador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public int Id_control { get => id_control; set => id_control = value; }
    }
}
