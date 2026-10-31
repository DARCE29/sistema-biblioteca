namespace ProyectoFinal
{
    partial class MenuPrincipal
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
            this.buttRegisLibrosUser = new System.Windows.Forms.Button();
            this.buttPrestamos = new System.Windows.Forms.Button();
            this.buttReportes = new System.Windows.Forms.Button();
            this.BttSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttRegisLibrosUser
            // 
            this.buttRegisLibrosUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttRegisLibrosUser.Location = new System.Drawing.Point(20, 108);
            this.buttRegisLibrosUser.Margin = new System.Windows.Forms.Padding(2);
            this.buttRegisLibrosUser.Name = "buttRegisLibrosUser";
            this.buttRegisLibrosUser.Size = new System.Drawing.Size(140, 42);
            this.buttRegisLibrosUser.TabIndex = 2;
            this.buttRegisLibrosUser.Text = "Registrar Libros";
            this.buttRegisLibrosUser.UseVisualStyleBackColor = true;
            this.buttRegisLibrosUser.Click += new System.EventHandler(this.buttRegisLibrosUser_Click);
            // 
            // buttPrestamos
            // 
            this.buttPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttPrestamos.Location = new System.Drawing.Point(20, 166);
            this.buttPrestamos.Margin = new System.Windows.Forms.Padding(2);
            this.buttPrestamos.Name = "buttPrestamos";
            this.buttPrestamos.Size = new System.Drawing.Size(140, 42);
            this.buttPrestamos.TabIndex = 4;
            this.buttPrestamos.Text = "Prestamos";
            this.buttPrestamos.UseVisualStyleBackColor = true;
            this.buttPrestamos.Click += new System.EventHandler(this.buttPrestamos_Click);
            // 
            // buttReportes
            // 
            this.buttReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttReportes.Location = new System.Drawing.Point(20, 53);
            this.buttReportes.Margin = new System.Windows.Forms.Padding(2);
            this.buttReportes.Name = "buttReportes";
            this.buttReportes.Size = new System.Drawing.Size(140, 42);
            this.buttReportes.TabIndex = 8;
            this.buttReportes.Text = "Reportes disponibles";
            this.buttReportes.UseVisualStyleBackColor = true;
            this.buttReportes.Click += new System.EventHandler(this.buttReportes_Click);
            // 
            // BttSalir
            // 
            this.BttSalir.BackColor = System.Drawing.Color.DimGray;
            this.BttSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttSalir.ForeColor = System.Drawing.Color.White;
            this.BttSalir.Location = new System.Drawing.Point(320, 224);
            this.BttSalir.Name = "BttSalir";
            this.BttSalir.Size = new System.Drawing.Size(69, 30);
            this.BttSalir.TabIndex = 9;
            this.BttSalir.Text = "Salir";
            this.BttSalir.UseVisualStyleBackColor = false;
            this.BttSalir.Click += new System.EventHandler(this.BttSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.buttReportes);
            this.groupBox1.Controls.Add(this.buttRegisLibrosUser);
            this.groupBox1.Controls.Add(this.buttPrestamos);
            this.groupBox1.Controls.Add(this.BttSalir);
            this.groupBox1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(102, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 260);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Principal";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 329);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuPrincipal";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttRegisLibrosUser;
        private System.Windows.Forms.Button buttPrestamos;
        private System.Windows.Forms.Button buttReportes;
        private System.Windows.Forms.Button BttSalir;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}