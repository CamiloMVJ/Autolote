namespace AutoloteInfo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCarros = new System.Windows.Forms.DataGridView();
            this.btnVerCarros = new System.Windows.Forms.Button();
            this.btnVerClientes = new System.Windows.Forms.Button();
            this.btnAñadirCarro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCarros
            // 
            this.dgvCarros.AllowUserToAddRows = false;
            this.dgvCarros.AllowUserToDeleteRows = false;
            this.dgvCarros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCarros.Location = new System.Drawing.Point(0, 191);
            this.dgvCarros.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCarros.Name = "dgvCarros";
            this.dgvCarros.ReadOnly = true;
            this.dgvCarros.RowHeadersWidth = 51;
            this.dgvCarros.RowTemplate.Height = 25;
            this.dgvCarros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarros.Size = new System.Drawing.Size(900, 306);
            this.dgvCarros.TabIndex = 10;
            this.dgvCarros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // btnVerCarros
            // 
            this.btnVerCarros.Location = new System.Drawing.Point(607, 29);
            this.btnVerCarros.Name = "btnVerCarros";
            this.btnVerCarros.Size = new System.Drawing.Size(144, 33);
            this.btnVerCarros.TabIndex = 11;
            this.btnVerCarros.Text = "Ver Carros";
            this.btnVerCarros.UseVisualStyleBackColor = true;
            this.btnVerCarros.Click += new System.EventHandler(this.btnVerCarros_Click);
            // 
            // btnVerClientes
            // 
            this.btnVerClientes.Location = new System.Drawing.Point(757, 29);
            this.btnVerClientes.Name = "btnVerClientes";
            this.btnVerClientes.Size = new System.Drawing.Size(131, 33);
            this.btnVerClientes.TabIndex = 12;
            this.btnVerClientes.Text = "Ver Clientes";
            this.btnVerClientes.UseVisualStyleBackColor = true;
            // 
            // btnAñadirCarro
            // 
            this.btnAñadirCarro.Location = new System.Drawing.Point(45, 12);
            this.btnAñadirCarro.Name = "btnAñadirCarro";
            this.btnAñadirCarro.Size = new System.Drawing.Size(305, 34);
            this.btnAñadirCarro.TabIndex = 13;
            this.btnAñadirCarro.Text = "Actualizar inventario de Carro";
            this.btnAñadirCarro.UseVisualStyleBackColor = true;
            this.btnAñadirCarro.Click += new System.EventHandler(this.btnAñadirCarro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 497);
            this.Controls.Add(this.btnAñadirCarro);
            this.Controls.Add(this.btnVerClientes);
            this.Controls.Add(this.btnVerCarros);
            this.Controls.Add(this.dgvCarros);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Autolote";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvCarros;
        private Button btnVerCarros;
        private Button btnVerClientes;
        private Button btnAñadirCarro;
    }
}