using System;
public class EmpleadoAves : Empleado, ITarea
{
    public EmpleadoAves(string nombre, string apellido, int numeroEmpleado, string dni, string email)
        : base(nombre, apellido, numeroEmpleado, ESectorEmpleado.Aves, dni, email) { }

    public void IniciarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha comenzado una tarea en el sector Aves.");
    }

    public void FinalizarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha finalizado la tarea en el sector Aves.");
    }
}