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
    public partial class DespliegueHorario : Form
    {
        public horario horarioN = new horario();
        int actualizar = 1;
        public string busqueda;
        public string fechaEdit;
        public DespliegueHorario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool validacion = true;
            if (textBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
            {
                validacion = false;
            }
            if (validacion == true && Convert.ToDateTime(maskedTextBox2.Text).Hour < Convert.ToDateTime("13:00").Hour && Convert.ToDateTime(maskedTextBox1.Text).Hour < Convert.ToDateTime("13:00").Hour && maskedTextBox1.Text != maskedTextBox2.Text)
            {
                if (Convert.ToDateTime(maskedTextBox3.Text) < Convert.ToDateTime("31/12/2030") && Convert.ToDateTime(maskedTextBox3.Text) > DateTime.Now.Date || Convert.ToDateTime(maskedTextBox3.Text) == DateTime.Now.Date)
                {
                    if (actualizar == 1)
                    {
                        string fechaHorario = Convert.ToDateTime(maskedTextBox3.Text).ToString("yyyy-MM-dd");
                        horario horario1 = new horario(textBox1.Text, maskedTextBox1.Text, maskedTextBox2.Text, Convert.ToDateTime(fechaHorario));
                        horarioCRUD.GuardarHorario(horario1, fechaHorario);
                    }
                    else
                    {
                        string fechaHorario = Convert.ToDateTime(maskedTextBox3.Text).ToString("yyyy-MM-dd");
                        horario horario2 = new horario(textBox1.Text, maskedTextBox1.Text, maskedTextBox2.Text, Convert.ToDateTime(fechaHorario));
                        horarioCRUD.ActualizarHorario(horario2, busqueda, fechaEdit);
                    }

                    //horarioCRUD.listar();
                    validacion = true;
                    this.Close();
                }
                else if (Convert.ToDateTime(maskedTextBox3.Text) < DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha no puede ser anterior a este dia");
                    validacion = false;
                }
            }
            else
            {
                MessageBox.Show("Verifique la hora y que todos los campos esten llenos");
                validacion = false;
            }
            if (validacion == false)
            {
                MessageBox.Show("Verifique la informacion");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DespliegueHorario_Load(object sender, EventArgs e)
        {
            textBox1.Text = horarioN.NombrePersona1;
            if (textBox1.Text.Length == 0)
            {
                actualizar = 1;
            }
            else
            {
                actualizar = 0;
            }
            maskedTextBox1.Text = horarioN.HoraInicio1;
            maskedTextBox2.Text = horarioN.HoraFinal1;
            maskedTextBox3.Text = Convert.ToString(horarioN.Fecha1);
            busqueda = textBox1.Text;
            fechaEdit = Convert.ToDateTime(maskedTextBox3.Text).ToString("yyyy-MM-dd");
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
    }
}
