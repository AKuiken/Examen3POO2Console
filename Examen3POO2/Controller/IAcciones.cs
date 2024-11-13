using Examen3POO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3POO2.Controller
{
    internal interface IAcciones
    {
        Task ObtenerAlumnosAsync();
        Task ObtenerAlumnoPorIdAsync(int id);
        Task CrearAlumnoAsync(Inventario alumno);
        Task ActualizarAlumnoAsync(int id, Inventario alumno);
        Task EliminarAlumnoAsync(int id);
    }
    
}
