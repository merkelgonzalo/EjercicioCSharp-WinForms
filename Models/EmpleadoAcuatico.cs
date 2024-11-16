using System;
public class EmpleadoAcuatico : Empleado, ITarea
{
    public EmpleadoAcuatico(string nombre, string apellido, int numeroEmpleado, string dni, string email)
        : base(nombre, apellido, numeroEmpleado, ESectorEmpleado.Acuatico, dni, email) { }

    public void IniciarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha comenzado una tarea en el sector Acuático.");
    }

    public void FinalizarTarea(string nombreTarea, int numeroEmpleado)
    {
        Console.WriteLine($"Empleado {Nombre} ha finalizado la tarea en el sector Acuático.");
    }
}