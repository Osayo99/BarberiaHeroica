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

namespace BarberH
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        Validaciones obj = new Validaciones();

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }
        public void mostrarGrid()
        {
            DataTable datos = ProductoCRUD.listar();
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

        private void limpiar()
        {
            tboBuscar.Text = "";
            tboIdProducto.Text = "";
            tboNombre.Text = "";
            tboExistencia.Text = "";
            tboPrecioUni.Text = "";
            tboPrecioMay.Text = "";
           
        }

        private void seleccion()
        {
            String campo1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String campo2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String campo3 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String campo4 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            String campo5 = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            tboIdProducto.Text = campo1;
            tboNombre.Text = campo2;
            tboExistencia.Text = campo3;
            tboPrecioUni.Text = campo4;
            tboPrecioMay.Text = campo5;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int resultado = 0;
            bool esNumerico = Int32.TryParse(tboBuscar.Text, out resultado);
            if (tboBuscar.Text.Trim() == "" || esNumerico == false)
            {
                MessageBox.Show("Debe ingresar un Id de Producto valido");
            }
            else
            {
                Producto prd = ProductoCRUD.buscar(int.Parse(tboBuscar.Text.Trim()));
                if (prd == null)
                {
                    MessageBox.Show("No existe el Producto con el Id: " + tboBuscar.Text);
                }
                else
                {
                    tboIdProducto.Text = prd.id_producto1.ToString();
                    tboNombre.Text = prd.nombre_producto1;
                    tboExistencia.Text = prd.cant_existencia1.ToString();
                    tboPrecioUni.Text = prd.precio_unitario1.ToString();
                    tboPrecioMay.Text = prd.precio_mayorista1.ToString();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tboIdProducto.Text == "")
            {
                MessageBox.Show("Consulte un Id de Producto primero");
            }
            else
            {
                try
                {
                    Producto pd = new Producto();
                    pd.id_producto1 = Convert.ToInt32(tboIdProducto.Text.Trim());
                    pd.nombre_producto1 = tboNombre.Text.Trim();
                    pd.cant_existencia1 = Convert.ToInt32(tboExistencia.Text.Trim());
                    //pd.precio_unitario1 = Convert.ToDecimal(tboPrecioUni.Text.Trim().Replace(".", ","));
                    //pd.precio_mayorista1 = Convert.ToDecimal(tboPrecioMay.Text.Trim().Replace(".", ","));

                    string precio = tboPrecioUni.Text.Replace(".", ",");
                    pd.precio_unitario1 = Convert.ToDecimal(precio);
                    string precio2 = tboPrecioMay.Text.Replace(".", ",");
                    pd.precio_mayorista1 = Convert.ToDecimal(precio2);

                    if (ProductoCRUD.actualizar(pd))
                    {
                        mostrarGrid();
                        limpiar();
                        MessageBox.Show("El Producto se actualizo correctamente");
                    }
                    else
                    {
                        mostrarGrid();
                        limpiar();
                        MessageBox.Show("El Producto no se pudo actualizar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //if (tboIdProducto.Text.Trim() == null)
            //{
            //    MessageBox.Show("Debe ingresar un ID valido");
            //}

            //else
            //{
                try
                {
                //ValidarCampos();
                Producto pd = new Producto();
                    //pd.id_producto1 = Convert.ToInt32(tboIdProducto.Text.Trim());
                    pd.nombre_producto1 = tboNombre.Text.Trim();
                    pd.cant_existencia1 = Convert.ToInt32(tboExistencia.Text.Trim());
                    pd.precio_unitario1 = Convert.ToDecimal(tboPrecioUni.Text.Trim().Replace(".", ","));
                    pd.precio_mayorista1 = Convert.ToDecimal(tboPrecioMay.Text.Trim().Replace(".", ","));

                    if (ProductoCRUD.GuardarProducto(pd))
                    {
                        mostrarGrid();
                        limpiar();
                        MessageBox.Show("El Producto se guardo correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El Producto no se pudo guardar");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //}
        }

        //private bool ValidarCampos()
        //{
        //    bool ok = true;
        //    if (tboNombre.Text == "")
        //    {
        //        ok = false;
        //        errorProvider1.SetError(tboNombre, "Ingresar nombre");
        //    }
        //    return ok;
        //}





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiar();
            seleccion();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tboIdProducto.Text == "")
            {
                MessageBox.Show("Consulte un Id de Producto primero");
            }
            else
            {
                try
                {
                    if (ProductoCRUD.eliminar(Int32.Parse(tboIdProducto.Text.Trim())))
                    {
                        mostrarGrid();
                        limpiar();
                        MessageBox.Show("Se elimnino correctamente");
                    }
                    else
                    {
                        mostrarGrid();
                        limpiar();
                        MessageBox.Show("No se pude eliminar");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwind, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }

        private void tboNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarLetras(e);
        }

        private void tboExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarNumeros(e);
        }

        private void tboPrecioUni_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarDecimal(e);
        }

        private void tboPrecioMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj.ValidarDecimal(e);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            this.Hide();
            men.ShowDialog();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                ExportarExcel(dataGridView1);
            }
            else
            {
                MessageBox.Show("Debe listar los productos primero");
            }
        }

        public void ExportarExcel(DataGridView dtg)
        {
            Microsoft.Office.Interop.Excel.Application exportarDTG = new Microsoft.Office.Interop.Excel.Application();
            exportarDTG.Application.Workbooks.Add(true);

            Microsoft.Office.Interop.Excel.Worksheet sheet = exportarDTG.ActiveSheet;
            Microsoft.Office.Interop.Excel.Range formatRange;
            formatRange = sheet.get_Range("a1", "e1");
            formatRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            formatRange.EntireColumn.ColumnWidth = 18;
            formatRange.EntireColumn.AutoFit();
            formatRange.EntireRow.AutoFit();
            formatRange.WrapText = true;
            formatRange.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            int indicecolumna = 0;
            foreach (DataGridViewColumn columna in dtg.Columns)
            {
                indicecolumna++;
                exportarDTG.Cells[1, indicecolumna] = columna.Name;

                sheet.Cells[1, indicecolumna].Font.Bold = true;
                formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.AliceBlue);
                Microsoft.Office.Interop.Excel.Range cell = formatRange.Cells[1, indicecolumna];
                Microsoft.Office.Interop.Excel.Borders border = cell.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

            }
            int indicefila = 0;
            foreach (DataGridViewRow fila in dtg.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn columna in dtg.Columns)
                {
                    indicecolumna++;
                    exportarDTG.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;

                    Microsoft.Office.Interop.Excel.Range cell = formatRange.Cells[indicefila + 1, indicecolumna];
                    Microsoft.Office.Interop.Excel.Borders border = cell.Borders;
                    border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    border.Weight = 2d;

                }
            }
            exportarDTG.Visible = true;
        }
    }
}   
