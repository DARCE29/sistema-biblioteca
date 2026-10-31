using ProyectoFinal.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class Crear_Usuario : Form
    {
        public Crear_Usuario()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegresaar_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); 
        }

        private void btnAgregarU_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContresena.Text;
            string tipodeusuario = cmbBTipoUsuario.Text;

            
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(tipodeusuario))
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tipodeusuario.Equals("Profesor", StringComparison.OrdinalIgnoreCase))
            {
                string codigo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el código de autorización para crear un usuario Profesor:", "Validación");

                if (codigo != "0990")
                {
                    MessageBox.Show("Código incorrecto. No se puede crear el usuario Profesor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }

            if (tipodeusuario.Equals("Administrativo", StringComparison.OrdinalIgnoreCase))
            {
                string codigo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el código de autorización para crear un usuario Administrativo:", "Validación");
                
                if (codigo != "0890")
                {
                    MessageBox.Show("Código incorrecto. No se puede crear el usuario Administrativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }

                var user = new Usuario(usuario, contrasena, tipodeusuario);
                user.Guardar("usuarios.txt");
                BaseDatos.ListaUsuarios.Add(user);

                MessageBox.Show("Usuario creado con éxito.");
                txtUsuario.Clear();
                txtContresena.Clear();
                cmbBTipoUsuario.SelectedIndex = -1; 
            }
        

        private void brnSalir_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación Cerrada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();

        }

        private void Crear_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void cmbBTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
