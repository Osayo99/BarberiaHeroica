using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BarberH
{
    public partial class AgregarBarbero : Form
    {
        public AgregarBarbero()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Regex letras = new Regex("^[a-zA-Z ]+$");
            Regex numeros = new Regex("^[0-9]+$");

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""|| textBox4.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(textBox1.Text == "")
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Ingrese el nombre para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox1, "Ingrese el nombre para completar el registro");
                    textBox1.Focus();
                }
                else if (!letras.IsMatch(textBox1.Text))
                {
                    errorProvider1.Clear();
                    MessageBox.Show("No se permite ningun valor númerico en la celda del nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox1, "No se permite ningun valor númerico en esta celda");
                    textBox1.Focus();
                }
                else if(textBox2.Text == "")
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Ingrese el apellido para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox2, "Ingrese el apellido para completar el registro");
                    textBox2.Focus();
                }
                else if (!letras.IsMatch(textBox2.Text))
                {
                    errorProvider1.Clear();
                    MessageBox.Show("No se permite ningun valor númerico en la celda de apellido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox2, "No se permite ningun valor númerico en esta celda");
                    textBox2.Focus();
                }
                else if(!numeros.IsMatch(textBox3.Text))
                {
                    errorProvider1.Clear();
                    MessageBox.Show("No se permite ninguna cadena de texto en la celda de telefono", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox3, "No se permite ninguna cadena de texto númerico en esta celda");
                    textBox3.Focus();
                }
                else if (textBox3.Text.Length != 8)
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Su numero de telefono debe contener almenos 8 digitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox3, "Su numero de telefono debe contener almenos 8 digitos");
                    textBox3.Focus();
                }
                else if(textBox3.Text == "")
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Ingrese el número de telefono para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox3, "Ingrese el número de telefono para completar el registro");
                    textBox3.Focus();
                }
                else if(comboBox1.Text == "--Seleccione un genero--")
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Seleccione el genero para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(comboBox1, "Seleccione el genero para completar el registro");
                    comboBox1.Focus();
                }
                else if (textBox4.Text == "")
                {
                    errorProvider1.Clear();
                    MessageBox.Show("Ingrese la ciudad para completar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox4, "Ingrese la ciudad para completar el registro");
                    textBox4.Focus();
                }
                else if (!letras.IsMatch(textBox4.Text))
                {
                    errorProvider1.Clear();
                    MessageBox.Show("No se permite ningun valor númerico en la celda de ciudad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(textBox4, "No se permite ningun valor númerico en esta celda");
                    textBox4.Focus();
                }
                else
                {
                    try
                    {
                        clases.Barbero barbero = new clases.Barbero();

                        barbero.Nombre = textBox1.Text;
                        barbero.Apellido = textBox2.Text;
                        barbero.Telefono = textBox3.Text;
                        barbero.Genero = comboBox1.Text;
                        barbero.Ciudad = textBox4.Text;

                        if (CRUDs.AgregarBarbero.RegistrarBarbero(barbero))
                        {
                            this.Close();
                            MessageBox.Show("Barbero registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegistrar_Click(this, new EventArgs());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegistrar_Click(this, new EventArgs());
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegistrar_Click(this, new EventArgs());
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegistrar_Click(this, new EventArgs());
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRegistrar_Click(this, new EventArgs());
            }
        }
    }
}
