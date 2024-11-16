using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
    public class TareaService
    {
        private Dictionary<int, Dictionary<string, DateTime>> tareasEnProgreso; // ID del empleado -> {Tarea, Inicio}
        private List<Tarea> tareasCompletadas; // Lista de tareas completadas

        public TareaService()
        {
            tareasEnProgreso = new Dictionary<int, Dictionary<string, DateTime>>();
            tareasCompletadas = new List<Tarea>();
        }

        public void IniciarTarea(int idEmpleado, string nombreTarea)
        {
            if (!tareasEnProgreso.ContainsKey(idEmpleado))
            {
                tareasEnProgreso[idEmpleado] = new Dictionary<string, DateTime>();
            }

            if (tareasEnProgreso[idEmpleado].ContainsKey(nombreTarea))
            {
                throw new InvalidOperationException($"El empleado {idEmpleado} ya tiene la tarea '{nombreTarea}' en progreso.");
            }

            tareasEnProgreso[idEmpleado][nombreTarea] = DateTime.Now;
            Console.WriteLine($"Empleado {idEmpleado} inició la tarea '{nombreTarea}' a las {DateTime.Now}.");
        }

        public TimeSpan FinalizarTarea(int idEmpleado, string nombreTarea)
        {
            if (!tareasEnProgreso.ContainsKey(idEmpleado) || !tareasEnProgreso[idEmpleado].ContainsKey(nombreTarea))
            {
                throw new KeyNotFoundException($"La tarea '{nombreTarea}' para el empleado {idEmpleado} no se encontró en progreso.");
            }

            // Calcular duración de la tarea
            DateTime inicio = tareasEnProgreso[idEmpleado][nombreTarea];
            DateTime fin = DateTime.Now;
            TimeSpan duracion = fin - inicio;

            // Registrar tarea como completada
            var tareaCompletada = new Tarea
            {
                Nombre = nombreTarea,
                Duracion = duracion,
                EmpleadoId = idEmpleado,
                FechaCompletada = fin
            };
            tareasCompletadas.Add(tareaCompletada);

            // Eliminar la tarea de las tareas en progreso
            tareasEnProgreso[idEmpleado].Remove(nombreTarea);
            if (tareasEnProgreso[idEmpleado].Count == 0)
            {
                tareasEnProgreso.Remove(idEmpleado);
            }

            Console.WriteLine($"Empleado {idEmpleado} finalizó la tarea '{nombreTarea}' a las {fin}. Duración: {duracion.TotalMinutes} minutos.");
            return duracion;
        }

        public List<Tarea> ObtenerTareasCompletadas()
        {
            return tareasCompletadas;
        }

        public List<(string Tarea, DateTime Inicio)> ObtenerTareasEnProgreso(int idEmpleado)
        {
            if (tareasEnProgreso.ContainsKey(idEmpleado))
            {
                return tareasEnProgreso[idEmpleado].Select(t => (t.Key, t.Value)).ToList();
            }

            return new List<(string Tarea, DateTime Inicio)>();
        }
    }
}