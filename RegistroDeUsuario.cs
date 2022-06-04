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
    public partial class RegistroDeUsuario : Form
    {
        public RegistroDeUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Porfavor ingrese todos los datos para completar su registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBox2.Text.Length > 8 || textBox2.Text.Length < 7)
                {
                    MessageBox.Show("Su numero de telefono debe contener almenos 8 digitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox1.Text.Length < 3)
                {
                    MessageBox.Show("Porfavor ingrese un usuario mas extenso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (int.Parse(textBox2.Text) < 0)
                {
                    MessageBox.Show("Porfavor omita los numeros negativos en el numero de telefono", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox3.Text.Length < 5 && textBox4.Text.Length < 5)
                {
                    MessageBox.Show("Porfavor ingrese una contraseña mas extensa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Asegurese que su contraseña sea la misma al confirmarla nuevamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        AdministradorDB admin = new AdministradorDB();
                        admin.Usuario = textBox1.Text.Trim();
                        admin.Telefono = textBox2.Text.Trim();
                        admin.Contraseña = textBox3.Text.Trim();

                        if (Registrarse.registrarse(admin))
                        {
                            this.Close();
                            MessageBox.Show("¡Usuario Registrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al registrarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }


        private void RegistroDeUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
