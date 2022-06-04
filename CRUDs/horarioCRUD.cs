using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    class horarioCRUD
    {
        
        public static DataTable listar()
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                SqlCommand llenarDgv = new SqlCommand("Select * from dbo.horario", con.AbrirConexion());
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

        public static bool GuardarHorario(horario e, string fechaG)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "INSERT INTO horario VALUES ('" + e.NombrePersona1 + "','"
                    + e.HoraInicio1 + "', '" + e.HoraFinal1 + "', '" + fechaG + "')";
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
        public static bool ActualizarHorario(horario e, string busqueda, string fechaEdit)
        {
            try
            {

                DB_Conexion con = new DB_Conexion();
                string sql = "UPDATE horario SET NombrePersona ='" + e.NombrePersona1 + "', HoraInicio ='"
                    + e.HoraInicio1 + "', HoraFinal ='" + e.HoraFinal1 + "', Fecha ='" + e.Fecha1.ToString("yyyy-MM-dd") + "' WHERE NombrePersona = '" + busqueda + "' AND Fecha = '" + fechaEdit +"'";
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
        public static bool eliminar(string nombreEli, string fechaEli)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "DELETE FROM horario where NombrePersona='" + nombreEli + "' AND Fecha ='" + fechaEli + "'";
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
