using System;
public class EmpleadoFelinos : Empleado, ITarea
{
    public EmpleadoFelinos(string nombre, string apellido, int numeroEmpleado, string dni, string email)
        : base(nombre, apellido, numeroEmpleado, ESectorEmpleado.Felinos, dni, email) { }

    public void IniciarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha comenzado una tarea en el sector Felino.");
    }

    public void FinalizarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha finalizado la tarea en el sector Felino.");
    }
}