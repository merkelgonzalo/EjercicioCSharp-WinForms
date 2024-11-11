using System;

public class Empleado
{
    // Propiedades empleado
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int NumeroEmpleado { get; set; }
    public ESectorEmpleado Sector { get; set; }
    public string Dni { get; set; }
    public string Email { get; set; }

    // Constructor
    public Empleado(string nombre, string apellido, int numeroEmpleado, ESectorEmpleado sector, string dni, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        NumeroEmpleado = numeroEmpleado;
        Sector = sector;
        Dni = dni;
        Email = email;
    }

    // ToString()
    public void toString()
    {
        Console.WriteLine($"Empleado N°: {NumeroEmpleado}");
        Console.WriteLine($"Nombre: {Nombre} {Apellido}");
        Console.WriteLine($"Sector: {Sector}");
        Console.WriteLine($"DNI: {Dni}");
        Console.WriteLine($"Email: {Email}");
    }
}
