using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Zoologico
{
    public partial class FormularioEmpleado : Form, ITarea
    {
        private List<Empleado> listaEmpleados = new List<Empleado>();
        // Diccionario para almacenar el tiempo de inicio de tareas, usando una clave compuesta de tarea y número de empleado
        private Dictionary<(string, int), DateTime> tiempoInicioTarea = new Dictionary<(string, int), DateTime>();
        public FormularioEmpleado()
        {
            InitializeComponent();
            CargarSectores();
            ConfigurarDataGridView();
            // Desactivar todos los botones de tarea al inicio
            buttonLimpiarEstanque.Enabled = false;
            buttonAlimentarEstanque.Enabled = false;
            buttonLimpiarJaulas.Enabled = false;
            buttonAlimentarFelinos.Enabled = false;
            buttonSacarFelinos.Enabled = false;
            buttonLimpiarBebederos.Enabled = false;
            buttonLimpiarPasillos.Enabled = false;
        }
        private void CargarSectores()
        {
            // Se carga los valores del enumerador SectorEmpleado en el ComboBox
            comboBoxSector.DataSource = Enum.GetValues(typeof(ESectorEmpleado));
        }

        private void ConfigurarDataGridView()
        {
            // Configuración de las columnas del DataGridView
            dataGridViewEmpleados.ColumnCount = 6;
            dataGridViewEmpleados.Columns[0].Name = "Número Empleado";
            dataGridViewEmpleados.Columns[1].Name = "Nombre";
            dataGridViewEmpleados.Columns[2].Name = "Apellido";
            dataGridViewEmpleados.Columns[3].Name = "Sector";
            dataGridViewEmpleados.Columns[4].Name = "DNI";
            dataGridViewEmpleados.Columns[5].Name = "Email";
        }

        private void buttonAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Validacion de los campos obligatorios
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxApellido.Text) ||
                string.IsNullOrWhiteSpace(textBoxNumeroEmpleado.Text) ||
                string.IsNullOrWhiteSpace(textBoxDni.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Tiene que completar todos los campos obligatorios.");
                return;
            }

            // VAlidacion de nro de empleado
            int numeroEmpleado;
            if (!int.TryParse(textBoxNumeroEmpleado.Text, out numeroEmpleado) ||
                listaEmpleados.Any(emp => emp.NumeroEmpleado == numeroEmpleado))
            {
                MessageBox.Show("El Número de Empleado es inválido o ya se asignó.");
                return;
            }

            // Obtener los datos ingresados en los TextBoxes
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string dni = textBoxDni.Text;
            string email = textBoxEmail.Text;
            ESectorEmpleado sector = (ESectorEmpleado)comboBoxSector.SelectedItem;

            // Crear un objeto Empleado dependiendo del sector seleccionado
            Empleado empleado;
            switch (sector)
            {
                case ESectorEmpleado.Acuatico:
                    empleado = new EmpleadoAcuatico(nombre, apellido, numeroEmpleado, dni, email);
                    break;
                case ESectorEmpleado.Felinos:
                    empleado = new EmpleadoFelinos(nombre, apellido, numeroEmpleado, dni, email);
                    break;
                case ESectorEmpleado.Aves:
                    empleado = new EmpleadoAves(nombre, apellido, numeroEmpleado, dni, email);
                    break;
                default:
                    MessageBox.Show("Sector no válido.");
                    return;
            }

            // Agregar el empleado a la lista y al DataGridView
            listaEmpleados.Add(empleado);
            dataGridViewEmpleados.Rows.Add(empleado.NumeroEmpleado, empleado.Nombre, empleado.Apellido, empleado.Sector, empleado.Dni, empleado.Email);

            // Mostrar la información del empleado ingresado en un MessageBox
            MessageBox.Show($"Empleado creado:\nNombre: {empleado.Nombre} {empleado.Apellido}\n" +
                            $"Número de Empleado: {empleado.NumeroEmpleado}\nSector: {empleado.Sector}\n" +
                            $"DNI: {empleado.Dni}\nEmail: {empleado.Email}", "Empleado Guardado");

            // Limpiar los campos después de agregar
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxNumeroEmpleado.Clear();
            textBoxDni.Clear();
            textBoxEmail.Clear();
            comboBoxSector.SelectedIndex = 0;
        }

        private void dataGridViewEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el sector del empleado seleccionado
                var selectedRow = dataGridViewEmpleados.SelectedRows[0];
                var sector = (ESectorEmpleado)selectedRow.Cells["Sector"].Value;

                // Habilitar los botones según el sector del empleado
                switch (sector)
                {
                    case ESectorEmpleado.Acuatico:
                        // Habilitar solo los botones de tareas de Animales Acuáticos
                        buttonLimpiarJaulas.Enabled = false;
                        buttonAlimentarFelinos.Enabled = false;
                        buttonSacarFelinos.Enabled = false;
                        buttonLimpiarBebederos.Enabled = false;
                        buttonLimpiarPasillos.Enabled = false;

                        buttonLimpiarEstanque.Enabled = true;
                        buttonAlimentarEstanque.Enabled = true;
                        break;

                    case ESectorEmpleado.Felinos:
                        // Habilitar solo los botones de tareas de Felinos
                        buttonLimpiarEstanque.Enabled = false;
                        buttonAlimentarEstanque.Enabled = false;
                        buttonLimpiarBebederos.Enabled = false;
                        buttonLimpiarPasillos.Enabled = false;

                        buttonLimpiarJaulas.Enabled = true;
                        buttonAlimentarFelinos.Enabled = true;
                        buttonSacarFelinos.Enabled = true;
                        break;

                    case ESectorEmpleado.Aves:
                        // Habilitar solo los botones de tareas de Aves
                        buttonLimpiarEstanque.Enabled = false;
                        buttonAlimentarEstanque.Enabled = false;
                        buttonLimpiarJaulas.Enabled = false;
                        buttonAlimentarFelinos.Enabled = false;
                        buttonSacarFelinos.Enabled = false;

                        buttonLimpiarBebederos.Enabled = true;
                        buttonLimpiarPasillos.Enabled = true;
                        break;
                }
            }
        }

        // Método para iniciar una tarea
        public async void IniciarTarea(string nombreTarea, int numeroEmpleado)
        {
            // Guardar el tiempo de inicio con la clave compuesta de tarea y número de empleado
            tiempoInicioTarea[(nombreTarea, numeroEmpleado)] = DateTime.Now;
            MessageBox.Show($"Empleado con N° {numeroEmpleado} ha iniciado la tarea: '{nombreTarea}' a las {DateTime.Now}");

            // Esperar un tiempo para simular duración de la tarea
            await Task.Delay(5000);

            // Llamar automáticamente a FinalizarTarea después de la espera
            FinalizarTarea(nombreTarea, numeroEmpleado);
        }

        // Método para finalizar una tarea, registrando el tiempo de finalización
        public void FinalizarTarea(string nombreTarea, int numeroEmpleado)
        {
            // Verificar si la tarea fue iniciada
            var claveTarea = (nombreTarea, numeroEmpleado);
            if (tiempoInicioTarea.ContainsKey(claveTarea))
            {
                DateTime tiempoInicio = tiempoInicioTarea[claveTarea];
                DateTime tiempoFinal = DateTime.Now;
                TimeSpan duracion = tiempoFinal - tiempoInicio;

                // Mostrar el mensaje de finalización en la consola
                MessageBox.Show($"Empleado con N° {numeroEmpleado} ha finalizado la tarea: '{nombreTarea}' a las {tiempoFinal} - Duración: {duracion.TotalSeconds} segundos.");

                // Registrar la tarea en ReporteProductividad
                var reporteProductividad = ReporteProductividad.Instancia;
                reporteProductividad.RegistrarTarea(numeroEmpleado.ToString(), duracion);

                // Eliminar el registro de la tarea finalizada
                tiempoInicioTarea.Remove(claveTarea);
            }
            else
            {
                MessageBox.Show($"No se ha iniciado la tarea '{nombreTarea}' para el empleado N° {numeroEmpleado}, por lo que no se puede finalizar.");
            }
        }

        private void buttonLimpiarEstanque_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Limpiar Estanque", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonAlimentarEstanque_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Alimentar Estanque", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarJaulas_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Limpiar Jaulas", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonAlimentarFelinos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Alimentar Felinos", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonSacarFelinos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Sacar Felinos", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarBebederos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Limpiar Bebederos", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarPasillos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                // Llamar a IniciarTarea con el nombre de la tarea y el número de empleado
                IniciarTarea("Limpiar Pasillos", numeroEmpleado);
            }
            else
            {
                Console.WriteLine("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        // Método para generar y mostrar el reporte de productividad
        private void buttonGenerarReporte_Click(object sender, EventArgs e)
        {
            var formularioReporte = new FormularioReporteProductividad(listaEmpleados);
            formularioReporte.ShowDialog();
        }

    }
}
