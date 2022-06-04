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
    public class MovimientoDat
    {
        //SqlConnection conexion;
        //public MovimientoDat()
        //{
        //    conexion = new SqlConnection(ConexionBD);
        //}

        //INSERTAR 1 movimiento (ingreso o egreso)
        public void InsertMovimiento(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string Insertar = "INSERT Movimiento(tipoMovimiento, monto, descripcion, fecha, codCaja) VALUES('" + objMov.Tipo + "', '" + objMov.Monto + "','" + objMov.Descripcion + "','"+objMov.Fecha+"',"+objMov.CodCaja+")";
            SqlCommand unComando = new SqlCommand(Insertar, con.AbrirConexion());
            unComando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        //ACTUALIZAR 1 movimiento(ingreso o egreso)
        public void UpdateMovimiento(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string update = "UPDATE Movimiento SET monto='" + objMov.Monto + "', descripcion='"+objMov.Descripcion+"' WHERE codMovimiento="+objMov.CodMovimiento+"";
            SqlCommand unComando = new SqlCommand(update, con.AbrirConexion());
            unComando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        //ELIMINAR 1 movimiento (ingreso o egreso)
        public void DeleteMovimiento(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string Delete = "DELETE Movimiento WHERE codMovimiento = " + objMov.CodMovimiento + "";

            SqlCommand unComando = new SqlCommand(Delete, con.AbrirConexion());
            unComando.ExecuteNonQuery();
            con.CerrarConexion();
        }

        //BUSCAR 1 movimiento (ingreso o egreso) 
        public bool SelectMovimiento(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            bool hayRegistros;
            string select = "SELECT * FROM Movimiento WHERE codMovimiento =" + objMov.CodMovimiento + "";
            SqlCommand unComando = new SqlCommand(select, con.AbrirConexion());
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            if (hayRegistros)//Si es verdadero que hay registros
            {
                objMov.CodMovimiento = (int)registros[0] + "";
                objMov.Tipo = (string)registros[1];
                objMov.Monto = (string)registros[2];
                objMov.Descripcion = (string)registros[3];
                objMov.Fecha = (string)registros[4] + "";                
                objMov.Estado = 99;
            }
            else
            {
                objMov.Estado = 1;
            }
            con.CerrarConexion();
            return hayRegistros;
        }

        //MOSTRAR TODOS LOS INGRESOS Búsqueda POR FECHA
        public DataTable SelectMovimientoIngresosPorFecha(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (+)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod' FROM Movimiento WHERE tipoMovimiento = 'Ingreso' AND fecha='" + objMov.Fecha + "'";
            DataTable dsMovimientoIngreso = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimientoIngreso);
            return dsMovimientoIngreso;
        }

        //MOSTRAR TODOS LOS EGRESOS Búsqueda POR FECHA
        public DataTable SelectMovimientoEgresosPorFecha(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (-)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod' FROM Movimiento WHERE tipoMovimiento = 'Egreso' AND fecha='" + objMov.Fecha + "'";
            DataTable dsMovimientoIngreso = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimientoIngreso);
            return dsMovimientoIngreso;
        }

        //MOSTRAR TODOS LOS Movimientos Búsqueda POR FECHA
        public DataTable SelectMovimientosPorFecha(Movimiento objMov)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (+/-)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod'  FROM Movimiento WHERE fecha='" + objMov.Fecha + "'";
            DataTable dsMovimientoIngreso = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimientoIngreso);
            return dsMovimientoIngreso;
        }
        //MES Ingresos
        public DataTable SelectMovimientoIngresosPorMes(string fec)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (+)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod' FROM Movimiento where fecha like '%/" + fec + "/%' AND tipoMovimiento='Ingreso'";
            DataTable dsMovimiento = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimiento);
            return dsMovimiento;
        }
        //Mes Egresos
        public DataTable SelectMovimientoEgresosPorMes(string fec)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (-)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod' FROM Movimiento where fecha like '%/" + fec + "/%' AND tipoMovimiento='Egreso'";
            DataTable dsMovimiento = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimiento);
            return dsMovimiento;
        }
        //MES Movimientos
        public DataTable SelectMovimientosPorMes(string fec)
        {
            DB_Conexion con = new DB_Conexion();
            string select = "SELECT  monto as 'Monto (+/-)', descripcion as 'Descripción',fecha as 'Fecha', tipoMovimiento as 'Movimiento', codMovimiento as 'Cod' FROM Movimiento where fecha like '%/" + fec + "/%'";
            DataTable dsMovimiento = new DataTable();
            SqlDataAdapter unComando = new SqlDataAdapter(select, con.AbrirConexion());
            unComando.Fill(dsMovimiento);
            return dsMovimiento;
        }

        //ULTIMO COD Caja registrado
        public string SelectUltimaCaja()
        {
            DB_Conexion con = new DB_Conexion();
            bool hayRegistros;
            string select = "SELECT top 1 codCaja FROM Caja order by codCaja desc";
            SqlCommand unComando = new SqlCommand(select, con.AbrirConexion());
            SqlDataReader registros = unComando.ExecuteReader();
            hayRegistros = registros.Read();
            string r = ""; ;
            if (hayRegistros)//Si es verdadero que hay registros
            {

                r = (int)registros[0] + "";

            }

            con.CerrarConexion();
            return r;
        }

    }
}
