using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using BarberH.clases;
using BarberH.conexion;
using System.Data;

namespace BarberH.CRUDs
{
    internal class AgregarDatosServicio
    {
        public static bool AgregarDatos(Servicio servicio)
        {
            try
            {
                DB_Conexion connection = new DB_Conexion();
                string query = "INSERT INTO servicio(id_barbero, nombre_barbero, tipo_servicio, fecha, precio) VALUES ('" + servicio.Id_barbero + "','" + servicio.Nombre_barbero + "','" + servicio.Tipo_servicio + "','" + servicio.Fecha + "','" + servicio.Precio.ToString().Replace(",",".") + "');";
                SqlCommand insertar = new SqlCommand(query, connection.AbrirConexion());
                int i = insertar.ExecuteNonQuery();
                if(i != 0)
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

        public static DataTable listar(string fecha)
        {
            try
            {
                
                DB_Conexion con = new DB_Conexion();
                string sql = "SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero',tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio where fecha = '" + Convert.ToDateTime(fecha).ToString("yyyy-MM-dd") + "'";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());
                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);


                DataTable dt = new DataTable();
                dt.Load(dr);
                con.CerrarConexion();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
