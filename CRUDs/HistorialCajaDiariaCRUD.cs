using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    class HistorialCajaDiariaCRUD
    {
        public static bool GuardarHistorial(HistorialCajaDiaria e)
        {
            try
            {


                string IngresoTotalCorte = Convert.ToString(e.Ingresototalporcorte).Replace(",", ".");
                string OtrosIngresos = Convert.ToString(e.Otros_ingresos).Replace(",", ".");
                string CajaInicial = Convert.ToString(e.Caja_inicial).Replace(",", ".");
                string TotalIngresos = Convert.ToString(e.Total_ingresos).Replace(",", ".");
                string ComisionGeneral = Convert.ToString(e.Comision_general).Replace(",", ".");
                string Descuentos = Convert.ToString(e.Descuentos).Replace(",", ".");
                string TotalEgresos = Convert.ToString(e.Total_egresos).Replace(",", ".");
                string Liquido = Convert.ToString(e.Liquido).Replace(",", ".");
                string AbonofondoGeneral = Convert.ToString(e.Abonofondo_general).Replace(",", ".");
                string CierreCaja = Convert.ToString(e.Cierre_caja).Replace(",", ".");
                string Fecha = e.Fecha.ToString("yyyy-MM-dd");
                DB_Conexion con = new DB_Conexion();
                string sql = "INSERT INTO historial_cajadiaria VALUES ('" + IngresoTotalCorte + "', '" + OtrosIngresos + "', '" + CajaInicial + "','" + TotalIngresos + "', '" + ComisionGeneral + "', '" + Descuentos + "', '" + TotalEgresos + "', '" + Liquido + "', '" + AbonofondoGeneral + "', '" + CierreCaja + "', '" + Fecha + "')";
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
    }
}
