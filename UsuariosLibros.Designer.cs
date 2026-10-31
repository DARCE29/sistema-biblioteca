namespace ProyectoFinal
{
    partial class UsuariosLibros
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoLibro = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBTitulo = new System.Windows.Forms.TextBox();
            this.txtBAutor = new System.Windows.Forms.TextBox();
            this.dtpAniode = new System.Windows.Forms.DateTimePicker();
            this.txtBCategoria = new System.Windows.Forms.TextBox();
            this.txtBDispo = new System.Windows.Forms.TextBox();
            this.txtBUbicacion = new System.Windows.Forms.TextBox();
            this.txtBURL = new System.Windows.Forms.TextBox();
            this.numAccesos = new System.Windows.Forms.NumericUpDown();
            this.cboCondicion = new System.Windows.Forms.ComboBox();
            this.dataGridLibrosUsuarios = new System.Windows.Forms.DataGridView();
            this.buttAgregarLibro = new System.Windows.Forms.Button();
            this.buttBuscar = new System.Windows.Forms.Button();
            this.buttRegresar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrarTodosLibros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAccesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibrosUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Autor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Año de publicacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Categoria";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(623, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Disponibilidad";
            // 
            // cboTipoLibro
            // 
            this.cboTipoLibro.FormattingEnabled = true;
            this.cboTipoLibro.Items.AddRange(new object[] {
            "LibroDigital",
            "LibroFisico"});
            this.cboTipoLibro.Location = new System.Drawing.Point(627, 167);
            this.cboTipoLibro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTipoLibro.Name = "cboTipoLibro";
            this.cboTipoLibro.Size = new System.Drawing.Size(81, 24);
            this.cboTipoLibro.TabIndex = 6;
            this.cboTipoLibro.SelectedIndexChanged += new System.EventHandler(this.combTipoLibro_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tipo de libro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ubicacion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Condicion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "URL de descarga";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(433, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "# Accesos Disponibles";
            // 
            // txtBTitulo
            // 
            this.txtBTitulo.Location = new System.Drawing.Point(59, 85);
            this.txtBTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBTitulo.Name = "txtBTitulo";
            this.txtBTitulo.Size = new System.Drawing.Size(68, 22);
            this.txtBTitulo.TabIndex = 12;
            // 
            // txtBAutor
            // 
            this.txtBAutor.Location = new System.Drawing.Point(156, 85);
            this.txtBAutor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBAutor.Name = "txtBAutor";
            this.txtBAutor.Size = new System.Drawing.Size(68, 22);
            this.txtBAutor.TabIndex = 13;
            // 
            // dtpAniode
            // 
            this.dtpAniode.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAniode.Location = new System.Drawing.Point(261, 85);
            this.dtpAniode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpAniode.Name = "dtpAniode";
            this.dtpAniode.Size = new System.Drawing.Size(135, 22);
            this.dtpAniode.TabIndex = 15;
            // 
            // txtBCategoria
            // 
            this.txtBCategoria.Location = new System.Drawing.Point(437, 85);
            this.txtBCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBCategoria.Name = "txtBCategoria";
            this.txtBCategoria.Size = new System.Drawing.Size(148, 22);
            this.txtBCategoria.TabIndex = 16;
            // 
            // txtBDispo
            // 
            this.txtBDispo.Location = new System.Drawing.Point(627, 85);
            this.txtBDispo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBDispo.Name = "txtBDispo";
            this.txtBDispo.Size = new System.Drawing.Size(68, 22);
            this.txtBDispo.TabIndex = 17;
            this.txtBDispo.TextChanged += new System.EventHandler(this.txtBDispo_TextChanged);
            // 
            // txtBUbicacion
            // 
            this.txtBUbicacion.Location = new System.Drawing.Point(59, 167);
            this.txtBUbicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBUbicacion.Name = "txtBUbicacion";
            this.txtBUbicacion.Size = new System.Drawing.Size(68, 22);
            this.txtBUbicacion.TabIndex = 18;
            // 
            // txtBURL
            // 
            this.txtBURL.Location = new System.Drawing.Point(263, 167);
            this.txtBURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBURL.Name = "txtBURL";
            this.txtBURL.Size = new System.Drawing.Size(133, 22);
            this.txtBURL.TabIndex = 20;
            // 
            // numAccesos
            // 
            this.numAccesos.Location = new System.Drawing.Point(439, 166);
            this.numAccesos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numAccesos.Name = "numAccesos";
            this.numAccesos.Size = new System.Drawing.Size(148, 22);
            this.numAccesos.TabIndex = 21;
            // 
            // cboCondicion
            // 
            this.cboCondicion.FormattingEnabled = true;
            this.cboCondicion.Items.AddRange(new object[] {
            "Nuevo",
            "Usado",
            "Deteriorado"});
            this.cboCondicion.Location = new System.Drawing.Point(156, 166);
            this.cboCondicion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCondicion.Name = "cboCondicion";
            this.cboCondicion.Size = new System.Drawing.Size(68, 24);
            this.cboCondicion.TabIndex = 27;
            // 
            // dataGridLibrosUsuarios
            // 
            this.dataGridLibrosUsuarios.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataGridLibrosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLibrosUsuarios.Location = new System.Drawing.Point(19, 311);
            this.dataGridLibrosUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridLibrosUsuarios.Name = "dataGridLibrosUsuarios";
            this.dataGridLibrosUsuarios.RowHeadersWidth = 82;
            this.dataGridLibrosUsuarios.RowTemplate.Height = 33;
            this.dataGridLibrosUsuarios.Size = new System.Drawing.Size(985, 97);
            this.dataGridLibrosUsuarios.TabIndex = 28;
            this.dataGridLibrosUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLibrosUsuarios_CellContentClick);
            // 
            // buttAgregarLibro
            // 
            this.buttAgregarLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttAgregarLibro.Location = new System.Drawing.Point(19, 258);
            this.buttAgregarLibro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttAgregarLibro.Name = "buttAgregarLibro";
            this.buttAgregarLibro.Size = new System.Drawing.Size(213, 34);
            this.buttAgregarLibro.TabIndex = 29;
            this.buttAgregarLibro.Text = "Agregar Libro";
            this.buttAgregarLibro.UseVisualStyleBackColor = true;
            this.buttAgregarLibro.Click += new System.EventHandler(this.buttAgregarLibro_Click);
            // 
            // buttBuscar
            // 
            this.buttBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttBuscar.Location = new System.Drawing.Point(278, 258);
            this.buttBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttBuscar.Name = "buttBuscar";
            this.buttBuscar.Size = new System.Drawing.Size(223, 34);
            this.buttBuscar.TabIndex = 31;
            this.buttBuscar.Text = "Buscar Libro";
            this.buttBuscar.UseVisualStyleBackColor = true;
            this.buttBuscar.Click += new System.EventHandler(this.buttBuscar_Click);
            // 
            // buttRegresar
            // 
            this.buttRegresar.BackColor = System.Drawing.Color.DimGray;
            this.buttRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttRegresar.ForeColor = System.Drawing.Color.White;
            this.buttRegresar.Location = new System.Drawing.Point(917, 427);
            this.buttRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttRegresar.Name = "buttRegresar";
            this.buttRegresar.Size = new System.Drawing.Size(99, 34);
            this.buttRegresar.TabIndex = 32;
            this.buttRegresar.Text = "Regresar";
            this.buttRegresar.UseVisualStyleBackColor = false;
            this.buttRegresar.Click += new System.EventHandler(this.buttRegresar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnMostrarTodosLibros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttRegresar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttBuscar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttAgregarLibro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataGridLibrosUsuarios);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboCondicion);
            this.groupBox1.Controls.Add(this.cboTipoLibro);
            this.groupBox1.Controls.Add(this.numAccesos);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBURL);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBUbicacion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBDispo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBCategoria);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpAniode);
            this.groupBox1.Controls.Add(this.txtBTitulo);
            this.groupBox1.Controls.Add(this.txtBAutor);
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1023, 468);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnMostrarTodosLibros
            // 
            this.btnMostrarTodosLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodosLibros.Location = new System.Drawing.Point(772, 258);
            this.btnMostrarTodosLibros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMostrarTodosLibros.Name = "btnMostrarTodosLibros";
            this.btnMostrarTodosLibros.Size = new System.Drawing.Size(223, 34);
            this.btnMostrarTodosLibros.TabIndex = 33;
            this.btnMostrarTodosLibros.Text = "Mostrar todos los libros";
            this.btnMostrarTodosLibros.UseVisualStyleBackColor = true;
            this.btnMostrarTodosLibros.Click += new System.EventHandler(this.btnMostrarTodosLibros_Click);
            // 
            // UsuariosLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 540);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UsuariosLibros";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UsuariosLibros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAccesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibrosUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoLibro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBTitulo;
        private System.Windows.Forms.TextBox txtBAutor;
        private System.Windows.Forms.DateTimePicker dtpAniode;
        private System.Windows.Forms.TextBox txtBCategoria;
        private System.Windows.Forms.TextBox txtBDispo;
        private System.Windows.Forms.TextBox txtBUbicacion;
        private System.Windows.Forms.TextBox txtBURL;
        private System.Windows.Forms.NumericUpDown numAccesos;
        private System.Windows.Forms.ComboBox cboCondicion;
        private System.Windows.Forms.DataGridView dataGridLibrosUsuarios;
        private System.Windows.Forms.Button buttAgregarLibro;
        private System.Windows.Forms.Button buttBuscar;
        private System.Windows.Forms.Button buttRegresar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMostrarTodosLibros;
    }
}

