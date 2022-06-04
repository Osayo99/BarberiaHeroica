using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    class CajaDiariaCRUD
    {
        public static string mostrar(string fecha)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "SELECT caja_inicial FROM caja_diaria WHERE fecha = '" + fecha + "'";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());
                string caja = comando.ExecuteScalar().ToString();
                con.CerrarConexion();
                return caja;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool actualizar(CajaDiaria e, string fecha)
        {
            try
            {
              
                DB_Conexion con = new DB_Conexion();

                string sql = "UPDATE caja_diaria SET caja_final='" + e.Caja_final + "WHERE fecha = '" + fecha + "'";

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

        public static bool GuardarCajaDiaria(CajaDiaria e)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                double caja_inicial = Convert.ToDouble(e.Caja_inicial);
                double caja_finl = Convert.ToDouble(e.Caja_final);
                string fecha = e.Fecha;

                string sql = "INSERT INTO caja_diaria VALUES ('" + e.Caja_inicial + "', '" + e.Caja_final + "', '" + e.Fecha + "')";
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
        public static bool eliminar(int id_caja)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "DELETE FROM caja_diaria where id_caja='" + id_caja + "'";

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
