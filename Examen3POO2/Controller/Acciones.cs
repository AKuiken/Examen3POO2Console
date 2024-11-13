using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using Examen3POO2.Models;

namespace Examen3POO2.Controller
{
    internal class Acciones : IAcciones
    {
        static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7197"),
        };

        public async Task ObtenerAlumnosAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Alumnos");
            if (response.IsSuccessStatusCode)
            {
                var alumnos = JsonConvert.DeserializeObject<List<Inventario>>(await response.Content.ReadAsStringAsync());
                foreach (var alum in alumnos)
                {
                    Console.WriteLine($"ID: {alum.Id}, Nombre: {alum.Nombre}, Marca: {alum.Marca}, Categoria: {alum.Categoria}, Precio: {alum.Precio}");
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
            }
        }

        public async Task ObtenerAlumnoPorIdAsync(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"api/alumnos/{id}");
            if (response.IsSuccessStatusCode)
            {
                var alum = JsonConvert.DeserializeObject<Inventario>(await response.Content.ReadAsStringAsync());
                Console.WriteLine($"ID: {alum.Id}, Nombre: {alum.Nombre}, Marca: {alum.Marca}, Categoria: {alum.Categoria}, Precio: {alum.Precio}");
            }
            else
            {
                Console.WriteLine($"Error: No se pudo encontrar el alumno con ID {id}. {response.ReasonPhrase}");
            }
        }

        public async Task CrearAlumnoAsync(Inventario alumno)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(alumno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/alumnos", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto creado con éxito.");
            }
            else
            {
                Console.WriteLine($"Error al crear el producto: {response.ReasonPhrase}");
            }
        }

        public async Task ActualizarAlumnoAsync(int id, Inventario alumno)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(alumno);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/alumnos/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto actualizado con éxito.");
            }
            else
            {
                Console.WriteLine($"Error al actualizar el producto: {response.ReasonPhrase}");
            }
        }

        public async Task EliminarAlumnoAsync(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync($"api/alumnos/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine($"Error al eliminar el producto: {response.ReasonPhrase}");
            }
        }
    }
}
