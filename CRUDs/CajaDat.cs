using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BarberH.clases;
using BarberH.conexion;
using System.Data;

namespace BarberH.CRUDs
{
    public class CajaDat
    {
        //SqlConnection conexion;

        //public CajaDat()
        //{
        //    conexion = new SqlConnection(DB_Conex);
        //}

        //ACTUALIZAR CAJA (el saldoTotal)
        public void UpdateCaja(Caja objCaja)
        {
            DB_Conexion con = new DB_Conexion();
            string update = "UPDATE Caja SET saldoTotal='" + objCaja.SaldoTotal+"'";
            SqlCommand unComando = new SqlCommand(update, con.AbrirConexion());
            unComando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        //BUSCAR 1 CAJA
        public bool SelectCaja(Caja objCaja)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                bool hayRegistros;
                string select = "SELECT * FROM Caja WHERE codCaja=" + objCaja.CodCaja + "";
                SqlCommand unComando = new SqlCommand(select, con.AbrirConexion());
                SqlDataReader registros = unComando.ExecuteReader();
                hayRegistros = registros.Read();
                if (hayRegistros)//Si es verdadero que hay registros
                {
                    objCaja.CodCaja = (int)registros[0] + "";
                    objCaja.SaldoTotal = (string)registros[2];
                    objCaja.Estado = 99;
                }
                else
                {
                    objCaja.Estado = 1;
                }
                con.CerrarConexion();
                return hayRegistros;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool SelectUltimaCaja(Caja objCaja)
        {
            DB_Conexion con = new DB_Conexion();
            bool hayRegistros;
            string select = "SELECT TOP 1 * FROM Caja order by codCaja desc";

            SqlCommand unComando = new SqlCommand(select, con.AbrirConexion());
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)//Si es verdadero que hay registros
            {
                objCaja.CodCaja = (int)registros[0] + "";
                objCaja.NombreCaja = (string)registros[1];
                objCaja.SaldoTotal = (string)registros[2];
                objCaja.Estado = 99;
            }
            else
            {
                objCaja.Estado = 1;
            }
            con.CerrarConexion();
            return hayRegistros;
        }
    }
}
