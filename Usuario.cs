using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System;

namespace ProyectoFinal
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoDeUsuario { get; set; } 
        public Usuario(string nombreUsuario, string contrasena, string tipodeusuario)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            TipoDeUsuario = tipodeusuario;
        }

        public Usuario()
        {
        }

        
        public static class SesionActual
        {

            public static Usuario UsuarioEnSesion { get; set; }
            public static List<Usuario> UsuariosEnSesion = new List<Usuario>();
            
        }



        public bool Guardar(string Path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path, true))
                {
                    string registro = $"{NombreUsuario},{Contrasena},{TipoDeUsuario}";
                    writer.WriteLine(registro);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<Usuario> leerRegistrosU(string ruta)
        {
            List<Usuario> lista = new List<Usuario>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length >= 3)
                    {
                        Usuario u = new Usuario
                        {
                            NombreUsuario = datos[0].Trim(),
                            Contrasena = datos[1].Trim(),
                            TipoDeUsuario = datos[2].Trim()
                        };
                        lista.Add(u);
                    }
                }
            }

            return lista;
        }

        public int ObtenerLimitePrestamos()
        {
            return TipoDeUsuario == "Profesor" ? 5 : 3;
        }
    }
}
