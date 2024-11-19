using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;
using Business;

namespace Zoologico
{
    public partial class FormularioEmpleado : Form
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

            // Validar que el número de empleado sea un número válido
            if (!int.TryParse(textBoxNumeroEmpleado.Text, out int numeroEmpleado))
            {
                MessageBox.Show("El número de empleado debe ser un número válido.");
                return;
            }

            try
            {
                // Obtener los datos ingresados en los TextBoxes
                string nombre = textBoxNombre.Text;
                string apellido = textBoxApellido.Text;
                string dni = textBoxDni.Text;
                string email = textBoxEmail.Text;
                ESectorEmpleado sector = (ESectorEmpleado)comboBoxSector.SelectedItem;

                // Crear instancia del empleado
                Empleado nuevoEmpleado = new EmpleadoGeneral(nombre, apellido, numeroEmpleado, dni, email, sector);

                // Llamar a EmpleadoService para agregar al empleado
                EmpleadoService empleadoService = new EmpleadoService();
                bool res = empleadoService.AgregarEmpleado(nuevoEmpleado);

                if (res)
                {
                    // Agregar el empleado al DataGridView
                    dataGridViewEmpleados.Rows.Add(
                        nuevoEmpleado.NumeroEmpleado,
                        nuevoEmpleado.Nombre,
                        nuevoEmpleado.Apellido,
                        nuevoEmpleado.Sector,
                        nuevoEmpleado.Dni,
                        nuevoEmpleado.Email
                    );

                    // Mostrar la información del empleado ingresado en un MessageBox
                    MessageBox.Show($"Empleado creado:\nNombre: {nuevoEmpleado.Nombre} {nuevoEmpleado.Apellido}\n" +
                                    $"Número de Empleado: {nuevoEmpleado.NumeroEmpleado}\nSector: {nuevoEmpleado.Sector}\n" +
                                    $"DNI: {nuevoEmpleado.Dni}\nEmail: {nuevoEmpleado.Email}", "Empleado Guardado");

                    // Limpiar los campos después de agregar
                    LimpiarCampos();

                }
                else
                {
                    MessageBox.Show("Ya existe un empleado con el mismo Número de Empleado o DNI");
                }
                
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de problemas (por ejemplo, duplicados)
                MessageBox.Show($"Error al agregar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxNumeroEmpleado.Clear();
            textBoxDni.Clear();
            textBoxEmail.Clear();
            comboBoxSector.SelectedIndex = -1;
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

        private void buttonLimpiarEstanque_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Limpiar Estanque", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }

        }

        private void buttonAlimentarEstanque_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Alimentar Estanque", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarJaulas_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Limpiar Jaulas", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonAlimentarFelinos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Alimentar Felinos", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonSacarFelinos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Sacar Felinos", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarBebederos_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Limpiar Bebederos", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void buttonLimpiarPasillos_Click(object sender, EventArgs e)
        {
            /// Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener el NumeroEmpleado de la fila seleccionada
                int numeroEmpleado = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["Número Empleado"].Value);

                accionTareas("Limpiar Pasillos", numeroEmpleado);

            }
            else
            {
                MessageBox.Show("Seleccione un empleado del listado para asignar la tarea.");
            }
        }

        private void accionTareas (string nombreTarea, int numeroEmpleado)
        {
            try
            {
                // Crear instancia de tarea
                Tarea nuevaTarea = new TareaGeneral(nombreTarea, numeroEmpleado);

                // Llamar a EmpleadoService para agregar al empleado
                tareaService = new TareaService();
                bool res = tareaService.IniciarTarea(nuevaTarea);

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de problemas (por ejemplo, duplicados)
                MessageBox.Show($"Error al hacer la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
