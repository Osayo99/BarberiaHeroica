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
    public partial class FondoGeneral : Form
    {
        Caja objCaja;
        Movimiento objMov;
        CajaNeg objCajaNeg;
        MovimientoNeg objMovNeg;
        
        public FondoGeneral()
        {
            InitializeComponent();            
            objCaja = new Caja();
            objCajaNeg = new CajaNeg();
            objMov = new Movimiento();
            objMovNeg = new MovimientoNeg();
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnVerificar.Enabled = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            deshabilitarEntradas();
            deshabilitarRadioButtons();
            lblsaldo.Text = mostrarSaldoActual();

            
        }
        public string mostrarSaldoActual()
        {
            objCaja = new Caja();
            objCajaNeg.LeerUltimaCaja(objCaja);
            return objCaja.SaldoTotal;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            objCajaNeg.LeerUltimaCaja(objCaja);
            if(rbIngreso.Checked)
                objMov = new Movimiento("0", txtMonto.Text, txtDescripcion.Text, fechaGet(), objCaja.CodCaja);
            else
                if(rbEgreso.Checked)
                    objMov = new Movimiento("1", txtMonto.Text, txtDescripcion.Text,fechaGet(), objCaja.CodCaja);
            
            objMovNeg.RegistrarMovimiento(objMov, objCaja);
            mostrarMensajeRegistro(objMov);

            
            if (rbIngreso.Checked)
                cargarTablaIngresos(objMov);
            else
                if (rbEgreso.Checked)
                    cargarTablaEgresos(objMov);

            
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
           btnVerificar.Enabled = true;
        }

        private void lblSaldoActual_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

 

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            


        }

        private void Egresos_Click(object sender, EventArgs e)
        {
            
        }

        public void limpiarEntradas()
        {
            txtMonto.Text = "";
            txtDescripcion.Text = "";
            txtSaldoTemporal.Text = "";
            lblMensajeRegistros.ForeColor = Color.Black;
            lblMensajeRegistros.Text = "Introduzca los Datos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            deshabilitarRadioButtons();
            limpiarEntradas();
            btnAceptar.Visible = true;
            deshabilitarEntradas();
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void rbIngreso_CheckedChanged(object sender, EventArgs e)
        {
            lblTabla.Text = "";
            lblBuscar.Text = "";
            txtSumaEgresos.Text = "";
            txtSumaIngresos.Text = "";
            txtFecha.Text = "";
            //deshabilitarBusqueda();
            btnModificar.Visible = false;
            btnAceptar.Visible=true;
            btnEliminar.Visible = false;
            lblMensajePrincipal.ForeColor = Color.Black;
            lblMensajePrincipal.Text = "Has seleccionado INGRESOS...";
            limpiarEntradas();
            lblsaldo.Text = mostrarSaldoActual();
            objMov.Fecha = fechaGet();
            cargarTablaIngresos(objMov);
            habilitarEntradas();
            
            
        }

        private void rbEgreso_CheckedChanged(object sender, EventArgs e)
        {
            lblTabla.Text = "";
            lblBuscar.Text = "";
            txtFecha.Text = "";
            //deshabilitarBusqueda();
            lblMensajePrincipal.ForeColor = Color.Black;
            lblMensajePrincipal.Text = "Has seleccionado EGRESOS...";
            btnModificar.Visible = false;
            btnAceptar.Visible = true;
            btnEliminar.Visible = false;
            txtSumaEgresos.Text = "";
            txtSumaIngresos.Text = "";
            limpiarEntradas();
            lblsaldo.Text = mostrarSaldoActual();
            objMov.Fecha = fechaGet();
            cargarTablaEgresos(objMov);
            habilitarEntradas();
        }


        public void cargarTablaIngresos(Movimiento obj)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerIngresos(obj);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void cargarTablaEgresos(Movimiento obj)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerEgresos(obj);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void cargarTablaMovimientos(Movimiento obj)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerIngresosEgresos(obj);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void cargarTablaMovimientosMes(string fec)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerIngresosEgresosMes(fec);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void cargarTablaIngresosMes(string fec)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerIngresosMes(fec);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void cargarTablaEgresosMes(string fec)
        {
            objMovNeg = new MovimientoNeg();
            GV.Visible = true;
            DataTable dsMov = objMovNeg.LeerEgresosMes(fec);
            GV.DataSource = dsMov;
            GV.Columns[4].Visible = false;
        }

        public void mostrarMensajeRegistro(Movimiento obj)
        {
            if (obj.Estado == 99)
                lblMensajeRegistros.ForeColor = Color.Green;
            else
                lblMensajeRegistros.ForeColor = Color.Red;
            switch (obj.Estado)
            {
                case 99:
                    {
                        
                        if(obj.Tipo.Equals("Ingreso"))
                            lblMensajeRegistros.Text = "La caja ha aumentado su saldo";
                        else
                            lblMensajeRegistros.Text = "La caja ha disminuido su saldo";

                        txtMonto.Text = "";
                        txtDescripcion.Text = "";
                        txtSaldoTemporal.Text = "";
                        lblsaldo.Text = mostrarSaldoActual();
                        btnVerificar.Enabled = false;

                        if (btnModificar.Visible == true)
                        {
                            btnAceptar.Visible = true;
                            btnModificar.Visible = false;
                            btnEliminar.Visible = false;
                        }
                       

                    }break;
                case 45:
                    lblMensajeRegistros.Text = "La caja no existe";
                    break;
                case 1:
                    lblMensajeRegistros.Text = "El movimiento no existe";
                    break;
                case 2:
                    {
                        lblMensajeRegistros.Text = "Monto debe ser mayor a cero";
                        txtSaldoTemporal.Text = "";
                    }
                    break;
                case 3:
                    {
                        lblMensajeRegistros.Text = "Monto debe ser numérico";
                        txtSaldoTemporal.Text = "";
                    }                    
                    break;
                case 4:
                    lblMensajeRegistros.Text = "Ingrese una descripción";
                    break;
                case 11:
                    {
                        lblMensajeRegistros.Text = "El Monto no puede exceder al saldoActual";
                        txtSaldoTemporal.Text = "";
                    }                    
                    break;
                case 12:
                    {
                        lblMensajeRegistros.Text = "La suma de Ingresos NO puede ser MENOR que la de Egresos";
                        txtSaldoTemporal.Text = "";
                    }
                    break;
                default:
                    lblMensajeRegistros.Text = "===???===";
                    break;
            }
        }

        

        

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            limpiarEntradas();
            deshabilitarRadioButtons();
            deshabilitarEntradas();
            dt.Enabled = true;
            lblMensajeRegistros.Text = "";
            if (!txtFecha.Text.Equals(""))
            {
                btnBuscar.Enabled = true;
                btnBuscar.BackColor = Color.Black;
                btnBuscar.ForeColor = Color.White;
                lblBuscar.ForeColor = Color.Black;
                lblBuscar.Text = "Pulse en Buscar";
            }
            else
            {
                lblBuscar.ForeColor = Color.Black;
                lblBuscar.Text = "Seleccione una fecha del calendario";
            }
            
            


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            
            double sumatoriaE = 0.0;
            double sumatoriaI = 0.0;
            txtSumaEgresos.Text = "";
            txtSumaIngresos.Text = "";
            lblMensajeRegistros.Text = "";
            lblBuscar.Text = "";
            lblTabla.Text = "";

            if(comboBusqueda.SelectedIndex.Equals(0))
            {
                objMov.Fecha = txtFecha.Text;
                cargarTablaIngresos(objMov);
                
                foreach(DataGridViewRow row in GV.Rows)
                {
                    sumatoriaI += Convert.ToDouble(row.Cells["Monto (+)"].Value);   
                }

                txtSumaIngresos.Text = Convert.ToString(sumatoriaI);
            }
            if (comboBusqueda.SelectedIndex.Equals(1))
            {
                objMov.Fecha = txtFecha.Text;
                cargarTablaEgresos(objMov);
                

                foreach (DataGridViewRow row in GV.Rows)
                {
                    sumatoriaE += Convert.ToDouble(row.Cells["Monto (-)"].Value);
                    
                }

                txtSumaEgresos.Text = Convert.ToString(sumatoriaE);
            }
            if (comboBusqueda.SelectedIndex.Equals(2))
            {
                objMov.Fecha = txtFecha.Text;
                cargarTablaMovimientos(objMov);

                foreach (DataGridViewRow row in GV.Rows)
                {

                    if (Convert.ToString(row.Cells["Movimiento"].Value).Equals("Ingreso"))
                    {
                        sumatoriaI += Convert.ToDouble(row.Cells["Monto (+/-)"].Value);
                    }
                    else
                    {
                        sumatoriaE += Convert.ToDouble(row.Cells["Monto (+/-)"].Value);
                    }
                }

                
                txtSumaIngresos.Text = Convert.ToString(sumatoriaI);
                txtSumaEgresos.Text = Convert.ToString(sumatoriaE);
                lblTabla.ForeColor = Color.Black;
                double total = sumatoriaI - sumatoriaE;
                if (total > 0)
                {
                    lblTabla.ForeColor = Color.Green;
                    lblTabla.Text = "Ganancia del día: " + (sumatoriaI - sumatoriaE) + " USD";
                }
                else
                {
                    lblTabla.ForeColor = Color.Red;
                    lblTabla.Text = "Pérdida del día: " + -1 * (sumatoriaI - sumatoriaE) + " USD";
                }

                
            }

            if ((txtSumaEgresos.Text.Equals("0") || txtSumaEgresos.Text.Equals("")) && (txtSumaIngresos.Text.Equals("0") || txtSumaIngresos.Text.Equals("")))
            {
                lblTabla.ForeColor = Color.Black;
                lblTabla.Text = "No se encontraron registros para esa fecha";
                
            }
            else
            {
                lblBuscar.ForeColor = Color.Black;
                lblBuscar.Text = "Seleccione una Búsqueda";
                
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objCajaNeg.LeerUltimaCaja(objCaja);
            objMovNeg.LeerMovimiento(objMov);
            objMov.Monto = txtMonto.Text;
            objMov.Descripcion = txtDescripcion.Text;
            objMovNeg.ActualizarMovimiento(objMov, objCaja);
            mostrarMensajeRegistro(objMov);
            if (objMov.Estado.Equals(99))
            {
                if (comboBusqueda.SelectedIndex.Equals(2))
                    cargarTablaMovimientos(objMov);
                    
                else
                    if (objMov.Tipo.Equals("Ingreso"))
                        cargarTablaIngresos(objMov);                
                    else                
                        cargarTablaEgresos(objMov);

                lblMensajeRegistros.ForeColor = Color.Black;
                lblMensajeRegistros.Text = "Se modificó con éxito";
                txtSumaEgresos.Text = "";
                txtSumaIngresos.Text = "";
                deshabilitarEntradas();
            }
           

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objCajaNeg.LeerUltimaCaja(objCaja);
            objMovNeg.LeerMovimiento(objMov);
            objMovNeg.EliminarMovimiento(objMov,objCaja);
            mostrarMensajeRegistro(objMov);
            if(objMov.Estado.Equals(99))
            {
                if (objMov.Tipo.Equals("Ingreso")){
                    
                    cargarTablaIngresos(objMov);
                }
                else
                {
                    cargarTablaEgresos(objMov);
                }
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
                btnAceptar.Visible = true;
                btnVerificar.Enabled = false;
                limpiarEntradas();
                lblMensajeRegistros.ForeColor = Color.Black;
                lblMensajeRegistros.Text = "Se eliminó correctamente";
                lblsaldo.Text = mostrarSaldoActual();
                txtSumaEgresos.Text = "";
                txtSumaIngresos.Text = "";
                deshabilitarEntradas();
            }
            
        }

        private void GV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            deshabilitarRadioButtons();
            try
            {
                DataGridViewRow dgv1 = GV.Rows[e.RowIndex];
                objMov.CodMovimiento = dgv1.Cells[4].Value.ToString();
                if (dgv1.Cells[3].Value.ToString().Equals("Ingreso"))
                    objMov.Tipo = "Ingreso";
                if (dgv1.Cells[3].Value.ToString().Equals("Egreso"))
                    objMov.Tipo = "Egreso";

                objMov.Monto = dgv1.Cells[0].Value.ToString();

                txtMonto.Text = dgv1.Cells[0].Value.ToString();
                txtDescripcion.Text = dgv1.Cells[1].Value.ToString();

                if (!dgv1.Cells[0].Value.ToString().Equals(null))
                {
                    btnEliminar.Visible = true;
                    btnModificar.Visible = true;
                    btnAceptar.Visible = false;
                    lblMensajeRegistros.ForeColor = Color.Black;
                    lblMensajeRegistros.Text = "Modifique  o Elimine";
                }
                habilitarEntradas();

            }
            catch
            {
                lblTabla.ForeColor = Color.Black;
                lblTabla.Text = "Por favor vuelva a seleccionar un registro de la tabla";
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            
            lblMensajeRegistros.Text = "";
            if (txtMonto.Text.Equals(""))
            {
                lblMensajeRegistros.ForeColor = Color.Black;
                lblMensajeRegistros.Text = "Ingrese monto";
            }
                else
                if (txtDescripcion.Text.Equals(""))
                {
                    lblMensajeRegistros.ForeColor = Color.Black;
                    lblMensajeRegistros.Text = "Verifique saldo temporal e ingrese una descripción";
                    try
                    {
                        if (rbIngreso.Checked)
                            txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) + double.Parse(txtMonto.Text));
                        else
                            if (rbEgreso.Checked)
                                txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) - double.Parse(txtMonto.Text));

                    }
                    catch
                    {
                        lblMensajeRegistros.ForeColor = Color.Black;
                        lblMensajeRegistros.Text = "ERROR, revise el monto";
                        txtSaldoTemporal.ForeColor = Color.Black;
                        txtSaldoTemporal.Text = "???";
                    }
                }
                else
                {    
                    try
                    {
                        if (btnAceptar.Visible == true)
                        {
                            if (rbIngreso.Checked)
                                txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) + double.Parse(txtMonto.Text));
                            else
                                if (rbEgreso.Checked)
                                    txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) - double.Parse(txtMonto.Text));

                            lblMensajeRegistros.ForeColor = Color.Black;
                            lblMensajeRegistros.Text = "Pulse Aceptar para registrar";
                        }
                        else
                            if(btnModificar.Visible == true)
                        {
                            if (objMov.Tipo.Equals("Ingreso"))
                                txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) - double.Parse(objMov.Monto) + double.Parse(txtMonto.Text));
                            else
                                if (objMov.Tipo.Equals("Egreso"))
                                    txtSaldoTemporal.Text = "" + (double.Parse(lblsaldo.Text) + double.Parse(objMov.Monto) - double.Parse(txtMonto.Text));

                            lblMensajeRegistros.ForeColor = Color.Black;
                            lblMensajeRegistros.Text = "Pulse Modificar";

                        }

                    }
                    catch
                    {
                        lblMensajeRegistros.ForeColor = Color.Red;
                        lblMensajeRegistros.Text = "ERROR, revise el montoo";
                        txtSaldoTemporal.ForeColor = Color.Red;
                        txtSaldoTemporal.Text = "???";
                    }
                }
        }

        public string fechaGet(){
            DateTime fec = DateTime.Today;
            return fec.ToString("d");
        }

        private void lblMensajePrincipal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void habilitarEntradas()
        {
            txtDescripcion.Enabled = true;
            txtMonto.Enabled = true;
            
        }

        public void deshabilitarBusqueda()
        {
            btnMes.Visible = true;
            btnBuscar.Enabled = true;
            dt.Enabled = true;

        }
        public void deshabilitarEntradas()
        {
            txtDescripcion.Enabled = false;
            txtMonto.Enabled = false;
        }
        public void deshabilitarRadioButtons()
        {
            rbEgreso.Checked = false;
            rbIngreso.Checked = false;
            lblMensajePrincipal.ForeColor = Color.Black;
            lblMensajePrincipal.Text = "Seleccione (Ingreso o Egreso)";
        }

        private void lblsaldo_Click(object sender, EventArgs e)
        {

        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            txtFecha.Text = dt.Value.ToString("d");
            btnMes.Visible = true;
            btnBuscar.Enabled = true;

        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    string fec = "";
        //    char letra;
        //    for (int i = 0; i < txtFecha.Text.Length; i++)
        //    {
        //        letra = txtFecha.Text[i];
        //        if (i == 3 || i == 4)
        //        {
        //            fec += letra;
        //        }
        //    }

        //    double sumatoriaE = 0.0;
        //    double sumatoriaI = 0.0;
        //    txtSumaEgresos.Text = "";
        //    txtSumaIngresos.Text = "";
        //    lblMensajeRegistros.Text = "";
        //    lblBuscar.Text = "";
        //    lblTabla.Text = "";

        //    if (comboBusqueda.SelectedIndex.Equals(0))
        //    {
        //        cargarTablaIngresosMes(fec);

        //        foreach (DataGridViewRow row in GV.Rows)
        //        {
        //            sumatoriaI += Convert.ToDouble(row.Cells["Monto (+)"].Value);
        //        }

        //        txtSumaIngresos.Text = Convert.ToString(sumatoriaI);
        //    }
        //    if (comboBusqueda.SelectedIndex.Equals(1))
        //    {
        //        cargarTablaEgresosMes(fec);


        //        foreach (DataGridViewRow row in GV.Rows)
        //        {
        //            sumatoriaE += Convert.ToDouble(row.Cells["Monto (-)"].Value);

        //        }

        //        txtSumaEgresos.Text = Convert.ToString(sumatoriaE);
        //    }
        //    if (comboBusqueda.SelectedIndex.Equals(2))
        //    {
        //        cargarTablaMovimientosMes(fec);

        //        foreach (DataGridViewRow row in GV.Rows)
        //        {

        //            if (Convert.ToString(row.Cells["Movimiento"].Value).Equals("Ingreso"))
        //            {
        //                sumatoriaI += Convert.ToDouble(row.Cells["Monto (+/-)"].Value);
        //            }
        //            else
        //            {
        //                sumatoriaE += Convert.ToDouble(row.Cells["Monto (+/-)"].Value);
        //            }
        //        }


        //        txtSumaIngresos.Text = Convert.ToString(sumatoriaI);
        //        txtSumaEgresos.Text = Convert.ToString(sumatoriaE);
        //        lblTabla.ForeColor = Color.DarkGoldenrod;
        //        double total = sumatoriaI - sumatoriaE;
        //        if (total > 0)
        //        {
        //            lblTabla.ForeColor = Color.Green;
        //            lblTabla.Text = "Ganancia del Mes: " + (sumatoriaI - sumatoriaE) + " USD";
        //        }
        //        else
        //        {
        //            lblTabla.ForeColor = Color.Red;
        //            lblTabla.Text = "Pérdida del Mes: " + -1 * (sumatoriaI - sumatoriaE) + " USD";
        //        }


        //    }

        //    if ((txtSumaEgresos.Text.Equals("0") || txtSumaEgresos.Text.Equals("")) && (txtSumaIngresos.Text.Equals("0") || txtSumaIngresos.Text.Equals("")))
        //    {
        //        string mes="";
        //        switch (fec)
        //        {
        //            case "01": mes = "Enero"; break;
        //            case "02": mes = "Febrero"; break;
        //            case "03": mes = "Marzo"; break;
        //            case "04": mes = "Abril"; break;
        //            case "05": mes = "Mayo"; break;
        //            case "06": mes = "Junio"; break;
        //            case "07": mes = "Julio"; break;
        //            case "08": mes = "Agosto"; break;
        //            case "09": mes = "Septiembre"; break;
        //            case "10": mes = "Octubre"; break;
        //            case "11": mes = "Noviembre"; break;
        //            case "12": mes = "Diciembre"; break;
        //        }
        //        lblTabla.ForeColor = Color.Black;
        //        lblTabla.Text = "No se encontraron registros para el mes de "+mes;

        //    }
        //    else
        //    {
        //        txtFecha.Enabled = false;
        //        btnBuscar.Enabled = false;
        //        lblBuscar.ForeColor = Color.Black;
        //        lblBuscar.Text = "Seleccione una Búsqueda";

        //    }
        //    btnBuscar.BackColor = Color.Black;
        //    btnBuscar.ForeColor = Color.White;
            
        //}

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnMes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.ShowDialog();
        }
    }
}
