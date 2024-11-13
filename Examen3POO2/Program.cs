using Examen3POO2.Controller;
using Examen3POO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Examen3POO2
{
    public enum MenuOpciones
    {
        ObtenerAlumnosAsync = 1,
        ObtenerAlumnoPorIdAsync,
        CrearAlumnoAsync,
        ActualizarAlumnoAsync,
        EliminarAlumnoAsync,
        Salir
    }
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Acciones acciones = new Acciones();


            bool exit = false;
            while (!exit)
            {
                switch (Seleccion())
                {
                    case MenuOpciones.ObtenerAlumnosAsync:
                        await acciones.ObtenerAlumnosAsync();
                        break;
                    case MenuOpciones.ObtenerAlumnoPorIdAsync:
                        Console.Write("Ingrese el ID: ");
                        int idObtener = int.Parse(Console.ReadLine());
                        await acciones.ObtenerAlumnoPorIdAsync(idObtener);
                        break;
                    case MenuOpciones.CrearAlumnoAsync:
                        await acciones.CrearAlumnoAsync();
                        break;
                    case MenuOpciones.ActualizarAlumnoAsync:
                        Console.Write("Ingrese el ID a actualizar: ");
                        int idActualizar = int.Parse(Console.ReadLine());
                        await acciones.ActualizarAlumnoAsync(idActualizar);
                        break;
                    case MenuOpciones.EliminarAlumnoAsync:
                        Console.Write("Ingrese el ID a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        await acciones.EliminarAlumnoAsync(idEliminar, acciones.GetClient());
                        break;
                    case MenuOpciones.Salir:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
        static MenuOpciones Seleccion()
        {
            Console.WriteLine("1) Mostrar alumnos");
            Console.WriteLine("2) Mostrar alumno por ID");
            Console.WriteLine("3) Crear registro");
            Console.WriteLine("4) Actualizar");
            Console.WriteLine("5) Eliminar alumno");
            Console.WriteLine("6) Salir");

            try
            {
                MenuOpciones opc = (MenuOpciones)Convert.ToInt32(Console.ReadLine());
                return opc;
            }
            catch (Exception)
            {
                Console.WriteLine("La opción no es válida. Intente de nuevo.");
                return 0;
            }
        }
    }
}
