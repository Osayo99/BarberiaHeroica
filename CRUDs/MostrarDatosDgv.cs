using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    internal class MostrarDatosDgv
    {
        public DataTable MostrarDatos()
        {
            DB_Conexion connection = new DB_Conexion();
            string query = "SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero',tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio where fecha = convert(varchar, getdate(), 23);";
            SqlCommand command = new SqlCommand(query, connection.AbrirConexion());
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = command;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            connection.CerrarConexion();
            return dt;
        }

        public DataTable Historial()
        {
            DB_Conexion connection = new DB_Conexion();
            string query = "SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero',tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio";
            SqlCommand command = new SqlCommand(query, connection.AbrirConexion());
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = command;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            connection.CerrarConexion();
            return dt;
        }

        public DataTable MostrarPorID(int valor)
        {
            DB_Conexion connection = new DB_Conexion();
            string query = "SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero',tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio WHERE id_barbero = " +valor+ " AND fecha = convert(varchar, getdate(), 23);";
            SqlCommand command = new SqlCommand(query, connection.AbrirConexion());
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = command;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            connection.CerrarConexion();
            return dt;
        }

        public DataTable MostrarFechaEspecifica(string fecha)
        {
            DB_Conexion connection = new DB_Conexion();
            string query = "SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero',tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio where fecha = '" + fecha + "';";
            SqlCommand command = new SqlCommand(query, connection.AbrirConexion());
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = command;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            connection.CerrarConexion();
            return dt;
        }
    }
}
