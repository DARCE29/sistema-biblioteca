using ProyectoFinal.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class UsuariosLibros : Form
    {
        const string RutaLibros = "libros.txt";

        public UsuariosLibros()
        {
            InitializeComponent();

            txtBUbicacion.Visible = false;
            numAccesos.Visible = false;
            txtBURL.Visible = false;
            cboCondicion.Visible = false;
            cboTipoLibro.SelectedIndex = -1;
        }

        private void buttAgregarLibro_Click(object sender, EventArgs e)
        {
            string titulo = txtBTitulo.Text.Trim();
            string autor = txtBAutor.Text.Trim();
            string categoria = txtBCategoria.Text.Trim();
            string tipoLibro = cboTipoLibro.SelectedItem?.ToString();
            int anio = dtpAniode.Value.Year;

            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor) ||
                string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(tipoLibro))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.");
                return;
            }

            Libro nuevoLibro;

            if (tipoLibro == "LibroDigital")
            {
                string url = txtBURL.Text.Trim();
                int accesos = (int)numAccesos.Value;

                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("Debe ingresar una URL para el libro digital.");
                    return;
                }

                nuevoLibro = new LibroDigital
                {
                    Titulo = titulo,
                    Autor = autor,
                    AñoDePublicacion = anio,
                    Categoria = categoria,
                    Disponible = true,
                    URLDeDescarga = url,
                    NumeroDeAccesosDisponibles = accesos
                };
            }
            else if (tipoLibro == "LibroFisico")
            {
                string ubicacion = txtBUbicacion.Text.Trim();
                string condicion = cboCondicion.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(ubicacion) || string.IsNullOrEmpty(condicion))
                {
                    MessageBox.Show("Debe ingresar ubicación y condición para el libro físico.");
                    return;
                }

                nuevoLibro = new LibroFisico
                {
                    Titulo = titulo,
                    Autor = autor,
                    AñoDePublicacion = anio,
                    Categoria = categoria,
                    Disponible = true,
                    UbicacionDeBiblioteca = ubicacion,
                    CondicionDelLibro = condicion
                };
            }
            else
            {
                MessageBox.Show("Seleccione un tipo de libro válido.");
                return;
            }

            BaseDatos.ListaLibros.Add(nuevoLibro);
            MessageBox.Show("Libro agregado con éxito.");
            LimpiarCamposLibro();
            GuardarLibrosEnTxt();
        }

        private void GuardarLibrosEnTxt()
        {
            using (StreamWriter sw = new StreamWriter(RutaLibros, false)) 
            {
                foreach (var libro in BaseDatos.ListaLibros)
                {
                    if (libro is LibroDigital digital)
                    {
                        sw.WriteLine($"{libro.Titulo};{libro.Autor};{libro.AñoDePublicacion};{libro.Categoria};Digital;{digital.URLDeDescarga};{digital.NumeroDeAccesosDisponibles}");
                    }
                    else if (libro is LibroFisico fisico)
                    {
                        sw.WriteLine($"{libro.Titulo};{libro.Autor};{libro.AñoDePublicacion};{libro.Categoria};Fisico;{fisico.UbicacionDeBiblioteca};{fisico.CondicionDelLibro}");
                    }
                }
            }
        }
        private void MostrarLibros()
        {
            dataGridLibrosUsuarios.DataSource = null;
            dataGridLibrosUsuarios.DataSource = BaseDatos.ListaLibros.Select(l => new
            {
                l.Titulo,
                l.Autor,
                l.AñoDePublicacion,
                l.Categoria,
                Tipo = l is LibroDigital ? "LibroDigital" : "LibroFisico", 
                Estado = l.Disponible ? "Disponible" : "Prestado"
            }).ToList();
        }
        private void LimpiarCamposLibro()
        {
            txtBTitulo.Clear();
            txtBAutor.Clear();
            txtBCategoria.Clear();
            txtBURL.Clear();
            txtBUbicacion.Clear();
            cboCondicion.SelectedIndex = -1;
            cboTipoLibro.SelectedIndex = -1;
            numAccesos.Value = 0;
        }

        private void UsuariosLibros_Load(object sender, EventArgs e)
        {

        }

        private void buttAgregarUser_Click(object sender, EventArgs e)
        {
            
        }

        private void MostrarUsuarios()
        {
           
        }

        private void buttBuscar_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscarLibros buscarLibros = new BuscarLibros();
            buscarLibros.Show();

            
        }
        private void buttRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void combTipoLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cboTipoLibro.SelectedItem?.ToString();

            if (tipo == "LibroDigital")
            {
                txtBURL.Visible = true;
                numAccesos.Visible = true;

                txtBUbicacion.Visible = false;
                cboCondicion.Visible = false;
            }
            else if (tipo == "LibroFisico")
            {
                txtBURL.Visible = false;
                numAccesos.Visible = false;

                txtBUbicacion.Visible = true;
                cboCondicion.Visible = true;
            }
            else
            {

               txtBURL.Visible = false;
                numAccesos.Visible = false;
                txtBUbicacion.Visible = false;
                cboCondicion.Visible = false;
            }
        }

        private void dataGridLibrosUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBDispo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarTodosLibros_Click(object sender, EventArgs e)
        {
            
            if (BaseDatos.ListaLibros == null || BaseDatos.ListaLibros.Count == 0)
            {
                MessageBox.Show("No hay libros registrados en el sistema.",
                               "Sin libros", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                dataGridLibrosUsuarios.DataSource = null;
            }
            else
            {
                MostrarLibros();
                MessageBox.Show($"Mostrando {BaseDatos.ListaLibros.Count} libro(s) registrado(s).",
                               "Libros cargados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GuardarLibrosEnTxt(); 
            }
        }
    }
}
