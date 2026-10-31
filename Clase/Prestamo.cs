using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clase
{
    public class Prestamo : Libro
    {
        public string LibroPrestado { get; set; }
        public DateTime FechaDelPrestamo { get; set; }
        public DateTime? FechaDeDevolucion { get; set; } 
        public string NombreUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Devuelto { get; set; }

    }


}
