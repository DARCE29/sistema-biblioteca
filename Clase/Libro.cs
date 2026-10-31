using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clase
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoDePublicacion { get; set; }
        public string Categoria { get; set; }
        public bool Disponible { get; set; } = true; 
    }

    public class LibroDigital : Libro
    {
        public string URLDeDescarga { get; set; }
        public int NumeroDeAccesosDisponibles { get; set; }
    }

    public class LibroFisico : Libro
    {
        public string UbicacionDeBiblioteca { get; set; }
        public string CondicionDelLibro { get; set; } 
    }
}
