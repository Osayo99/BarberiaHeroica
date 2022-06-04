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
    class ProductoCRUD
    {
        public static DataTable listar()
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "SELECT * FROM producto;";
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

        public static bool eliminar(int id_producto)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "DELETE FROM producto where id_producto='" + id_producto + "'";

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

        public static bool GuardarProducto(Producto e)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string precuni = Convert.ToString(e.precio_unitario1).Replace(",", ".");
                string precmay = Convert.ToString(e.precio_mayorista1).Replace(",", ".");
                string sql = "INSERT INTO producto VALUES ('" + e.nombre_producto1 + "','"
                    + e.cant_existencia1 + "', '" + precuni + "', '" + precmay + "')";

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

        public static bool actualizar(Producto e)
        {
            try
            {
                string preciou = e.precio_unitario1.ToString();
                string preciom = e.precio_mayorista1.ToString();
                string preciouni = preciou.Replace(",", ".");
                string preciomay = preciom.Replace(",", ".");

                DB_Conexion con = new DB_Conexion();

                string sql = "UPDATE producto SET nombre_producto='" + e.nombre_producto1 + "',cant_existencia='" + e.cant_existencia1 + "',precio_unitario='" + preciouni + "',precio_mayorista='" + preciomay + "'  where id_producto='" + e.id_producto1 + "'";

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

        public static Producto buscar(int id_producto)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();

                string sqlBuscar = "SELECT * FROM producto WHERE id_producto LIKE '" + id_producto + "'";

                SqlCommand comandobuscar = new SqlCommand(sqlBuscar, con.AbrirConexion());

                SqlDataReader dr = comandobuscar.ExecuteReader(CommandBehavior.CloseConnection);

                Producto prd = new Producto();
                if (dr.Read())
                {

                    prd.id_producto1 = (int)dr["id_producto"];
                    prd.nombre_producto1 = dr["nombre_producto"].ToString();
                    prd.cant_existencia1 = (int)dr["cant_existencia"];
                    prd.precio_unitario1 = (decimal)dr["precio_unitario"];
                    prd.precio_mayorista1 = (decimal)dr["precio_mayorista"];
                    con.CerrarConexion();
                    return prd;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

        public static bool ActualizarProducto(Producto e, string id, string cantidadVent)
        {
            try
            {
                string precMay = Convert.ToString(e.precio_mayorista1).Replace(",", ".");
                string precUnit = Convert.ToString(e.precio_unitario1).Replace(",", ".");
                int cantidadRest = e.cant_existencia1 - Convert.ToInt32(cantidadVent);
                DB_Conexion con = new DB_Conexion();
                string sql = "UPDATE producto SET nombre_producto ='" + e.nombre_producto1
                     + "', cant_existencia ='" + cantidadRest + "', precio_unitario = " + precUnit + ", precio_mayorista = " + precMay + " WHERE id_producto = '" + id + "'";
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
        public static bool ActualizarProducto2(string id, string cantidadMas)
        {
            try
            {
                DB_Conexion con = new DB_Conexion();
                string sql = "UPDATE producto SET cant_existencia =" + "cant_existencia +" + cantidadMas + " WHERE id_producto = '" + id + "'";
                SqlCommand comando = new SqlCommand(sql, con.AbrirConexion());
                int cantidad2 = comando.ExecuteNonQuery();
                if (cantidad2 == 1)
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
