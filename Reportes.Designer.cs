namespace ProyectoFinal
{
    partial class Reportes
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
            this.dtgReportes = new System.Windows.Forms.DataGridView();
            this.buttReportMasPrestado = new System.Windows.Forms.Button();
            this.buttPrestamosActivos = new System.Windows.Forms.Button();
            this.buttReportDispo = new System.Windows.Forms.Button();
            this.bttRegresar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Menu de reportes";
            // 
            // dtgReportes
            // 
            this.dtgReportes.BackgroundColor = System.Drawing.Color.DimGray;
            this.dtgReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReportes.Location = new System.Drawing.Point(28, 134);
            this.dtgReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgReportes.Name = "dtgReportes";
            this.dtgReportes.RowHeadersWidth = 82;
            this.dtgReportes.RowTemplate.Height = 33;
            this.dtgReportes.Size = new System.Drawing.Size(991, 266);
            this.dtgReportes.TabIndex = 3;
            this.dtgReportes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgReportes_CellContentClick);
            // 
            // buttReportMasPrestado
            // 
            this.buttReportMasPrestado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttReportMasPrestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttReportMasPrestado.Location = new System.Drawing.Point(28, 54);
            this.buttReportMasPrestado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttReportMasPrestado.Name = "buttReportMasPrestado";
            this.buttReportMasPrestado.Size = new System.Drawing.Size(159, 59);
            this.buttReportMasPrestado.TabIndex = 32;
            this.buttReportMasPrestado.Text = "Reporte Libros mas prestados";
            this.buttReportMasPrestado.UseVisualStyleBackColor = false;
            this.buttReportMasPrestado.Click += new System.EventHandler(this.buttReportMasPrestado_Click);
            // 
            // buttPrestamosActivos
            // 
            this.buttPrestamosActivos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttPrestamosActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttPrestamosActivos.Location = new System.Drawing.Point(192, 54);
            this.buttPrestamosActivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttPrestamosActivos.Name = "buttPrestamosActivos";
            this.buttPrestamosActivos.Size = new System.Drawing.Size(159, 59);
            this.buttPrestamosActivos.TabIndex = 33;
            this.buttPrestamosActivos.Text = "Reporte de prestamos activos";
            this.buttPrestamosActivos.UseVisualStyleBackColor = false;
            this.buttPrestamosActivos.Click += new System.EventHandler(this.buttPrestamosActivos_Click);
            // 
            // buttReportDispo
            // 
            this.buttReportDispo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttReportDispo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttReportDispo.Location = new System.Drawing.Point(356, 54);
            this.buttReportDispo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttReportDispo.Name = "buttReportDispo";
            this.buttReportDispo.Size = new System.Drawing.Size(159, 59);
            this.buttReportDispo.TabIndex = 34;
            this.buttReportDispo.Text = "Reporte de libros disponibles";
            this.buttReportDispo.UseVisualStyleBackColor = false;
            this.buttReportDispo.Click += new System.EventHandler(this.buttReportDispo_Click);
            // 
            // bttRegresar
            // 
            this.bttRegresar.BackColor = System.Drawing.Color.DimGray;
            this.bttRegresar.ForeColor = System.Drawing.Color.White;
            this.bttRegresar.Location = new System.Drawing.Point(924, 412);
            this.bttRegresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bttRegresar.Name = "bttRegresar";
            this.bttRegresar.Size = new System.Drawing.Size(113, 39);
            this.bttRegresar.TabIndex = 35;
            this.bttRegresar.Text = "Regresar";
            this.bttRegresar.UseVisualStyleBackColor = false;
            this.bttRegresar.Click += new System.EventHandler(this.bttRegresar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.buttReportMasPrestado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bttRegresar);
            this.groupBox1.Controls.Add(this.dtgReportes);
            this.groupBox1.Controls.Add(this.buttReportDispo);
            this.groupBox1.Controls.Add(this.buttPrestamosActivos);
            this.groupBox1.Location = new System.Drawing.Point(16, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1045, 459);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 540);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgReportes;
        private System.Windows.Forms.Button buttReportMasPrestado;
        private System.Windows.Forms.Button buttPrestamosActivos;
        private System.Windows.Forms.Button buttReportDispo;
        private System.Windows.Forms.Button bttRegresar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}