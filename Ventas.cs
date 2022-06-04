using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using BarberH.clases;
using BarberH.CRUDs;
using BarberH.conexion;
using Microsoft.Reporting.WinForms;

namespace BarberH
{
    public partial class Ventas : Form
    {
        public string precMay;
        public Ventas()
        {
            InitializeComponent();
            mostrarGrid();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;

        }
        public void mostrarGrid()
        {
            DataTable productos = ProductoCRUD.listar();
            if (productos == null)
            {
                MessageBox.Show("No se logró acceder a los datos de la base de datos");
            }
            else
            {
                dataGridView1.DataSource = productos;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                string strFila = Row.Index.ToString();
                dataGridView1.Rows[Int32.Parse(strFila)].Selected = false;
                string valor = Convert.ToString(Row.Cells["nombre_producto"].Value);

                if (valor.Contains(this.txtBuscar.Text))
                {
                    dataGridView1.Rows[Int32.Parse(strFila)].Selected = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //string idprov = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    if (txtCantidad.Text == "")
                    {
                        txtCantidad.Text = "1";
                    }
                    int cantidadExist = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
                    int cantidadVent = Convert.ToInt32(txtCantidad.Text);
                    if ((cantidadExist) < (cantidadVent))
                    {
                        MessageBox.Show("No hay cantidad suficiente en el inventario");
                        Convert.ToInt32(nombre);
                    }
                    if (Convert.ToInt32(cantidadExist) < 5 && Convert.ToInt32(cantidadExist) != 0 && Convert.ToInt32(cantidadExist) > 0)
                    {
                        MessageBox.Show("Este producto esta por debajo del limite en el inventario");
                    }
                    if (Convert.ToInt32(cantidadExist) <= 0)
                    {
                        txtCantidad.Text = "";
                        MessageBox.Show("Ya no hay de este producto en inventario");
                        Convert.ToInt32(nombre);
                    }

                    string precUni = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    decimal precMay = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);

                    Producto venta = new Producto(Int32.Parse(id), nombre, cantidadExist, Decimal.Parse(precUni), precMay);
                    ProductoCRUD.ActualizarProducto(venta, id, cantidadVent.ToString());
                    mostrarGrid();
                    decimal totalProducto = venta.precio_unitario1 * Convert.ToDecimal(cantidadVent);
                    dataGridView2.Rows.Add(venta.id_producto1, venta.nombre_producto1, cantidadVent, venta.precio_unitario1, totalProducto);
                    dataGridView2.Rows[0].Selected = true;
                    contar();
                    txtCantidad.Text = ""; 
                }
                else
                {
                    MessageBox.Show("No hay ningun producto en el inventario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int celda = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[celda].Selected = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {
                string strFila = Row.Index.ToString();
                dataGridView1.Rows[Int32.Parse(strFila)].Selected = true;
                string id = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value);
                string cantidad = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[2].Value);
                ProductoCRUD.ActualizarProducto2(id, cantidad);
                mostrarGrid();
            }
            dataGridView2.Rows.Clear();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int celda = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows[celda].Selected = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                string id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string cantidad = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                ProductoCRUD.ActualizarProducto2(id, cantidad);
                mostrarGrid();
                string numFilas = dataGridView2.RowCount.ToString();
                if (Int32.Parse(numFilas) > 0)
                {
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                    contar();
                } 
            }
            else
            {
                MessageBox.Show("No ha añadido ningun producto");
            }

        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        public void contar()
        {
            decimal Sumatoria = 0;
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {
                Sumatoria += Convert.ToDecimal(Row.Cells[4].Value);
            }
            txtTotalVenta.Text = Sumatoria.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string descuento = txtDescuento.Text;
                if (descuento != "" || descuento != null)
                {
                    descuento.Replace(".", ",");
                    if (txtDescuento.Text == "")
                    {
                        txtDescuento.Text = "0";
                    }
                    txtTotalFinal.Text = (double.Parse(txtTotalVenta.Text) - double.Parse(txtDescuento.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese datos numericos");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string descuento = txtDescuento.Text;
                if (descuento != "" || descuento != null)
                {
                    if (txtDescuento.Text == "")
                    {
                        txtDescuento.Text = "0";
                    }
                    decimal valorFinal = Convert.ToDecimal(txtTotalVenta.Text) - Convert.ToDecimal(descuento.Replace(".", ","));
                    txtTotalFinal.Text = valorFinal.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese datos numericos");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string recibido = txtRecibido.Text;
                if (recibido != "" || recibido != null)
                {
                    if (txtRecibido.Text == "")
                    {
                        txtRecibido.Text = "0";
                    }
                    decimal cambio = Convert.ToDecimal(txtTotalFinal.Text) - Convert.ToDecimal(recibido.Replace(".", ","));
                    txtCambio.Text = cambio.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese el monto recibido");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string recibido = txtRecibido.Text;
                if (recibido != "" || recibido != null)
                {
                    if (txtRecibido.Text == "")
                    {
                        txtRecibido.Text = "0";
                    }
                    decimal cambio = Convert.ToDecimal(txtTotalFinal.Text) - Convert.ToDecimal(recibido.Replace(".", ","));
                    txtCambio.Text = cambio.ToString();
                    txtRecibido.Text = recibido;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese el monto recibido");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string recibido = txtRecibido.Text;
                if (txtRecibido.Text == "" || txtRecibido.Text == "0" || Convert.ToDecimal(recibido.Replace(".", ",")) < Convert.ToDecimal(txtTotalFinal.Text))
                {
                    MessageBox.Show("Ingrese el monto pagado");
                }
                else
                {
                    bool generado = false;
                    int nuevoTk = 0;
                    string ultimoTicket = ticketCRUD.ultimoTicket();
                    if (ultimoTicket == "" || ultimoTicket == "0")
                    {
                        ultimoTicket = "1";
                    }
                    nuevoTk = Convert.ToInt32(ultimoTicket) + 1;
                    foreach (DataGridViewRow Row in dataGridView2.Rows)
                    {
                        string strFila = Row.Index.ToString();
                        dataGridView1.Rows[Int32.Parse(strFila)].Selected = true;
                        string id = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value);
                        string cantidad = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[2].Value);
                        string unitario = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[3].Value);
                        string totalPP = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[4].Value);

                        ticket nuevoT = new ticket(nuevoTk, Convert.ToDecimal(txtTotalFinal.Text), DateTime.Now, Convert.ToInt32(id), txtTotalVenta.Text, txtDescuento.Text, txtRecibido.Text, txtCambio.Text, unitario, totalPP, cantidad);
                        ticketCRUD.GuardarTicket(nuevoT);
                        generado = true;
                    }
                    if (generado)
                    {
                        MessageBox.Show("La venta se registro con exito");
                        
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error durante la generacion del ticket");
                    }
                    if (generado)
                    {
                        //ticketVenta ticket = new ticketVenta();
                        //for (int i = 0; i < dataGridView2.RowCount-1; i++)
                        //{
                        //    ticketGenerado nuevoTck = new ticketGenerado(
                        //        Convert.ToString(dataGridView2.Rows[i].Cells[1]),
                        //        Convert.ToInt32(dataGridView2.Rows[i].Cells[2]),
                        //        Convert.ToDecimal(dataGridView2.Rows[i].Cells[3]),
                        //        0,
                        //        0,
                        //        Convert.ToDecimal(dataGridView2.Rows[i].Cells[4])
                        //        );
                        //    ticket.Datos.Add(nuevoTck);
                        //}
                        //ticket.ShowDialog();

                        //ReportDataSource rds = new ReportDataSource();
                        DataSet1 tabla = new DataSet1();
                        DataRow fila;
                        int cantFilas = dataGridView2.Rows.Count;
                        for (int row = 0; row < dataGridView2.Rows.Count; row++)
                        {
                            fila = tabla.DataTable1.NewRow();
                            fila["NombreProducto"] = dataGridView2.Rows[Convert.ToInt32(row)].Cells[1].Value;
                            fila["Cantidad"] = dataGridView2.Rows[Convert.ToInt32(row)].Cells[2].Value;
                            fila["PrecioUnitario"] = dataGridView2.Rows[Convert.ToInt32(row)].Cells[3].Value;
                            fila["PrecioTotal"] = dataGridView2.Rows[Convert.ToInt32(row)].Cells[4].Value;
                            fila["Descuento"] = Convert.ToDecimal(txtDescuento.Text.Replace(".",","));
                            fila["PrecioFinal"] = Convert.ToDecimal(txtTotalFinal.Text);
                            fila["TotalVenta"] = Math.Round(Convert.ToDecimal(txtTotalVenta.Text),2);
                            tabla.DataTable1.Rows.Add(fila);
                        }
                        ticketVenta ticket = new ticketVenta(tabla.DataTable1);
                        ticket.Show();
                        dataGridView2.Rows.Clear();
                        txtRecibido.Text = "";
                        txtCambio.Text = "";
                        txtDescuento.Text = "";
                        txtTotalFinal.Text = "";
                        txtTotalVenta.Text = "";
                        //rds.Name = "ticketReport";
                        //rds.Value = tabla.Tables;
                        //reportViewer1.LocalReport.DataSources.Clear();
                        //ReportViewer1.LocalReport.DataSources.Add(rds);
                        //ReportViewer1.LocalReport.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar los datos: " + ex.Message);
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten numeros");
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                string punto = e.KeyChar.ToString();
                if (punto == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se admiten numeros y punto");
                }
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten numeros");
            }
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                string punto = e.KeyChar.ToString();
                if (punto == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se admiten numeros y punto");
                }
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten numeros");
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.ShowDialog();
        }
    }   
}
