using System;
using System.Collections.Generic;

public class ReporteProductividad
{
    private static ReporteProductividad instancia;
    private Dictionary<string, (int totalTareas, double totalTiempo)> estadisticasEmpleados;

    private ReporteProductividad()
    {
        estadisticasEmpleados = new Dictionary<string, (int totalTareas, double totalTiempo)>();
    }

    public static ReporteProductividad Instancia
    {
        get
        {
            if (instancia == null)
                instancia = new ReporteProductividad();
            return instancia;
        }
    }

    public void RegistrarTarea(string numeroEmpleado, TimeSpan duracion)
    {
        double minutos = duracion.TotalMinutes;

        if (estadisticasEmpleados.ContainsKey(numeroEmpleado))
        {
            estadisticasEmpleados[numeroEmpleado] = (
                estadisticasEmpleados[numeroEmpleado].totalTareas + 1,
                estadisticasEmpleados[numeroEmpleado].totalTiempo + minutos
            );
        }
        else
        {
            estadisticasEmpleados[numeroEmpleado] = (1, minutos);
        }
    }

    // Método para obtener las estadísticas acumuladas
    public Dictionary<string, (int totalTareas, double totalTiempo)> ObtenerEstadisticas()
    {
        return estadisticasEmpleados;
    }
}