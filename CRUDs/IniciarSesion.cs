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
    internal class IniciarSesion
    {
        public static bool iniciar_sesion(AdministradorDB admin)
        {
            try
            {
                DB_Conexion conexion = new DB_Conexion();
                string query = "SELECT usuario, contraseña FROM administrador WHERE usuario='" + admin.Usuario + "' AND contraseña = '" + admin.Contraseña + "'";
                SqlCommand iniciar_sesion = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataReader dr = iniciar_sesion.ExecuteReader();

                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex);
                return false;
            }
        }
    }
}
