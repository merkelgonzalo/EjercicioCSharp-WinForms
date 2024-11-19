namespace Models
{
    public class Tarea
    {
        public string NombreTarea { get; set; }

        public double Duracion { get; set; }

        public Empleado Empleado { get; set; }


        public Tarea(string nombreTarea, double duracion, Empleado empleado)
        {
            NombreTarea = nombreTarea;
            Duracion = duracion;
            Empleado = empleado;
        }

        public override string ToString()
        {
            return $"Tarea: {NombreTarea}, Empleado: {Empleado.Nombre} {Empleado.Apellido}";
        }
    }
}
