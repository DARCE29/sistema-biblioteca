namespace ProyectoFinal
{
    partial class Prestamos
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
            this.label7 = new System.Windows.Forms.Label();
            this.combTipoLibro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBAutor = new System.Windows.Forms.TextBox();
            this.txtBTitulo = new System.Windows.Forms.TextBox();
            this.txtBNombre = new System.Windows.Forms.TextBox();
            this.combTipoUser = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttRegisPrestamo = new System.Windows.Forms.Button();
            this.butDevolPrestamo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttRegresar = new System.Windows.Forms.Button();
            this.lblFechahoy = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblfechadevolucion = new System.Windows.Forms.Label();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.LVPrestamos = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(13, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prestamo de Libros";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tipo de libro";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // combTipoLibro
            // 
            this.combTipoLibro.FormattingEnabled = true;
            this.combTipoLibro.Items.AddRange(new object[] {
            "LibroDigital",
            "LibroFisico"});
            this.combTipoLibro.Location = new System.Drawing.Point(173, 59);
            this.combTipoLibro.Margin = new System.Windows.Forms.Padding(2);
            this.combTipoLibro.Name = "combTipoLibro";
            this.combTipoLibro.Size = new System.Drawing.Size(62, 21);
            this.combTipoLibro.TabIndex = 10;
            this.combTipoLibro.SelectedIndexChanged += new System.EventHandler(this.combTipoLibro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Autor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Titulo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtBAutor
            // 
            this.txtBAutor.Location = new System.Drawing.Point(100, 60);
            this.txtBAutor.Margin = new System.Windows.Forms.Padding(2);
            this.txtBAutor.Name = "txtBAutor";
            this.txtBAutor.Size = new System.Drawing.Size(52, 20);
            this.txtBAutor.TabIndex = 21;
            this.txtBAutor.TextChanged += new System.EventHandler(this.txtBAutor_TextChanged);
            // 
            // txtBTitulo
            // 
            this.txtBTitulo.Location = new System.Drawing.Point(27, 60);
            this.txtBTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtBTitulo.Name = "txtBTitulo";
            this.txtBTitulo.Size = new System.Drawing.Size(52, 20);
            this.txtBTitulo.TabIndex = 20;
            this.txtBTitulo.TextChanged += new System.EventHandler(this.txtBTitulo_TextChanged);
            // 
            // txtBNombre
            // 
            this.txtBNombre.Location = new System.Drawing.Point(261, 60);
            this.txtBNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtBNombre.Name = "txtBNombre";
            this.txtBNombre.Size = new System.Drawing.Size(78, 20);
            this.txtBNombre.TabIndex = 30;
            this.txtBNombre.TextChanged += new System.EventHandler(this.txtBNombre_TextChanged);
            // 
            // combTipoUser
            // 
            this.combTipoUser.FormattingEnabled = true;
            this.combTipoUser.Items.AddRange(new object[] {
            "Estudiante",
            "Profesor",
            "Administrativo"});
            this.combTipoUser.Location = new System.Drawing.Point(366, 60);
            this.combTipoUser.Margin = new System.Windows.Forms.Padding(2);
            this.combTipoUser.Name = "combTipoUser";
            this.combTipoUser.Size = new System.Drawing.Size(62, 21);
            this.combTipoUser.TabIndex = 29;
            this.combTipoUser.SelectedIndexChanged += new System.EventHandler(this.combTipoUser_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(363, 40);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Tipo de usuario";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(258, 39);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Nombre Usuario";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // buttRegisPrestamo
            // 
            this.buttRegisPrestamo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttRegisPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttRegisPrestamo.Location = new System.Drawing.Point(28, 112);
            this.buttRegisPrestamo.Margin = new System.Windows.Forms.Padding(2);
            this.buttRegisPrestamo.Name = "buttRegisPrestamo";
            this.buttRegisPrestamo.Size = new System.Drawing.Size(119, 48);
            this.buttRegisPrestamo.TabIndex = 31;
            this.buttRegisPrestamo.Text = "Registrar Prestamo";
            this.buttRegisPrestamo.UseVisualStyleBackColor = false;
            this.buttRegisPrestamo.Click += new System.EventHandler(this.buttRegisPrestamo_Click);
            // 
            // butDevolPrestamo
            // 
            this.butDevolPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDevolPrestamo.Location = new System.Drawing.Point(151, 112);
            this.butDevolPrestamo.Margin = new System.Windows.Forms.Padding(2);
            this.butDevolPrestamo.Name = "butDevolPrestamo";
            this.butDevolPrestamo.Size = new System.Drawing.Size(119, 48);
            this.butDevolPrestamo.TabIndex = 32;
            this.butDevolPrestamo.Text = "Registrar Devolucion";
            this.butDevolPrestamo.UseVisualStyleBackColor = true;
            this.butDevolPrestamo.Click += new System.EventHandler(this.butDevolPrestamo_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(274, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 48);
            this.button1.TabIndex = 34;
            this.button1.Text = "Historial de prestamos por usuario";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttRegresar
            // 
            this.buttRegresar.BackColor = System.Drawing.Color.DimGray;
            this.buttRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttRegresar.ForeColor = System.Drawing.Color.White;
            this.buttRegresar.Location = new System.Drawing.Point(726, 316);
            this.buttRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.buttRegresar.Name = "buttRegresar";
            this.buttRegresar.Size = new System.Drawing.Size(77, 27);
            this.buttRegresar.TabIndex = 35;
            this.buttRegresar.Text = "Regresar";
            this.buttRegresar.UseVisualStyleBackColor = false;
            this.buttRegresar.Click += new System.EventHandler(this.buttRegresar_Click);
            // 
            // lblFechahoy
            // 
            this.lblFechahoy.AutoSize = true;
            this.lblFechahoy.Location = new System.Drawing.Point(460, 40);
            this.lblFechahoy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechahoy.Name = "lblFechahoy";
            this.lblFechahoy.Size = new System.Drawing.Size(143, 13);
            this.lblFechahoy.TabIndex = 36;
            this.lblFechahoy.Text = "Fecha de inicio del Prestamo";
            this.lblFechahoy.Click += new System.EventHandler(this.lblFechahoy_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(463, 61);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaInicio.TabIndex = 37;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblfechadevolucion
            // 
            this.lblfechadevolucion.AutoSize = true;
            this.lblfechadevolucion.Location = new System.Drawing.Point(618, 39);
            this.lblfechadevolucion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblfechadevolucion.Name = "lblfechadevolucion";
            this.lblfechadevolucion.Size = new System.Drawing.Size(112, 13);
            this.lblfechadevolucion.TabIndex = 38;
            this.lblfechadevolucion.Text = "Fecha de Devolución ";
            this.lblfechadevolucion.Click += new System.EventHandler(this.lblfechadevolucion_Click);
            // 
            // dtpFechaDevolucion
            // 
            this.dtpFechaDevolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(621, 61);
            this.dtpFechaDevolucion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaDevolucion.TabIndex = 39;
            this.dtpFechaDevolucion.ValueChanged += new System.EventHandler(this.dtpFechaDevolucion_ValueChanged);
            // 
            // LVPrestamos
            // 
            this.LVPrestamos.BackColor = System.Drawing.Color.DimGray;
            this.LVPrestamos.HideSelection = false;
            this.LVPrestamos.Location = new System.Drawing.Point(23, 173);
            this.LVPrestamos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LVPrestamos.Name = "LVPrestamos";
            this.LVPrestamos.Size = new System.Drawing.Size(761, 139);
            this.LVPrestamos.TabIndex = 40;
            this.LVPrestamos.UseCompatibleStateImageBehavior = false;
            this.LVPrestamos.SelectedIndexChanged += new System.EventHandler(this.LVPrestamos_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.LVPrestamos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFechaDevolucion);
            this.groupBox1.Controls.Add(this.combTipoLibro);
            this.groupBox1.Controls.Add(this.lblfechadevolucion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.txtBTitulo);
            this.groupBox1.Controls.Add(this.lblFechahoy);
            this.groupBox1.Controls.Add(this.txtBAutor);
            this.groupBox1.Controls.Add(this.buttRegresar);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.combTipoUser);
            this.groupBox1.Controls.Add(this.butDevolPrestamo);
            this.groupBox1.Controls.Add(this.txtBNombre);
            this.groupBox1.Controls.Add(this.buttRegisPrestamo);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 348);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Prestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 421);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Prestamos";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Prestamos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combTipoLibro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBAutor;
        private System.Windows.Forms.TextBox txtBTitulo;
        private System.Windows.Forms.TextBox txtBNombre;
        private System.Windows.Forms.ComboBox combTipoUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttRegisPrestamo;
        private System.Windows.Forms.Button butDevolPrestamo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttRegresar;
        private System.Windows.Forms.Label lblFechahoy;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblfechadevolucion;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.ListView LVPrestamos;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}