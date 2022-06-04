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
    public partial class FormRegistro : Form
    {
        private readonly FormCliente _parent;
        public string id_cliente, barbero, nombre, servicio, temperatura, telefono, fecha, nomEdit, telefEdit;
        DB_Conexion db = new DB_Conexion();


        public FormRegistro(FormCliente parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarLetras(e);
        }

        private void txttemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarTemperatura(e);
        }

        private void txttell_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarTel(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            //Mostrando datos del barbero en combobox
            NombreBarbero();
        }

        private void cmbBarb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Validaciones2 obj = new Validaciones2();

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
        public void nomCli(string nombreEdit, string tel)
        {
            nomEdit = nombreEdit;
            telefEdit = tel;
        }

            public void ActualizarInfo()
        {
            lbltext.Text = "Actualizar Cliente";
            btnsave.Text = "Actualizar";
            cmbBarb.Text = barbero;
            txtname.Text = nombre;
            txtservicio.Text = servicio;
            txttemperatura.Text = temperatura;
            txttell.Text = telefono;
            ////dtFecha.Text = fecha;
            //dtFecha.Text = Convert.ToString(fecha);
            //string fecha = dtFecha.Value.ToString("dd/MM/yyyy");
            
        }



        public void Clear()
        {
            lbltext.Text = "Agregar Cliente";
            btnsave.Text = "Guardar";
            cmbBarb.Text = txtname.Text = txtservicio.Text = txttemperatura.Text = txttell.Text =   string.Empty;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void nbtsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBarb.Text == "")
                {
                    MessageBox.Show("Campo barbero obligatorio");
                    return;
                }
                if (txtname.Text == "")
                {
                    MessageBox.Show("Campo nombre obligatorio");
                    return;
                }
                if (txtservicio.Text == "")
                {
                    MessageBox.Show("Campo servicio obligatorio");
                    return;
                }
                if (txttemperatura.Text == "")
                {
                    MessageBox.Show("Campo temperatura obligatorio");
                    return;
                }
                if (txttell.Text == "")
                {
                    MessageBox.Show("Ingresar un numero de telefono valido: '0000-0000'");
                    return;
                }
                if (btnsave.Text == "Guardar")
                {
                    DateTime fechaCli = dtFecha.Value;
                    Cliente cli = new Cliente(cmbBarb.Text.Trim(), txtname.Text.Trim(), txtservicio.Text.Trim(), txttell.Text.Trim(), txttemperatura.Text.Trim(), Convert.ToDateTime(dtFecha.Value));
                    CRUDcliente.AgregarCliente(cli);
                    Clear();
                }

                else if (btnsave.Text == "Actualizar")
                {
                    DateTime fechaCli = dtFecha.Value;
                    Cliente cli = new Cliente(cmbBarb.Text.Trim(), txtname.Text.Trim(), txtservicio.Text.Trim(), txttell.Text.Trim(), txttemperatura.Text.Trim(), Convert.ToDateTime(dtFecha.Value));
                    CRUDcliente.ActualizarCliente(cli, nomEdit, telefEdit);
                    this.Close();
                }
                _parent.Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                cmbBarb.DataSource = dt;
                cmbBarb.DisplayMember = "nombre";
                cmbBarb.ValueMember = "id_barbero";
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
    }
}
