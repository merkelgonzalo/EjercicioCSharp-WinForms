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

        public void IniciarTarea(string nombreTarea, int numeroEmpleado)
        {
            if (!tareasEnProgreso.ContainsKey(numeroEmpleado))
            {
                tareasEnProgreso[numeroEmpleado] = new Dictionary<string, DateTime>();
            }

            if (tareasEnProgreso[numeroEmpleado].ContainsKey(nombreTarea))
            {
                throw new InvalidOperationException($"El empleado {numeroEmpleado} ya tiene la tarea '{nombreTarea}' en progreso.");
            }

            tareasEnProgreso[numeroEmpleado][nombreTarea] = DateTime.Now;
            MessageBox.Show($"Empleado {numeroEmpleado} inició la tarea '{nombreTarea}'.");

            FinalizarTarea(nombreTarea, numeroEmpleado);
        }

        public bool FinalizarTarea(string nombreTarea, int numeroEmpleado)
        {
            if (!tareasEnProgreso.ContainsKey(numeroEmpleado) || !tareasEnProgreso[numeroEmpleado].ContainsKey(nombreTarea))
            {
                throw new KeyNotFoundException($"La tarea '{nombreTarea}' para el empleado {numeroEmpleado} no se encontró en progreso.");
            }

            // Calcular duración de la tarea
            switch (nombreTarea)
            {
                case "Limpiar Estanque": double duracion = 10.0;
                    break;
                case "Alimentar Estanque": double duracion = 5.0;
                    break;
            }

            // Registrar tarea como completada
            var tareaCompletada = new Tarea
            {
                Nombre = nombreTarea,
                Duracion = duracion,
                NumeroEmpleado = numeroEmpleado,
                //FechaCompletada = fin
            };
            tareasCompletadas.Add(tareaCompletada);

            // Eliminar la tarea de las tareas en progreso
            tareasEnProgreso[idEmpleado].Remove(nombreTarea);
            if (tareasEnProgreso[numeroEmpleado].Count == 0)
            {
                tareasEnProgreso.Remove(numeroEmpleado);
            }

            MessageBox.Show($"Empleado {numeroEmpleado} finalizó la tarea '{nombreTarea}'. Duración: {duracion} segundos.");
            return true;
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