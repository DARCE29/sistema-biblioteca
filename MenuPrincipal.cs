using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.Clase;
using static ProyectoFinal.Usuario;

namespace ProyectoFinal
{
    public partial class MenuPrincipal : Form
    {
        

        public MenuPrincipal()
        {
            InitializeComponent();
        }

       
        private void MenuPrincipal_Load(object sender, EventArgs e)
        { 
}
        
        private void buttBuscarLibros_Click(object sender, EventArgs e)
        {

        }

        private void buttPrestamos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prestamos prestamos = new Prestamos();
            prestamos.Show();
        }

        private void BttSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación Cerrada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
            Application.Exit(); 
        }

        private void buttReportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
            this.Hide();
        }

        private void buttRegisLibrosUser_Click(object sender, EventArgs e)
        {

            Usuario usuarioActual = SesionActual.UsuarioEnSesion;

            if (usuarioActual != null)
            {
                
                if (usuarioActual.TipoDeUsuario == "Administrativo")
                {
                    UsuariosLibros MU = new UsuariosLibros();
                    MU.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Solo los Administradores pueden agregar libros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
