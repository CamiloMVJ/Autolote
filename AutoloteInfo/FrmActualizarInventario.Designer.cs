namespace AutoloteInfo
{
    partial class FrmActualizarInventario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvCarros = new System.Windows.Forms.DataGridView();
            this.txtChasis = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtDescripción = new System.Windows.Forms.TextBox();
            this.txtAñoFab = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizarVehiculo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrarInventario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chasis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "AñoFab";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Marca";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Estado";
            // 
            // dgvCarros
            // 
            this.dgvCarros.AllowUserToAddRows = false;
            this.dgvCarros.AllowUserToDeleteRows = false;
            this.dgvCarros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCarros.Location = new System.Drawing.Point(0, 321);
            this.dgvCarros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCarros.Name = "dgvCarros";
            this.dgvCarros.ReadOnly = true;
            this.dgvCarros.RowHeadersWidth = 51;
            this.dgvCarros.RowTemplate.Height = 25;
            this.dgvCarros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarros.Size = new System.Drawing.Size(883, 271);
            this.dgvCarros.TabIndex = 11;
            this.dgvCarros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarros_CellClick);
            // 
            // txtChasis
            // 
            this.txtChasis.Location = new System.Drawing.Point(116, 16);
            this.txtChasis.Name = "txtChasis";
            this.txtChasis.Size = new System.Drawing.Size(190, 27);
            this.txtChasis.TabIndex = 12;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(116, 221);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(125, 27);
            this.txtColor.TabIndex = 13;
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(116, 186);
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(432, 27);
            this.txtDescripción.TabIndex = 14;
            // 
            // txtAñoFab
            // 
            this.txtAñoFab.Location = new System.Drawing.Point(116, 150);
            this.txtAñoFab.Name = "txtAñoFab";
            this.txtAñoFab.Size = new System.Drawing.Size(125, 27);
            this.txtAñoFab.TabIndex = 15;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(116, 115);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(125, 27);
            this.txtEstado.TabIndex = 16;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(116, 80);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(125, 27);
            this.txtPrecio.TabIndex = 17;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(116, 47);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(125, 27);
            this.txtMarca.TabIndex = 18;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(539, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(142, 29);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar Vehículo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizarVehiculo
            // 
            this.btnActualizarVehiculo.Location = new System.Drawing.Point(539, 78);
            this.btnActualizarVehiculo.Name = "btnActualizarVehiculo";
            this.btnActualizarVehiculo.Size = new System.Drawing.Size(150, 29);
            this.btnActualizarVehiculo.TabIndex = 20;
            this.btnActualizarVehiculo.Text = "Actualizar Vehiculo";
            this.btnActualizarVehiculo.UseVisualStyleBackColor = true;
            this.btnActualizarVehiculo.Click += new System.EventHandler(this.btnActualizarVehiculo_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(549, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 21;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(539, 148);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 29);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnMostrarInventario
            // 
            this.btnMostrarInventario.Location = new System.Drawing.Point(12, 285);
            this.btnMostrarInventario.Name = "btnMostrarInventario";
            this.btnMostrarInventario.Size = new System.Drawing.Size(140, 29);
            this.btnMostrarInventario.TabIndex = 23;
            this.btnMostrarInventario.Text = "Mostrar Inventario";
            this.btnMostrarInventario.UseVisualStyleBackColor = true;
            this.btnMostrarInventario.Click += new System.EventHandler(this.btnMostrarInventario_Click);
            // 
            // FrmActualizarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 592);
            this.Controls.Add(this.btnMostrarInventario);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnActualizarVehiculo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtAñoFab);
            this.Controls.Add(this.txtDescripción);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtChasis);
            this.Controls.Add(this.dgvCarros);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmActualizarInventario";
            this.Text = "frmActualizarInventarioVehiculos";
            this.Load += new System.EventHandler(this.FrmActualizarInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvCarros;
        private TextBox txtChasis;
        private TextBox txtColor;
        private TextBox txtDescripción;
        private TextBox txtAñoFab;
        private TextBox txtEstado;
        private TextBox txtPrecio;
        private TextBox txtMarca;
        private Button btnAgregar;
        private Button btnActualizarVehiculo;
        private Button button3;
        private Button btnEliminar;
        private Button btnMostrarInventario;
    }
}