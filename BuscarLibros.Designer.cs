namespace ProyectoFinal
{
    partial class BuscarLibros
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBCategoria = new System.Windows.Forms.TextBox();
            this.txtBAutor = new System.Windows.Forms.TextBox();
            this.txtBTitulo = new System.Windows.Forms.TextBox();
            this.buttBuscarLibro = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttRegresar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDispo = new System.Windows.Forms.ComboBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Disponibilidad";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Categoria";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Autor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Titulo";
            // 
            // txtBCategoria
            // 
            this.txtBCategoria.Location = new System.Drawing.Point(213, 101);
            this.txtBCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBCategoria.Name = "txtBCategoria";
            this.txtBCategoria.Size = new System.Drawing.Size(68, 22);
            this.txtBCategoria.TabIndex = 20;
            this.txtBCategoria.TextChanged += new System.EventHandler(this.txtBCategoria_TextChanged);
            // 
            // txtBAutor
            // 
            this.txtBAutor.Location = new System.Drawing.Point(125, 101);
            this.txtBAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBAutor.Name = "txtBAutor";
            this.txtBAutor.Size = new System.Drawing.Size(64, 22);
            this.txtBAutor.TabIndex = 19;
            // 
            // txtBTitulo
            // 
            this.txtBTitulo.Location = new System.Drawing.Point(28, 101);
            this.txtBTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBTitulo.Name = "txtBTitulo";
            this.txtBTitulo.Size = new System.Drawing.Size(64, 22);
            this.txtBTitulo.TabIndex = 18;
            // 
            // buttBuscarLibro
            // 
            this.buttBuscarLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttBuscarLibro.Location = new System.Drawing.Point(28, 143);
            this.buttBuscarLibro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttBuscarLibro.Name = "buttBuscarLibro";
            this.buttBuscarLibro.Size = new System.Drawing.Size(187, 52);
            this.buttBuscarLibro.TabIndex = 22;
            this.buttBuscarLibro.Text = "Buscar Libro";
            this.buttBuscarLibro.UseVisualStyleBackColor = true;
            this.buttBuscarLibro.Click += new System.EventHandler(this.buttBuscarLibro_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 207);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(977, 228);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttRegresar
            // 
            this.buttRegresar.BackColor = System.Drawing.Color.DimGray;
            this.buttRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttRegresar.ForeColor = System.Drawing.Color.White;
            this.buttRegresar.Location = new System.Drawing.Point(913, 439);
            this.buttRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttRegresar.Name = "buttRegresar";
            this.buttRegresar.Size = new System.Drawing.Size(107, 33);
            this.buttRegresar.TabIndex = 24;
            this.buttRegresar.Text = "Regresar";
            this.buttRegresar.UseVisualStyleBackColor = false;
            this.buttRegresar.Click += new System.EventHandler(this.buttRegresar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.cboDispo);
            this.groupBox1.Controls.Add(this.btnLimpiarBusqueda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttRegresar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBCategoria);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBTitulo);
            this.groupBox1.Controls.Add(this.txtBAutor);
            this.groupBox1.Controls.Add(this.buttBuscarLibro);
            this.groupBox1.Location = new System.Drawing.Point(39, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1027, 479);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cboDispo
            // 
            this.cboDispo.FormattingEnabled = true;
            this.cboDispo.Items.AddRange(new object[] {
            "Disponible",
            "No Disponible"});
            this.cboDispo.Location = new System.Drawing.Point(312, 101);
            this.cboDispo.Name = "cboDispo";
            this.cboDispo.Size = new System.Drawing.Size(121, 24);
            this.cboDispo.TabIndex = 27;
            this.cboDispo.SelectedIndexChanged += new System.EventHandler(this.cboDispo_SelectedIndexChanged);
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(818, 143);
            this.btnLimpiarBusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(187, 52);
            this.btnLimpiarBusqueda.TabIndex = 26;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 43);
            this.label1.TabIndex = 25;
            this.label1.Text = "Libros";
            // 
            // BuscarLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 542);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BuscarLibros";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BuscarLibros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBCategoria;
        private System.Windows.Forms.TextBox txtBAutor;
        private System.Windows.Forms.TextBox txtBTitulo;
        private System.Windows.Forms.Button buttBuscarLibro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttRegresar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.ComboBox cboDispo;
    }
}