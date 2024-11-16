using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Business
{
    public class ReporteService
    {
        private readonly ReporteProductividad reporteProductividad;

        public ReporteService()
        {
            // Obtener la instancia de ReporteProductividad
            reporteProductividad = ReporteProductividad.Instancia;
        }

        public List<ReporteItem> GenerarReporteGeneral(List<Empleado> empleados)
        {
            var estadisticas = reporteProductividad.ObtenerEstadisticas();

            return (from emp in empleados
                    join est in estadisticas on emp.NumeroEmpleado.ToString() equals est.Key
                    select new ReporteItem
                    {
                        Nombre = emp.Nombre,
                        Apellido = emp.Apellido,
                        Sector = emp.Sector,
                        TotalTareas = est.Value.totalTareas,
                        TotalTiempo = est.Value.totalTiempo
                    }).ToList();
        }

        public List<ReporteItem> FiltrarPorSector(List<Empleado> empleados, ESectorEmpleado sector)
        {
            return GenerarReporteGeneral(empleados)
                   .Where(item => item.Sector == sector)
                   .ToList();
        }

        public List<ReporteItem> FiltrarPorRol<T>(List<Empleado> empleados) where T : Empleado
        {
            return GenerarReporteGeneral(empleados)
                   .Where(item => empleados.OfType<T>().Any(e => e.Nombre == item.Nombre && e.Apellido == item.Apellido))
                   .ToList();
        }

        public List<ReporteItem> FiltrarPorTarea(List<Empleado> empleados, List<Tarea> tareas, string nombreTarea)
        {
            var empleadosFiltrados = tareas
                                     .Where(t => t.Nombre == nombreTarea)
                                     .Select(t => t.EmpleadoId)
                                     .Distinct();

            return GenerarReporteGeneral(empleados)
                   .Where(item => empleadosFiltrados.Contains(empleados
                                                             .FirstOrDefault(emp => emp.Nombre == item.Nombre && emp.Apellido == item.Apellido)?
                                                             .NumeroEmpleado ?? -1))
                   .ToList();
        }
    }

    /// Clase que representa un elemento del reporte.
    public class ReporteItem
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ESectorEmpleado Sector { get; set; }
        public int TotalTareas { get; set; }
        public int TotalTiempo { get; set; } // Total de minutos trabajados
    }
}