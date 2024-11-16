namespace Models
{
    public class Tarea
    {
        public string NombreTarea { get; set; }

        public TimeSpan Duracion { get; set; }

        public Empleado Empleado { get; set; }


        public Tarea(string nombreTarea, TimeSpan duracion, Empleado empleado)
        {
            NombreTarea = nombreTarea;
            Duracion = duracion;
            Empleado = empleado;
        }

        public override string ToString()
        {
            return $"Tarea: {NombreTarea}, Duración: {Duracion.TotalMinutes} minutos, Empleado: {Empleado.Nombre} {Empleado.Apellido}";
        }
    }
}
