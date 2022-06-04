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
    public partial class DespliegueActividad2 : Form
    {
        public actividad actividadN = new actividad();
        int actualizar = 1;
        public string busquedaA;
        public string busquedaE;
        public string fechaEdit;

        public DespliegueActividad2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool validacion = true;
            if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || maskedTextBox3.Text == "")
            {
                validacion = false;
            }
            if (validacion == true && Convert.ToDateTime(maskedTextBox1.Text).Hour < Convert.ToDateTime("13:00").Hour)
            {
                if (Convert.ToDateTime(maskedTextBox3.Text) < Convert.ToDateTime("31/12/2030") && Convert.ToDateTime(maskedTextBox3.Text) > DateTime.Now.Date || Convert.ToDateTime(maskedTextBox3.Text) == DateTime.Now.Date)
                {
                    if (actualizar == 1)
                    {
                        string fechaHorario = Convert.ToDateTime(maskedTextBox3.Text).ToString("yyyy-MM-dd");
                        actividad actividad1 = new actividad(textBox1.Text, textBox2.Text, maskedTextBox1.Text, Convert.ToDateTime(fechaHorario));
                        actividadCRUD.GuardarActividad(actividad1, fechaHorario);
                    }
                    else
                    {
                        string fechaHorario = Convert.ToDateTime(maskedTextBox3.Text).ToString("yyyy-MM-dd");
                        actividad actividad2 = new actividad(textBox1.Text, textBox2.Text, maskedTextBox1.Text, Convert.ToDateTime(fechaHorario));
                        actividadCRUD.ActualizarActividad(actividad2, busquedaA, busquedaE, fechaEdit);
                    }

                    //horarioCRUD.listar();
                    validacion = true;
                    this.Close();
                }
                else if (Convert.ToDateTime(maskedTextBox3.Text) < DateTime.Now.Date)
                {
                    validacion = false;
                    MessageBox.Show("La fecha no puede ser anterior a este dia");
                }
            }
            else
            {
                validacion = false;
                MessageBox.Show("Verifique la hora y que todos los campos esten llenos");
            }
            if (validacion == false)
            {
                MessageBox.Show("Verifique la información");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DespliegueActividad_Load(object sender, EventArgs e)
        {
            textBox1.Text = actividadN.NombreActividad1;
            if (textBox1.Text.Length == 0)
            {
                actualizar = 1;
            }
            else
            {
                actualizar = 0;
            }
            textBox2.Text = actividadN.Encargado1;
            maskedTextBox1.Text = actividadN.Hora1;
            maskedTextBox3.Text = Convert.ToString(actividadN.Fecha1);
            busquedaA = textBox1.Text;
            busquedaE = textBox2.Text;
            fechaEdit = (maskedTextBox3.Text);
            //fechaEdit2 = Convert.ToDateTime(maskedTextBox3.Text).ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
