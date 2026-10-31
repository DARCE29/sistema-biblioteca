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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void buttReportMasPrestado_Click(object sender, EventArgs e)
        {
            try
            {
                var data = BaseDatos.ListaPrestamos
                    .GroupBy(p => new { p.Titulo, p.Autor })
                    .Select(g => new
                    {
                        Titulo = g.Key.Titulo,
                        Autor = g.Key.Autor,
                        VecesPrestado = g.Count()
                    })
                    .OrderByDescending(x => x.VecesPrestado)
                    .ToList();

                dtgReportes.DataSource = null;
                dtgReportes.DataSource = data;

                if (data.Count == 0)
                    MessageBox.Show("Sin datos de préstamos aún.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }
        

        

        private void buttPrestamosActivos_Click(object sender, EventArgs e)
        {
            try
            {
                Func<string, int> diasPermitidos = tipo =>
                {
                    if (string.Equals(tipo, "Profesor", StringComparison.OrdinalIgnoreCase)) return 14;
                    if (string.Equals(tipo, "Administrativo", StringComparison.OrdinalIgnoreCase)) return 10;
                    return 7; 
                };

                var ahora = DateTime.Now.Date;

                var data = BaseDatos.ListaPrestamos
                    .Where(p => !p.FechaDeDevolucion.HasValue)
                    .Select(p => new
                    {
                        p.Titulo,
                        p.Autor,
                        p.Categoria,
                        p.NombreUsuario,
                        p.TipoUsuario,
                        FechaPrestamo = p.FechaDelPrestamo.ToString("dd/MM/yyyy"),
                        DiasTranscurridos = (ahora - p.FechaDelPrestamo.Date).Days,
                        DiasPermitidos = diasPermitidos(p.TipoUsuario),
                        DiasAtraso = Math.Max(0, (ahora - p.FechaDelPrestamo.Date).Days - diasPermitidos(p.TipoUsuario))
                    })
                    .OrderByDescending(x => x.DiasAtraso)
                    .ThenByDescending(x => x.DiasTranscurridos)
                    .ToList();

                dtgReportes.DataSource = null;
                dtgReportes.DataSource = data;

                if (data.Count == 0)
                    MessageBox.Show("No hay préstamos pendientes.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        
   

        private void buttReportDispo_Click(object sender, EventArgs e)
        {
            try
            {
                var total = BaseDatos.ListaLibros.Count;
                var disp = BaseDatos.ListaLibros.Count(l => l.Disponible);
                var noDisp = total - disp;

                var detalle = BaseDatos.ListaLibros
                    .Select(l => new {
                        l.Titulo,
                        l.Autor,
                        Año = l.AñoDePublicacion,
                        l.Categoria,
                        Disponible = l.Disponible ? "Sí" : "No",
                        Tipo = (l is LibroDigital) ? "Digital" : "Físico"
                    }).ToList();

                dtgReportes.DataSource = null;
                dtgReportes.DataSource = detalle;

                if (total == 0)
                    MessageBox.Show("No hay libros cargados.");
                else
                    MessageBox.Show($"Disponibles: {disp}  |  No disponibles: {noDisp}  |  Total: {total}", "Resumen de disponibilidad");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

       }
      

        private void bttRegresar_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void dtgReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
