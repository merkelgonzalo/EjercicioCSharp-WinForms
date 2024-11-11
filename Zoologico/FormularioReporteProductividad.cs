using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Zoologico
{
    public partial class FormularioReporteProductividad : Form
    {
        private List<Empleado> listaEmpleados; // Variable de instancia
        public FormularioReporteProductividad(List<Empleado> listaEmpleados)
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatosReporte(listaEmpleados);
            ConfigurarBotonExportar();

            // Asignar listaEmpleados a la variable de instancia
            this.listaEmpleados = listaEmpleados;
        }

        private void ConfigurarDataGridView()
        {
            // Configura las columnas del DataGridView
            dataGridViewReporte.ColumnCount = 4;
            dataGridViewReporte.Columns[0].Name = "Nombre";
            dataGridViewReporte.Columns[1].Name = "Apellido";
            dataGridViewReporte.Columns[2].Name = "Total de Tareas";
            dataGridViewReporte.Columns[3].Name = "Total de Tiempo";
        }

        private void CargarDatosReporte(List<Empleado> listaEmpleados)
        {
            // Obtener las estadísticas desde ReporteProductividad
            var reporte = ReporteProductividad.Instancia.ObtenerEstadisticas();

            // Hacer un join entre los empleados y las estadísticas de reporte para obtener nombre y apellido
            var datosReporte = from emp in listaEmpleados
                               join est in reporte on emp.NumeroEmpleado.ToString() equals est.Key
                               select new
                               {
                                   emp.Nombre,
                                   emp.Apellido,
                                   TotalTareas = est.Value.totalTareas,
                                   TotalTiempo = est.Value.totalTiempo
                               };

            // Llenar el DataGridView con los datos procesados
            foreach (var item in datosReporte)
            {
                dataGridViewReporte.Rows.Add(item.Nombre, item.Apellido, item.TotalTareas, item.TotalTiempo);
            }
        }
        private void ConfigurarBotonExportar()
        {
            buttonExportarJSON.Click += buttonExportarJSON_Click;
            Controls.Add(buttonExportarJSON); // Añadir a los controles del formulario
        }
        private void buttonExportarJSON_Click(object sender, EventArgs e)
        {
            // Obtener las estadísticas desde ReporteProductividad
            var reporte = ReporteProductividad.Instancia.ObtenerEstadisticas();

            // Generar los datos de reporte combinando empleados con sus estadísticas
            var datosReporte = from emp in this.listaEmpleados
                               join est in reporte on emp.NumeroEmpleado.ToString() equals est.Key
                               select new ReporteEmpleado
                               {
                                   Nombre = emp.Nombre,
                                   Apellido = emp.Apellido,
                                   Sector = emp.Sector.ToString(),
                                   TiempoTotal = Math.Round(est.Value.totalTiempo, 2),
                                   TotalTareas = est.Value.totalTareas
                               };

            // Serializar a JSON
            string json = JsonSerializer.Serialize(datosReporte, new JsonSerializerOptions { WriteIndented = true });

            // Guardar en un archivo JSON
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo JSON (*.json)|*.json",
                Title = "Guardar Reporte de Productividad"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Reporte exportado exitosamente a JSON.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
