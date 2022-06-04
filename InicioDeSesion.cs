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

namespace BarberH
{
    public partial class InicioDeSesion : Form
    {
        DB_Conexion conexion = new DB_Conexion();
        public InicioDeSesion()
        {
            InitializeComponent();
            conexion.AbrirConexion();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradorDB admin = new AdministradorDB();
                admin.Usuario = textBox1.Text.Trim();
                admin.Contraseña = textBox2.Text.Trim();

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Ingrese los datos para iniciar sesion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (IniciarSesion.iniciar_sesion(admin))
                    {
                        label5.Text = "Verificando datos...";
                        await Task.Delay(1500);
                        label5.Text = "";
                        Menu mainMenu = new Menu();
                        this.Hide();
                        mainMenu.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        label5.Text = "Verificando datos...";
                        await Task.Delay(800);
                        label5.Text = "";
                        MessageBox.Show("Credenciales incorrectos\n\nIntentelo de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario registro = new RegistroDeUsuario();
            registro.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void InicioSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == e.CloseReason)
            {
                if (MessageBox.Show("¿Esta seguro que desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
