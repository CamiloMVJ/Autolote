namespace AutoloteInfo
{
    partial class PruebaConexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEliminar = new Button();
            btnTabla = new Button();
            btnActualizarVehiculo = new Button();
            btnAgregar = new Button();
            txtMarca = new TextBox();
            txtPrecio = new TextBox();
            txtEstado = new TextBox();
            txtAñoFab = new TextBox();
            txtColor = new TextBox();
            txtChasis = new TextBox();
            dgvCarros = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDescripcion = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCarros).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(539, 139);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 28);
            btnEliminar.TabIndex = 41;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnTabla
            // 
            btnTabla.AutoSize = true;
            btnTabla.ForeColor = SystemColors.ControlText;
            btnTabla.Location = new Point(774, 262);
            btnTabla.Name = "btnTabla";
            btnTabla.Size = new Size(104, 29);
            btnTabla.TabIndex = 40;
            btnTabla.Text = "Obtener Tabla";
            btnTabla.UseVisualStyleBackColor = true;
            btnTabla.Click += btnTabla_Click;
            // 
            // btnActualizarVehiculo
            // 
            btnActualizarVehiculo.Location = new Point(539, 69);
            btnActualizarVehiculo.Name = "btnActualizarVehiculo";
            btnActualizarVehiculo.Size = new Size(150, 28);
            btnActualizarVehiculo.TabIndex = 39;
            btnActualizarVehiculo.Text = "Actualizar Vehiculo";
            btnActualizarVehiculo.UseVisualStyleBackColor = true;
            btnActualizarVehiculo.Click += btnActualizarVehiculo_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(539, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 28);
            btnAgregar.TabIndex = 38;
            btnAgregar.Text = "Agregar Vehículo";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(116, 40);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(125, 26);
            txtMarca.TabIndex = 37;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(116, 71);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(125, 26);
            txtPrecio.TabIndex = 36;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(116, 104);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(125, 26);
            txtEstado.TabIndex = 35;
            // 
            // txtAñoFab
            // 
            txtAñoFab.Location = new Point(116, 137);
            txtAñoFab.Name = "txtAñoFab";
            txtAñoFab.Size = new Size(125, 26);
            txtAñoFab.TabIndex = 34;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(116, 205);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(125, 26);
            txtColor.TabIndex = 32;
            // 
            // txtChasis
            // 
            txtChasis.Location = new Point(116, 10);
            txtChasis.Name = "txtChasis";
            txtChasis.Size = new Size(190, 26);
            txtChasis.TabIndex = 31;
            // 
            // dgvCarros
            // 
            dgvCarros.AllowUserToAddRows = false;
            dgvCarros.AllowUserToDeleteRows = false;
            dgvCarros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarros.Dock = DockStyle.Bottom;
            dgvCarros.Location = new Point(0, 297);
            dgvCarros.Margin = new Padding(3, 4, 3, 4);
            dgvCarros.Name = "dgvCarros";
            dgvCarros.ReadOnly = true;
            dgvCarros.RowHeadersWidth = 51;
            dgvCarros.RowTemplate.Height = 25;
            dgvCarros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarros.Size = new Size(905, 257);
            dgvCarros.TabIndex = 30;
            dgvCarros.CellClick += dgvCarros_CellClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 111);
            label7.Name = "label7";
            label7.Size = new Size(50, 19);
            label7.TabIndex = 29;
            label7.Text = "Estado";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 46);
            label6.Name = "label6";
            label6.Size = new Size(47, 19);
            label6.TabIndex = 28;
            label6.Text = "Marca";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 78);
            label5.Name = "label5";
            label5.Size = new Size(46, 19);
            label5.TabIndex = 27;
            label5.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 144);
            label4.Name = "label4";
            label4.Size = new Size(56, 19);
            label4.TabIndex = 26;
            label4.Text = "AñoFab";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 212);
            label2.Name = "label2";
            label2.Size = new Size(42, 19);
            label2.TabIndex = 24;
            label2.Text = "Color";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(48, 19);
            label1.TabIndex = 23;
            label1.Text = "Chasis";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(116, 173);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(125, 26);
            txtDescripcion.TabIndex = 43;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 180);
            label3.Name = "label3";
            label3.Size = new Size(79, 19);
            label3.TabIndex = 42;
            label3.Text = "Descripcion";
            // 
            // PruebaConexion
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 554);
            Controls.Add(txtDescripcion);
            Controls.Add(label3);
            Controls.Add(btnEliminar);
            Controls.Add(btnTabla);
            Controls.Add(btnActualizarVehiculo);
            Controls.Add(btnAgregar);
            Controls.Add(txtMarca);
            Controls.Add(txtPrecio);
            Controls.Add(txtEstado);
            Controls.Add(txtAñoFab);
            Controls.Add(txtColor);
            Controls.Add(txtChasis);
            Controls.Add(dgvCarros);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PruebaConexion";
            Text = "PruebaConexion";
            Load += PruebaConexion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCarros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnTabla;
        private Button btnActualizarVehiculo;
        private Button btnAgregar;
        private TextBox txtMarca;
        private TextBox txtPrecio;
        private TextBox txtEstado;
        private TextBox txtAñoFab;
        private TextBox txtColor;
        private TextBox txtChasis;
        private DataGridView dgvCarros;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtDescripcion;
        private Label label3;
    }
}