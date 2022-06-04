using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarberH.clases;
using BarberH.CRUDs;
using BarberH.conexion;
using System.Data.SqlClient;


namespace BarberH
{
    public partial class FormCajachica : Form
    {
        DB_Conexion db = new DB_Conexion();

        public FormCajachica()
        {
            InitializeComponent();
        }

        private void FormCajachica_Load(object sender, EventArgs e)
        {
            NombreBarbero();
            dtpFecha.Value = System.DateTime.Now;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            llenarGrid();
            IngresosTotalesPorCortes();
            OtrosIngresos();
            CajaInicial();
            TotalIngresos();
            ComisionGeneral();
            Descuento();
            TotalEgresos();
            Liquido();
            //fechaDiaria();

        }

        public void fechaDiaria()
        {
            try
            {
                string fecha = dtpFecha.Text;
                DB_Conexion conectar = new DB_Conexion();
                SqlCommand llenarDgv = new SqlCommand("SELECT id_barbero as 'ID del barbero', nombre_barbero as 'Nombre del barbero', tipo_servicio as 'Tipo de servicio', fecha as 'Fecha', precio as 'Precio' FROM servicio where Fecha = '" + fecha + "'", conectar.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(llenarDgv);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conectar.CerrarConexion();
            }
            catch (Exception)
            {

                MessageBox.Show("Inserte un dato valido");
            }
        }
        public void llenarGrid()
        {
            string fecha = dtpFecha.Text;
            DataTable datos = AgregarDatosServicio.listar(fecha);
            if (datos == null)
            {
                MessageBox.Show("No se logró acceder a los datos de la base de datos");
            }
            else
            {
                dataGridView1.DataSource = datos;
                Console.WriteLine("Datos consultados");
            }
        }
        public void NombreBarbero()
        {
            try
            {
                string query = "SELECT id_barbero, nombre FROM barbero;";
                SqlCommand mostrar = new SqlCommand(query, db.AbrirConexion());
                SqlDataReader reader = mostrar.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Load(reader);
                cboBarberos.DataSource = dt;
                cboBarberos.DisplayMember = "nombre";
                cboBarberos.ValueMember = "id_barbero";
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.ShowDialog();
        }

        private void IngresosTotalesPorCortes()
        {
            double totalVenta = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                totalVenta += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox1.Text = totalVenta.ToString();
        }

        private void OtrosIngresos()
        {
            double otros_ingresos = ticketCRUD.TotalVenta(dtpFecha.Text);
            if (otros_ingresos == 0)
            {
                textBox3.Text = "0";
            }
            else
            {
                textBox3.Text = otros_ingresos.ToString();
            }
        }

        private void CajaInicial()
        {
            string cajaInicial = CajaDiariaCRUD.mostrar(dtpFecha.Text);
            textBox2.Text = cajaInicial;
        }

        private void TotalIngresos()
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                double total_ingresos = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox3.Text);
                textBox4.Text = total_ingresos.ToString();
            }
            else
            {
                MessageBox.Show("Patron incorrecto");
            }
          
        }

        private void ComisionGeneral()
        {
            double ingresos_cortes = Convert.ToDouble(textBox1.Text);
            ingresos_cortes = Convert.ToDouble(ingresos_cortes * 0.50);
            textBox5.Text = ingresos_cortes.ToString();
        }

        private void Descuento()
        {
            double descuentos = ticketCRUD.TotalDescuento(dtpFecha.Text);
            textBox7.Text = descuentos.ToString();
        }

        private void TotalEgresos()
        {
            double total_ingresos = Convert.ToDouble(textBox5.Text) + Convert.ToDouble(textBox7.Text);
            textBox6.Text = total_ingresos.ToString();
        }
        private void Liquido()
        {

            double liquido = Convert.ToDouble(textBox4.Text) - Convert.ToDouble(textBox6.Text);
            textBox8.Text = liquido.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Comision();
        }
        private void Comision()
        {
            try
            {
                string fecha = dtpFecha.Text;
                string query = "SELECT nombre_barbero, SUM(precio) * 0.50 AS 'Comision de barbero' FROM servicio WHERE fecha = '" + fecha + "' GROUP BY nombre_barbero;";
                SqlCommand mostrar = new SqlCommand(query, db.AbrirConexion());
                SqlDataReader reader = mostrar.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(0) + "  -  " + "$" + reader.GetDecimal(1));
                    }
                }
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

        private void button5_Click(object sender, EventArgs e)
        {
            CierreCaja();
        }

        private void CierreCaja()
        {
            try
            {
                double CierreCaja = Convert.ToDouble(textBox8.Text) - Convert.ToDouble(textBox10.Text);
                textBox9.Text = CierreCaja.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Debe abonar al fondo general");
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                HistorialCajaDiaria nuevoH = new HistorialCajaDiaria((float)Convert.ToDouble(textBox1.Text), (float)Convert.ToDouble(textBox3.Text), (float)Convert.ToDouble(textBox2.Text), (float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox5.Text), (float)Convert.ToDouble(textBox7.Text), (float)Convert.ToDouble(textBox6.Text), (float)Convert.ToDouble(textBox8.Text), (float)Convert.ToDouble(textBox10.Text), (float)Convert.ToDouble(textBox9.Text), DateTime.Now);
                HistorialCajaDiariaCRUD.GuardarHistorial(nuevoH);
                bool generado = true;
                if (generado)
                {
                    MessageBox.Show("El historial se guardo con exito");

                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox8.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al huardar el historial");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe abonar al fondo general");
            }
          
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones2 obj = new Validaciones2();
            obj.ValidarNumeros(e);
        }
    }
}