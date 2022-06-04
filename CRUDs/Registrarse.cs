using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    internal class Registrarse
    {
        public static bool registrarse(AdministradorDB admin)
        {
            try
            {
                DB_Conexion conexion = new DB_Conexion();
                string query = "INSERT INTO administrador(usuario,telefono,contraseña) VALUES ('" + admin.Usuario + "','" + admin.Telefono + "','" + admin.Contraseña + "')";
                SqlCommand insertar = new SqlCommand(query, conexion.AbrirConexion());
                int i = insertar.ExecuteNonQuery();
                if (i != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
