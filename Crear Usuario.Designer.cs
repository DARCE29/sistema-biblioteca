namespace ProyectoFinal
{
    partial class Crear_Usuario
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegresaar = new System.Windows.Forms.Button();
            this.brnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbBTipoUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarU = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContresena = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnRegresaar);
            this.groupBox1.Controls.Add(this.brnSalir);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(198, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 326);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Usuario";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnRegresaar
            // 
            this.btnRegresaar.BackColor = System.Drawing.Color.DimGray;
            this.btnRegresaar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegresaar.Location = new System.Drawing.Point(275, 287);
            this.btnRegresaar.Name = "btnRegresaar";
            this.btnRegresaar.Size = new System.Drawing.Size(120, 33);
            this.btnRegresaar.TabIndex = 15;
            this.btnRegresaar.Text = "Volver al Inicio";
            this.btnRegresaar.UseVisualStyleBackColor = false;
            this.btnRegresaar.Click += new System.EventHandler(this.btnRegresaar_Click_1);
            // 
            // brnSalir
            // 
            this.brnSalir.BackColor = System.Drawing.Color.DimGray;
            this.brnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.brnSalir.Location = new System.Drawing.Point(187, 287);
            this.brnSalir.Name = "brnSalir";
            this.brnSalir.Size = new System.Drawing.Size(82, 33);
            this.brnSalir.TabIndex = 4;
            this.brnSalir.Text = "Salir";
            this.brnSalir.UseVisualStyleBackColor = false;
            this.brnSalir.Click += new System.EventHandler(this.brnSalir_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbBTipoUsuario);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAgregarU);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.txtContresena);
            this.groupBox2.Location = new System.Drawing.Point(10, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 192);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // cmbBTipoUsuario
            // 
            this.cmbBTipoUsuario.FormattingEnabled = true;
            this.cmbBTipoUsuario.Items.AddRange(new object[] {
            "Estudiante",
            "Profesor",
            "Administrativo"});
            this.cmbBTipoUsuario.Location = new System.Drawing.Point(19, 127);
            this.cmbBTipoUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBTipoUsuario.Name = "cmbBTipoUsuario";
            this.cmbBTipoUsuario.Size = new System.Drawing.Size(100, 21);
            this.cmbBTipoUsuario.TabIndex = 6;
            this.cmbBTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbBTipoUsuario_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contrasena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // btnAgregarU
            // 
            this.btnAgregarU.Location = new System.Drawing.Point(178, 163);
            this.btnAgregarU.Name = "btnAgregarU";
            this.btnAgregarU.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarU.TabIndex = 2;
            this.btnAgregarU.Text = "Crear";
            this.btnAgregarU.UseVisualStyleBackColor = true;
            this.btnAgregarU.Click += new System.EventHandler(this.btnAgregarU_Click_1);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(19, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtContresena
            // 
            this.txtContresena.Location = new System.Drawing.Point(19, 89);
            this.txtContresena.Name = "txtContresena";
            this.txtContresena.Size = new System.Drawing.Size(100, 20);
            this.txtContresena.TabIndex = 0;
            // 
            // Crear_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Crear_Usuario";
            this.Text = "Crear_Usuario";
            this.Load += new System.EventHandler(this.Crear_Usuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegresaar;
        private System.Windows.Forms.Button brnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbBTipoUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarU;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContresena;
    }
}