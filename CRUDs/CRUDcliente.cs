using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BarberH.clases;
using BarberH.conexion;

namespace BarberH.CRUDs
{
    class CRUDcliente
    {
        public static void AgregarCliente(Cliente cli)
        {
            DB_Conexion con = new DB_Conexion();
            string fechaCli = Convert.ToDateTime(cli.Fecha.Date).ToString("yyyy-MM-dd");
            string horacli = cli.Fecha.ToShortTimeString();
            string sql = "INSERT INTO cliente VALUES ('" + cli.Barbero + "', '" + cli.Nombre + "', '" + cli.Servicio + "', '" + cli.Telefono + "', '" + fechaCli + " " + horacli + "', '" + cli.Temperatura + "')";
            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@Clientebarbero", SqlDbType.VarChar).Value = cli.Barbero;
            //cmd.Parameters.Add("@Clientenombre", SqlDbType.VarChar).Value = cli.Nombre;
            //cmd.Parameters.Add("@Clienteservicio", SqlDbType.VarChar).Value = cli.Servicio;
            //cmd.Parameters.Add("@Clientetelefono", SqlDbType.VarChar).Value = cli.Telefono;
            //cmd.Parameters.Add("@Clientetemperatura", SqlDbType.VarChar).Value = cli.Temperatura;
            //string fechaCli = Convert.ToDateTime(cli.Fecha.Date).ToString("yyyy-MM-dd");
            //cmd.Parameters.Add("@Clientefecha", SqlDbType.DateTime).Value = fechaCli;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Cliente not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.CerrarConexion();
        }

        public static void ActualizarCliente(Cliente cli, string nom_cliente, string telf)
        {
            DB_Conexion con = new DB_Conexion();
            string fechaCli = Convert.ToDateTime(cli.Fecha.Date).ToString("yyyy-MM-dd");
            string horacli = cli.Fecha.ToShortTimeString();
            string sql = "UPDATE cliente SET barbero = '" + cli.Barbero + "', nombre = '" + cli.Nombre + "', servicio = '" + cli.Servicio + "', telefono = '" + cli.Telefono + "', fecha = '" + fechaCli + " " + horacli + "', temperatura = '" + cli.Temperatura + "' WHERE nombre = '" + nom_cliente + "' AND telefono =  '" + telf + "'";
            //string sql = "UPDATE INTO cliente SET barbero = '" + @Clientebarbero + "', nombre = '" + @Clientenombre + "', servicio = '" + @Clienteservicio + "' , telefono = '" + @Clientetelefono + "', temperatura = '" + @Clientetemperatura + "', fecha = '" + @Clientefecha + "' WHERE id_cliente = '" + @Clienteid_cliente
            
            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@Clienteid_cliente", SqlDbType.Int).Value = id_cliente;
            //cmd.Parameters.Add("@Clientebarbero", SqlDbType.VarChar).Value = cli.Barbero;
            //cmd.Parameters.Add("@Clientenombre", SqlDbType.VarChar).Value = cli.Nombre;
            //cmd.Parameters.Add("@Clienteservicio", SqlDbType.VarChar).Value = cli.Servicio;
            //cmd.Parameters.Add("@Clientetelefono", SqlDbType.VarChar).Value = cli.Telefono;
            //cmd.Parameters.Add("@Clientefecha", SqlDbType.DateTime).Value = cli.Fecha;
            //cmd.Parameters.Add("@Clientetemperatura", SqlDbType.VarChar).Value = cli.Temperatura;


            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Cliente not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.CerrarConexion();
        }

        public static void EliminarClientee(String id)
        {
            DB_Conexion con = new DB_Conexion();
            string sql = "DELETE FROM cliente WHERE id_cliente = @Clienteid_cliente";
            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Clienteid_cliente", SqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Cliente not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.CerrarConexion();
        }

        public static void BuscarCliente(string query, DataGridView dgv)
        {
            DB_Conexion con = new DB_Conexion();
            string sql = query;
            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.CerrarConexion();

        }
    }
}
