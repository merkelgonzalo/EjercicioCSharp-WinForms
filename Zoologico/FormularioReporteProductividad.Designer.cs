namespace Zoologico
{
    partial class FormularioReporteProductividad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewReporte = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            TotalTareas = new DataGridViewTextBoxColumn();
            TotalTiempo = new DataGridViewTextBoxColumn();
            buttonExportarJSON = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReporte).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewReporte
            // 
            dataGridViewReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReporte.Columns.AddRange(new DataGridViewColumn[] { Nombre, Apellido, TotalTareas, TotalTiempo });
            dataGridViewReporte.Location = new Point(12, 60);
            dataGridViewReporte.Name = "dataGridViewReporte";
            dataGridViewReporte.RowHeadersWidth = 51;
            dataGridViewReporte.Size = new Size(776, 364);
            dataGridViewReporte.TabIndex = 0;
            // 
            // Nombre
            // 
            Nombre.FillWeight = 150F;
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.Width = 125;
            // 
            // TotalTareas
            // 
            TotalTareas.HeaderText = "TotalTareas";
            TotalTareas.MinimumWidth = 6;
            TotalTareas.Name = "TotalTareas";
            TotalTareas.Width = 125;
            // 
            // TotalTiempo
            // 
            TotalTiempo.HeaderText = "TotalTiempo";
            TotalTiempo.MinimumWidth = 6;
            TotalTiempo.Name = "TotalTiempo";
            TotalTiempo.Width = 125;
            // 
            // buttonExportarJSON
            // 
            buttonExportarJSON.Location = new Point(670, 12);
            buttonExportarJSON.Name = "buttonExportarJSON";
            buttonExportarJSON.Size = new Size(118, 29);
            buttonExportarJSON.TabIndex = 1;
            buttonExportarJSON.Text = "Exportar JSON";
            buttonExportarJSON.UseVisualStyleBackColor = true;
            // 
            // FormularioReporteProductividad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonExportarJSON);
            Controls.Add(dataGridViewReporte);
            Name = "FormularioReporteProductividad";
            Text = "FormularioReporteProductividad";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewReporte;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn TotalTareas;
        private DataGridViewTextBoxColumn TotalTiempo;
        private Button buttonExportarJSON;
    }
}