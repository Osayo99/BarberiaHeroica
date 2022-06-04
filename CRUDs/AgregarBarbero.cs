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
    internal class AgregarBarbero
    {
        public static bool RegistrarBarbero(Barbero barbero)
        {
            try
            {
                DB_Conexion connection = new DB_Conexion();
                string query = "INSERT INTO barbero(nombre, apellido, telefono, genero, ciudad) VALUES ('" + barbero.Nombre + "','" + barbero.Apellido + "','" + barbero.Telefono + "','" + barbero.Genero + "','" + barbero.Ciudad + "');";
                SqlCommand insertar = new SqlCommand(query, connection.AbrirConexion());
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
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return false;
            }
            finally
            {
                DB_Conexion connection = new DB_Conexion();
                connection.CerrarConexion();
            }
        }
    }
}
