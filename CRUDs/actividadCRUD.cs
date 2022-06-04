using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH
{
    class actividadCRUD
    {
        public static DataTable listar()
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                SqlCommand llenarDgv = new SqlCommand("Select * from dbo.actividad", con.AbrirConexion());
                SqlDataReader dr = llenarDgv.ExecuteReader(CommandBehavior.CloseConnection);
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

        public static bool GuardarActividad(actividad e, string fechaG)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "INSERT INTO actividad VALUES ('" + e.NombreActividad1 + "','"
                    + e.Encargado1 + "', '" + e.Hora1 + "', '" + fechaG + "')";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.CerrarConexion();
                    return true;
                }
                else
                {
                    con.CerrarConexion();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ActualizarActividad(actividad e, string busquedaA, string busquedaE, string fechaEdit)
        {
            try
            {

                DB_Conexion con = new DB_Conexion();
                string sql = "UPDATE actividad SET NombreActividad ='" + e.NombreActividad1 + "', Encargado ='"
                    + e.Encargado1 + "', Hora ='" + e.Hora1 + "', Fecha ='" + e.Fecha1.ToString("yyyy-MM-dd") + "' WHERE NombreActividad = '" + busquedaA + "' AND Fecha = '" + Convert.ToDateTime(fechaEdit).ToString("yyyy-MM-dd") + "' AND Encargado = '" + busquedaE + "'";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.CerrarConexion();
                    return true;
                }
                else
                {
                    con.CerrarConexion();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool eliminar(string nombreEli, string nombreEncEli, string fechaEli)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "DELETE FROM actividad WHERE NombreActividad='" + nombreEli + "' AND (Encargado ='" + nombreEncEli + "' AND Fecha ='" + fechaEli + "')";
                //string sql = "DELETE FROM actividad WHERE NombreActividad='" + nombreEli + "' AND Fecha ='" + fechaEli + "'";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());

                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.CerrarConexion();
                    return true;
                }
                else
                {
                    con.CerrarConexion();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
