using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberH
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
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

        private async void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                label4.Text = "Cerrando sesión...";
                await Task.Delay(1000);
                label4.Text = "";
                InicioDeSesion inicioDeSesion = new InicioDeSesion();
                this.Hide();
                inicioDeSesion.ShowDialog();
            }
            else
            {

            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario invent = new Inventario();
            this.Hide();
            invent.ShowDialog();
        }

        private void btnPerfilClientes_Click(object sender, EventArgs e)
        {
            FormCliente client = new FormCliente();
            this.Hide();
            client.ShowDialog();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Ventas vent = new Ventas();
            this.Hide();
            vent.ShowDialog();
        }

        private void btnCalendarizacion_Click(object sender, EventArgs e)
        {
            Calendarizacion calen = new Calendarizacion();
            this.Hide();
            calen.ShowDialog();
        }

        private void btnPerfilBarbs_Click(object sender, EventArgs e)
        {
            Perfil_barberos.Perfil_Barberos mostarBarbero = new Perfil_barberos.Perfil_Barberos();
            this.Hide();
            mostarBarbero.ShowDialog();
        }

        private void btnControlCaja_Click(object sender, EventArgs e)
        {
            FormCajachica caja = new FormCajachica();
            this.Hide();
            caja.ShowDialog();
        }

        private void btnFondoGeneral_Click(object sender, EventArgs e)
        {
            FondoGeneral fondoGeneral = new FondoGeneral();
            this.Hide();
            fondoGeneral.ShowDialog();
        }
    }
}
