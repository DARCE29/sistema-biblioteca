using ProyectoFinal.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoFinal.Usuario;

namespace ProyectoFinal
{
    public partial class Prestamos : Form
    {
        private const string Nonmbre_Archivo = "prestamos.txt";
        List<Prestamo> listaPrestamos = new List<Prestamo>();
        public Prestamos()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            txtBAutor.Clear();
            txtBNombre.Clear();
            txtBTitulo.Clear();
            combTipoLibro.SelectedIndex = -1; 
            combTipoUser.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaDevolucion.Value = DateTime.Now;
        }
        public bool GuardarInformacion(Prestamo prestamo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Nonmbre_Archivo, true))
                {
                    string linea = $"{prestamo.Titulo};{prestamo.Autor};{prestamo.Categoria};{prestamo.FechaDelPrestamo};{prestamo.FechaDeDevolucion};{prestamo.NombreUsuario};{prestamo.TipoUsuario};{prestamo.Devuelto}";
                    writer.WriteLine(linea);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<Prestamo> LeerInformacion()
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            try
            {
                if (File.Exists(Nonmbre_Archivo))
                {
                    using (StreamReader reader = new StreamReader(Nonmbre_Archivo))
                    {
                        while (!reader.EndOfStream)
                        {
                            string linea = reader.ReadLine();
                            string[] datos = linea.Split(';');
                            if (datos.Length == 8)
                            {
                                Prestamo prestamo = new Prestamo
                                {
                                    Titulo = datos[0].Trim(),
                                    Autor = datos[1].Trim(),
                                    Categoria = datos[2].Trim(),
                                    FechaDelPrestamo = DateTime.Parse(datos[3].Trim()),
                                    FechaDeDevolucion = DateTime.Parse(datos[4].Trim()),
                                    NombreUsuario = datos[5].Trim(),
                                    TipoUsuario = datos[6].Trim(),
                                    Devuelto = datos[7].Trim()
                                };
                                prestamos.Add(prestamo);
                            }
                            else
                            {
                                MessageBox.Show("Formato de datos incorrecto en la línea: " + linea, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return prestamos;
        }
        private void buttRegisPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionActual.UsuarioEnSesion == null)
                {
                    MessageBox.Show("No hay un usuario en sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Usuario usuarioActual = SesionActual.UsuarioEnSesion;

                string titulo = txtBTitulo.Text.Trim().ToLower();
                string autor = txtBAutor.Text.Trim().ToLower();
                string tipoLibro = combTipoLibro.Text;
                DateTime fechaPrestamo = dtpFechaInicio.Value;
                DateTime FechaDevolucion = dtpFechaDevolucion.Value;
                string tipoUsuario = combTipoUser.Text;
                string nombreUsuario = txtBNombre.Text.Trim().ToLower();
                string devuelto = "No Devuelto";

                if (string.IsNullOrEmpty(titulo) && string.IsNullOrEmpty(autor))
                {
                    MessageBox.Show("Debe ingresar el título y autor del libro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (var libro in BaseDatos.ListaLibros)
                {
                    if (libro.Titulo.ToLower() == titulo && libro.Autor.ToLower() == autor)
                    {
                        if (!libro.Disponible)
                        {
                            MessageBox.Show("El libro ya está prestado.", "Libro no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        break;
                    }
                }


                List<Prestamo> prestamos = LeerInformacion();


                int prestamosUsuario = prestamos.Count(p => p.NombreUsuario.Equals(usuarioActual.NombreUsuario, StringComparison.OrdinalIgnoreCase));

                if (usuarioActual.TipoDeUsuario == "Alumno" && prestamosUsuario >= 3)
                {
                    MessageBox.Show("Un alumno solo puede tener máximo 3 préstamos.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (usuarioActual.TipoDeUsuario == "Profesor" && prestamosUsuario >= 5)
                {
                    MessageBox.Show("Un profesor solo puede tener máximo 5 préstamos.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Prestamo prestamo = new Prestamo
                {
                    Titulo = titulo,
                    Autor = autor,
                    Categoria = tipoLibro,
                    FechaDelPrestamo = fechaPrestamo,
                    FechaDeDevolucion = fechaPrestamo.AddDays(
                        usuarioActual.TipoDeUsuario == "Profesor" ? 14 :
                        usuarioActual.TipoDeUsuario == "Administrativo" ? 30 : 7
                    ),
                    NombreUsuario = usuarioActual.NombreUsuario,
                    TipoUsuario = usuarioActual.TipoDeUsuario,
                    Devuelto = devuelto,
                };

                if (GuardarInformacion(prestamo))
                {
                    BaseDatos.ListaPrestamos.Add(prestamo);
                    listaPrestamos.Add(prestamo);
                    MessageBox.Show("Préstamo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el préstamo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
   


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreusuario = txtBNombre.Text.Trim().ToLower();
                foreach (var prestamo in BaseDatos.ListaPrestamos)
                {
                    if (prestamo.NombreUsuario.ToLower() == nombreusuario)
                    {
                        List<Prestamo> list = new List<Prestamo>();
                        list.Add(prestamo);
                        LVPrestamos.View = View.Details;
                        LVPrestamos.FullRowSelect = true;
                        LVPrestamos.GridLines = true;
                        LVPrestamos.Columns.Clear();

                        LVPrestamos.Columns.Add("Título", 80);
                        LVPrestamos.Columns.Add("Autor", 80);
                        LVPrestamos.Columns.Add("Categoría", 80);
                        LVPrestamos.Columns.Add("Fecha Préstamo", 100);
                        LVPrestamos.Columns.Add("Fecha Devolución", 100);
                        LVPrestamos.Columns.Add("Usuario", 80);
                        LVPrestamos.Columns.Add("Tipo Usuario", 80);
                        LVPrestamos.Columns.Add("Devuelto", 80);


                        LVPrestamos.Items.Clear();

                        foreach (var p in BaseDatos.ListaPrestamos)
                        {
                            ListViewItem fila = new ListViewItem(p.Titulo);
                            fila.SubItems.Add(p.Autor);
                            fila.SubItems.Add(p.Categoria);
                            fila.SubItems.Add(p.FechaDelPrestamo.ToShortDateString());
                            fila.SubItems.Add(p.FechaDeDevolucion.HasValue ? p.FechaDeDevolucion.Value.ToShortDateString() : "Pendiente");
                            fila.SubItems.Add(p.NombreUsuario);
                            fila.SubItems.Add(p.TipoUsuario);
                            fila.SubItems.Add(p.Devuelto);

                            LVPrestamos.Items.Add(fila);
                        }
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron préstamos para el usuario especificado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void butDevolPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = txtBNombre.Text.Trim().ToLower();
                string titulo = txtBTitulo.Text.Trim().ToLower();
                string autor = txtBAutor.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(titulo))
                {
                    MessageBox.Show("Debe ingresar el nombre del usuario y el título del libro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (var prestamo in BaseDatos.ListaPrestamos)
                {
                    if (prestamo.NombreUsuario.ToLower() == nombreUsuario && prestamo.Titulo.ToLower() == titulo)
                    {
                        prestamo.FechaDeDevolucion = dtpFechaDevolucion.Value;
                        foreach (var libro in BaseDatos.ListaLibros)
                        {
                            if (libro.Titulo.ToLower() == titulo && libro.Autor.ToLower() == autor)
                            {
                                libro.Disponible = true;
                                prestamo.Devuelto = "Devuelto";
                                MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCampos();
                                return;
                            }
                        }
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }
        private void Prestamos_Load(object sender, EventArgs e)
        {

        }

        private void LVPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpFechaDevolucion_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblfechadevolucion_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblFechahoy_Click(object sender, EventArgs e)
        {

        }

        private void txtBNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void combTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtBAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void combTipoLibro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    

