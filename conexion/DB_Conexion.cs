using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberH.conexion
{
    class DB_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("data source = DESKTOP-KV5MT4I\\SQLEXPRESS; initial catalog = BarberH; user id = administrador; password = administrador");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public bool CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return true;
        }
    }
}
