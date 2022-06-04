using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BarberH.clases;
using BarberH.CRUDs;
using BarberH.conexion;
using System.Data.SqlClient;
using System.Globalization;

namespace Perfil_barberos
{
    public partial class Perfil_Barberos : Form
    {
        MostrarDatosDgv obj = new MostrarDatosDgv();
        DB_Conexion db = new DB_Conexion();
        

        public Perfil_Barberos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarberH.Menu menu = new BarberH.Menu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void MostarBarbero_Load(object sender, EventArgs e)
        {
            //Agregando items de barberos a combobox
            DatosBarbero();
            IDBarbero();
            //Mostrar los datos de la base de datos en la DGV
            dataGridView1.DataSource = obj.MostrarDatos();
            label9.Text = DateTime.Now.ToShortDateString();
            dtpFecha.Value = System.DateTime.Now;
            cmbTipo.SelectedIndex = 0;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbBarbero == null || cmbCodigo == null || cmbTipo.Text == "-- Seleccione el tipo de corte --" || dtpFecha.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("Rellene los datos a solicitar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cmbCodigo.Text == null)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Seleccione el codigo del barbero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(cmbCodigo, "Seleccione el codigo del barbero");
                    cmbCodigo.Focus();
                }
                else if(int.Parse(cmbCodigo.Text) < 0)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Digite un codigo valido del barbero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(cmbCodigo, "Digite un codigo valido del barbero");
                    cmbCodigo.Focus();
                }
                else if (cmbTipo.Text == null)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Digite el tipo de servicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(cmbTipo, "Seleccione el tipo de servicio");
                    cmbTipo.Focus();
                }
                else if (txtPrecio.Text == null)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Digite un precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(txtPrecio, "Digite un precio");
                    txtPrecio.Focus();
                }
                else if(double.Parse(txtPrecio.Text) < 0)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Digite un precio valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(txtPrecio, "Digite un precio valido");
                    txtPrecio.Focus();
                }
                else if(dtpFecha.Text == null)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Seleccione una fecha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(dtpFecha, "Seleccione una fecha");
                    dtpFecha.Focus();
                }
                else if (dtpFecha.Value.Date < DateTime.Now.Date)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("No se puede agregar una fecha que sea anterior a la actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(dtpFecha, "Agregue una fecha que no sea anterior a la actual");
                    dtpFecha.Focus();
                }
                else
                {
                    try
                    {
                        Servicio servicio = new Servicio();

                        //Convirtiendo los textos con sus respectivos tipos de datos
                        int txtcod = Convert.ToInt32(cmbCodigo.Text.Trim());
                        //DateTime fecha = DateTime.ParseExact(dtpFecha.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        decimal precio = Convert.ToDecimal(txtPrecio.Text.Replace(".", ","));

                        //Agregando los datos a su constructor

                        servicio.Id_barbero = txtcod;
                        servicio.Nombre_barbero = cmbBarbero.Text;
                        servicio.Tipo_servicio = cmbTipo.Text;
                        servicio.Fecha = dtpFecha.Text;
                        servicio.Precio = precio;

                        //ID BARBERO DE SERVICIO = AL DE BARBERO

                        if (AgregarDatosServicio.AgregarDatos(servicio))
                        {
                            dataGridView1.DataSource = obj.MostrarDatos();
                            BarberH.Ventas ventas = new BarberH.Ventas();
                            //ventas.ShowDialog();
                            cmbTipo.SelectedIndex = -1;
                            txtPrecio.Clear();
                            cmbCodigo.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al guardar los datos: " + ex.Message);
                    }
                }
            }
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            double totalVenta = 0;
            try
            {
                //string query = "SELECT id_barbero FROM barbero WHERE id_barbero = " + cmbID.SelectedValue + ";";
                dataGridView1.DataSource = obj.MostrarPorID(Convert.ToInt32(cmbID.SelectedValue));

                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    totalVenta += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }
                txtTotal.Text = "$ " + totalVenta.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                db.CerrarConexion();
            }
            dataGridView1.DataSource = obj.MostrarDatos();
        }

        private void DatosBarbero()
        {
            try
            {
                string query = "SELECT id_barbero, nombre FROM barbero;";
                SqlCommand mostrar = new SqlCommand(query, db.AbrirConexion());
                SqlDataReader reader = mostrar.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Load(reader);
                cmbBarbero.DataSource = dt;
                cmbBarbero.DisplayMember = "nombre";
                cmbBarbero.ValueMember = "id_barbero";
                cmbCodigo.DataSource = dt;
                cmbCodigo.DisplayMember = "id_barbero";
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " +ex.Message);
            }
            finally
            {
                db.CerrarConexion();
            }
        }

        private void IDBarbero()
        {
            try
            {
                string query = "SELECT id_barbero FROM barbero;";
                SqlCommand mostrar = new SqlCommand(query, db.AbrirConexion());
                SqlDataReader reader = mostrar.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("id_barbero", typeof(string));
                dt.Load(reader);
                cmbID.DataSource = dt;
                cmbID.DisplayMember = "id_barbero";
                cmbID.ValueMember = "id_barbero";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                db.CerrarConexion();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarberH.AgregarBarbero agregarBarbero = new BarberH.AgregarBarbero();
            agregarBarbero.ShowDialog();
            DatosBarbero();
            IDBarbero();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatosBarbero();
        }

        private void cmbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(this, new EventArgs());
            }
        }

        private void cmbBarbero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(this, new EventArgs());
            }
        }

        private void txtTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(this, new EventArgs());
            }
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(this, new EventArgs());
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAgregar_Click(this, new EventArgs());
            }
        }

        private void cmbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBarbero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.Historial();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.MostrarDatos();
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double totalVenta = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                totalVenta += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txtTotal.Text = "$ " + totalVenta.ToString();
        }

        private void cmbBarbero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipo.SelectedIndex == 1)
            {
                txtPrecio.Text = "4";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if(cmbTipo.SelectedIndex == 2)
            {
                txtPrecio.Text = "4";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 3)
            {
                txtPrecio.Text = "7";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 4)
            {
                txtPrecio.Text = "4";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 5)
            {
                txtPrecio.Text = "4";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 6)
            {
                txtPrecio.Text = "6";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 7)
            {
                txtPrecio.Text = "4";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 8)
            {
                txtPrecio.Text = "2";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 9)
            {
                txtPrecio.Text = "3.99";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 10)
            {
                txtPrecio.Text = "0.99";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = true;
            }
            else if (cmbTipo.SelectedIndex == 11)
            {
                txtPrecio.Text = "";
                txtPrecio.Enabled = true;
                txtPrecio.ReadOnly = false;
            }
            else if (cmbTipo.SelectedIndex == 0)
            {
                txtPrecio.Text = "";
                txtPrecio.Enabled = false;
            }
        }

        private void btnMostrarFecha_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.MostrarFechaEspecifica(dtpFecha.Text);
        }
    }
}
