using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clase
{
    public class BaseDatos
    {

        public static bool IsAdmin = false;
        public static string UsuarioLogin = "";
        private static List<Usuario> listaUsuarios = new List<Usuario>();
        public static List<Libro> ListaLibros = new List<Libro>();
        public static List<Prestamo> ListaPrestamos = new List<Prestamo>();

        internal static List<Usuario> ListaUsuarios { get => listaUsuarios; set => listaUsuarios = value; }
    }
}
