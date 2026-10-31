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

namespace ProyectoFinal
{
    public partial class BuscarLibros : Form
    {
        public BuscarLibros()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBDispo_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }
        private void buttBuscarLibro_Click(object sender, EventArgs e)
        {
           
        }
        private void BuscarLibros_Load(object sender, EventArgs e)
        {

        }

        private void buttBuscarLibro_Click_1(object sender, EventArgs e)
        {
            
            string titulo = txtBTitulo.Text.Trim().ToLower();
            string autor = txtBAutor.Text.Trim().ToLower();
            string categoria = txtBCategoria.Text.Trim().ToLower();
            string disponibilidad = cboDispo.SelectedItem?.ToString();

           
            if (string.IsNullOrEmpty(titulo) &&
                string.IsNullOrEmpty(autor) &&
                string.IsNullOrEmpty(categoria) &&
                (string.IsNullOrEmpty(disponibilidad) || disponibilidad == "Todos"))
            {
                MessageBox.Show("No has buscado absolutamente nada bro", "¡EY!",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (BaseDatos.ListaLibros == null || !BaseDatos.ListaLibros.Any())
            {
                MessageBox.Show("No hay libros registrados en el sistema.", "Sin datos",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                return;
            }

            
            var resultado = BaseDatos.ListaLibros.Where(libro =>
                
                (string.IsNullOrEmpty(titulo) || libro.Titulo.ToLower().Contains(titulo)) &&

                
                (string.IsNullOrEmpty(autor) || libro.Autor.ToLower().Contains(autor)) &&

              
                (string.IsNullOrEmpty(categoria) || libro.Categoria.ToLower().Contains(categoria)) &&

                
                (string.IsNullOrEmpty(disponibilidad) || disponibilidad == "Todos" ||
                 (disponibilidad == "Disponible" && libro.Disponible) ||
                 (disponibilidad == "No Disponible" && !libro.Disponible))

            ).Select(l => new
            {
                l.Titulo,
                l.Autor,
                l.AñoDePublicacion,
                l.Categoria,
                Tipo = l is LibroDigital ? "Digital" : "Físico",
                Estado = l.Disponible ? "Disponible" : "No Disponible"
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = resultado;

          
            if (resultado.Count == 0)
            {
                MessageBox.Show("No se encontraron libros con esos criterios de búsqueda.",
                               "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Se encontraron {resultado.Count} libro(s).",
                               "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void LimpiarDataGridView()
        {
          
            
            txtBTitulo.Text = "";
            txtBAutor.Text = "";
            txtBCategoria.Text = "";
            cboDispo.SelectedIndex = -1;

            
            dataGridView1.DataSource = null;

        
    }

        private void cboDispo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
