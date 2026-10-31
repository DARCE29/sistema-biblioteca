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
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }
        
        private void buttIngresar_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }


        private void txtBContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Contrasena_Click(object sender, EventArgs e)
        {

        }

        private void txtBusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            Usuario user = new Usuario();
            List<Usuario> usuarios = user.leerRegistrosU("usuarios.txt");

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string tipodeusauiro = cmbBTipoUsuario.Text.Trim();

            
            Usuario usuarioEncontrado = usuarios
                .FirstOrDefault(u => u.NombreUsuario == usuario
                                  && u.Contrasena == contrasena
                                  && u.TipoDeUsuario == tipodeusauiro);

            if (usuarioEncontrado != null)
            {

                SesionActual.UsuarioEnSesion = usuarioEncontrado;
                SesionActual.UsuariosEnSesion.Add(usuarioEncontrado);

                MessageBox.Show("Bienvenido al sistema.", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MenuPrincipal FormPrincipal = new MenuPrincipal();
                FormPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtUsuario.Clear();
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Crear_Usuario formCU = new Crear_Usuario();
            formCU.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void brnSalir_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación Cerrada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
            Application.Exit();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Crear_Usuario formCU = new Crear_Usuario();
            formCU.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
