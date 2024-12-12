using ListaDeTareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ListaDeTareas.Controllers
{
    public class TareasController : Controller
    {
        private static List<Tarea> tareas = new List<Tarea>();

        // Mostrar la lista de tareas
        public IActionResult Index()
        {
            return View(tareas);
        }

        // Agregar una nueva tarea
        [HttpPost]
        public IActionResult Agregar(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                tareas.Add(new Tarea { Id = tareas.Count + 1, Nombre = nombre });
            }
            return RedirectToAction("Index");
        }

        // Eliminar una tarea
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
            }
            return RedirectToAction("Index");
        }

        // Mostrar el formulario de edición
        public IActionResult Editar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        // Procesar los cambios en la tarea
        [HttpPost]
        public IActionResult Editar(Tarea tareaEditada)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == tareaEditada.Id);
            if (tarea != null)
            {
                tarea.Nombre = tareaEditada.Nombre;
            }
            return RedirectToAction("Index");
        }
    }
}
