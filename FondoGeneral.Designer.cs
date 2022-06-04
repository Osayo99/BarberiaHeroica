namespace BarberH
{
    partial class FondoGeneral
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldoTemporal = new System.Windows.Forms.TextBox();
            this.lblsaldo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.GV = new System.Windows.Forms.DataGridView();
            this.lblMensajePrincipal = new System.Windows.Forms.Label();
            this.lblMensajeRegistros = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.comboBusqueda = new System.Windows.Forms.ComboBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.btnMes = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.lblTabla = new System.Windows.Forms.Label();
            this.lblSumaEgresos = new System.Windows.Forms.Label();
            this.txtSumaEgresos = new System.Windows.Forms.TextBox();
            this.txtSumaIngresos = new System.Windows.Forms.TextBox();
            this.lblSumaIngresos = new System.Windows.Forms.Label();
            this.rbIngreso = new System.Windows.Forms.RadioButton();
            this.rbEgreso = new System.Windows.Forms.RadioButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GV)).BeginInit();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoActual.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoActual.Location = new System.Drawing.Point(68, 98);
            this.lblSaldoActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(139, 25);
            this.lblSaldoActual.TabIndex = 3;
            this.lblSaldoActual.Text = "Saldo actual:";
            this.lblSaldoActual.Click += new System.EventHandler(this.lblSaldoActual_Click);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(69, 154);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(55, 18);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(35, 199);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 18);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(128, 151);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(195, 22);
            this.txtMonto.TabIndex = 7;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(128, 197);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(276, 82);
            this.txtDescripcion.TabIndex = 8;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.BackColor = System.Drawing.Color.Black;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(117, 543);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(131, 36);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 308);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Saldo temporal:";
            // 
            // txtSaldoTemporal
            // 
            this.txtSaldoTemporal.Enabled = false;
            this.txtSaldoTemporal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoTemporal.Location = new System.Drawing.Point(128, 302);
            this.txtSaldoTemporal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSaldoTemporal.Name = "txtSaldoTemporal";
            this.txtSaldoTemporal.Size = new System.Drawing.Size(276, 29);
            this.txtSaldoTemporal.TabIndex = 13;
            // 
            // lblsaldo
            // 
            this.lblsaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsaldo.Location = new System.Drawing.Point(241, 92);
            this.lblsaldo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsaldo.Name = "lblsaldo";
            this.lblsaldo.Size = new System.Drawing.Size(168, 32);
            this.lblsaldo.TabIndex = 14;
            this.lblsaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblsaldo.Click += new System.EventHandler(this.lblsaldo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(264, 543);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(131, 36);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // GV
            // 
            this.GV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV.BackgroundColor = System.Drawing.Color.White;
            this.GV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV.Location = new System.Drawing.Point(28, 70);
            this.GV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GV.Name = "GV";
            this.GV.RowHeadersWidth = 51;
            this.GV.Size = new System.Drawing.Size(789, 241);
            this.GV.TabIndex = 17;
            this.GV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_CellContentClick);
            // 
            // lblMensajePrincipal
            // 
            this.lblMensajePrincipal.Location = new System.Drawing.Point(48, 62);
            this.lblMensajePrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensajePrincipal.Name = "lblMensajePrincipal";
            this.lblMensajePrincipal.Size = new System.Drawing.Size(397, 37);
            this.lblMensajePrincipal.TabIndex = 20;
            this.lblMensajePrincipal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMensajePrincipal.Click += new System.EventHandler(this.lblMensajePrincipal_Click);
            // 
            // lblMensajeRegistros
            // 
            this.lblMensajeRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblMensajeRegistros.Location = new System.Drawing.Point(48, 335);
            this.lblMensajeRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensajeRegistros.Name = "lblMensajeRegistros";
            this.lblMensajeRegistros.Size = new System.Drawing.Size(401, 49);
            this.lblMensajeRegistros.TabIndex = 21;
            this.lblMensajeRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Enabled = false;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(619, 18);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(112, 36);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Location = new System.Drawing.Point(531, 166);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(76, 17);
            this.lblBusqueda.TabIndex = 23;
            this.lblBusqueda.Text = "Búsqueda:";
            // 
            // comboBusqueda
            // 
            this.comboBusqueda.FormattingEnabled = true;
            this.comboBusqueda.Items.AddRange(new object[] {
            "Ingresos",
            "Egresos",
            "Todos"});
            this.comboBusqueda.Location = new System.Drawing.Point(616, 162);
            this.comboBusqueda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBusqueda.Name = "comboBusqueda";
            this.comboBusqueda.Size = new System.Drawing.Size(133, 24);
            this.comboBusqueda.TabIndex = 24;
            this.comboBusqueda.Text = "Seleccione...";
            this.comboBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBusqueda_SelectedIndexChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFecha.Location = new System.Drawing.Point(1035, 551);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(132, 22);
            this.txtFecha.TabIndex = 25;
            this.txtFecha.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(775, 166);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 17);
            this.lblFecha.TabIndex = 26;
            this.lblFecha.Text = "Fecha:";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.btnMes);
            this.panel.Controls.Add(this.dt);
            this.panel.Controls.Add(this.lblTabla);
            this.panel.Controls.Add(this.lblSumaEgresos);
            this.panel.Controls.Add(this.txtSumaEgresos);
            this.panel.Controls.Add(this.txtSumaIngresos);
            this.panel.Controls.Add(this.lblSumaIngresos);
            this.panel.Controls.Add(this.GV);
            this.panel.Controls.Add(this.btnBuscar);
            this.panel.Location = new System.Drawing.Point(500, 140);
            this.panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(827, 388);
            this.panel.TabIndex = 27;
            // 
            // btnMes
            // 
            this.btnMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMes.BackColor = System.Drawing.Color.Black;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.ForeColor = System.Drawing.Color.White;
            this.btnMes.Location = new System.Drawing.Point(739, 18);
            this.btnMes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(79, 36);
            this.btnMes.TabIndex = 24;
            this.btnMes.Text = "Mes";
            this.btnMes.UseVisualStyleBackColor = false;
            this.btnMes.Visible = false;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // dt
            // 
            this.dt.Enabled = false;
            this.dt.Location = new System.Drawing.Point(335, 20);
            this.dt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(265, 22);
            this.dt.TabIndex = 23;
            this.dt.ValueChanged += new System.EventHandler(this.dt_ValueChanged);
            // 
            // lblTabla
            // 
            this.lblTabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabla.Location = new System.Drawing.Point(28, 315);
            this.lblTabla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(327, 62);
            this.lblTabla.TabIndex = 22;
            this.lblTabla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSumaEgresos
            // 
            this.lblSumaEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumaEgresos.AutoSize = true;
            this.lblSumaEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaEgresos.Location = new System.Drawing.Point(571, 353);
            this.lblSumaEgresos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSumaEgresos.Name = "lblSumaEgresos";
            this.lblSumaEgresos.Size = new System.Drawing.Size(105, 18);
            this.lblSumaEgresos.TabIndex = 21;
            this.lblSumaEgresos.Text = "Total Egresos:";
            // 
            // txtSumaEgresos
            // 
            this.txtSumaEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSumaEgresos.Enabled = false;
            this.txtSumaEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumaEgresos.Location = new System.Drawing.Point(684, 350);
            this.txtSumaEgresos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSumaEgresos.Name = "txtSumaEgresos";
            this.txtSumaEgresos.Size = new System.Drawing.Size(132, 26);
            this.txtSumaEgresos.TabIndex = 20;
            // 
            // txtSumaIngresos
            // 
            this.txtSumaIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSumaIngresos.Enabled = false;
            this.txtSumaIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumaIngresos.Location = new System.Drawing.Point(684, 319);
            this.txtSumaIngresos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSumaIngresos.Name = "txtSumaIngresos";
            this.txtSumaIngresos.Size = new System.Drawing.Size(132, 26);
            this.txtSumaIngresos.TabIndex = 19;
            // 
            // lblSumaIngresos
            // 
            this.lblSumaIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumaIngresos.AutoSize = true;
            this.lblSumaIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaIngresos.Location = new System.Drawing.Point(569, 322);
            this.lblSumaIngresos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSumaIngresos.Name = "lblSumaIngresos";
            this.lblSumaIngresos.Size = new System.Drawing.Size(106, 18);
            this.lblSumaIngresos.TabIndex = 18;
            this.lblSumaIngresos.Text = "Total Ingresos:";
            // 
            // rbIngreso
            // 
            this.rbIngreso.AutoSize = true;
            this.rbIngreso.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIngreso.ForeColor = System.Drawing.Color.Black;
            this.rbIngreso.Location = new System.Drawing.Point(92, 15);
            this.rbIngreso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbIngreso.Name = "rbIngreso";
            this.rbIngreso.Size = new System.Drawing.Size(125, 29);
            this.rbIngreso.TabIndex = 28;
            this.rbIngreso.TabStop = true;
            this.rbIngreso.Text = "INGRESOS";
            this.rbIngreso.UseVisualStyleBackColor = true;
            this.rbIngreso.CheckedChanged += new System.EventHandler(this.rbIngreso_CheckedChanged);
            // 
            // rbEgreso
            // 
            this.rbEgreso.AutoSize = true;
            this.rbEgreso.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEgreso.ForeColor = System.Drawing.Color.Black;
            this.rbEgreso.Location = new System.Drawing.Point(284, 15);
            this.rbEgreso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbEgreso.Name = "rbEgreso";
            this.rbEgreso.Size = new System.Drawing.Size(116, 29);
            this.rbEgreso.TabIndex = 29;
            this.rbEgreso.TabStop = true;
            this.rbEgreso.Text = "EGRESOS";
            this.rbEgreso.UseVisualStyleBackColor = true;
            this.rbEgreso.CheckedChanged += new System.EventHandler(this.rbEgreso_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.Black;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(500, 543);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(131, 36);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.BackColor = System.Drawing.Color.Black;
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(117, 543);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(131, 36);
            this.btnModificar.TabIndex = 31;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.Black;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.Location = new System.Drawing.Point(336, 144);
            this.btnVerificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(109, 36);
            this.btnVerificar.TabIndex = 32;
            this.btnVerificar.Text = "verificar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(717, 551);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 33;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(879, 551);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 34;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBuscar.Location = new System.Drawing.Point(852, 98);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(475, 38);
            this.lblBuscar.TabIndex = 35;
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnVerificar);
            this.panel1.Controls.Add(this.rbEgreso);
            this.panel1.Controls.Add(this.rbIngreso);
            this.panel1.Controls.Add(this.lblMensajePrincipal);
            this.panel1.Controls.Add(this.lblsaldo);
            this.panel1.Controls.Add(this.txtSaldoTemporal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.lblMonto);
            this.panel1.Controls.Add(this.lblMensajeRegistros);
            this.panel1.Controls.Add(this.lblSaldoActual);
            this.panel1.Location = new System.Drawing.Point(16, 140);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 388);
            this.panel1.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(49, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "FONDO GENERAL";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1371, 95);
            this.panel2.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1196, 543);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 40;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FondoGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1371, 613);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.comboBusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FondoGeneral";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GV)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaldoTemporal;
        private System.Windows.Forms.Label lblsaldo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView GV;
        private System.Windows.Forms.Label lblMensajePrincipal;
        private System.Windows.Forms.Label lblMensajeRegistros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.ComboBox comboBusqueda;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblSumaIngresos;
        private System.Windows.Forms.TextBox txtSumaEgresos;
        private System.Windows.Forms.TextBox txtSumaIngresos;
        private System.Windows.Forms.Label lblSumaEgresos;
        private System.Windows.Forms.RadioButton rbIngreso;
        private System.Windows.Forms.RadioButton rbEgreso;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVerificar;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}

