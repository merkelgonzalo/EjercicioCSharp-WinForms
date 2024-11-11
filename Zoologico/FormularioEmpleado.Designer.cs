namespace Zoologico
{
    partial class FormularioEmpleado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxNumeroEmpleado = new TextBox();
            textBoxDni = new TextBox();
            textBoxEmail = new TextBox();
            comboBoxSector = new ComboBox();
            buttonAgregarEmpleado = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dataGridViewEmpleados = new DataGridView();
            buttonLimpiarEstanque = new Button();
            buttonAlimentarEstanque = new Button();
            buttonLimpiarJaulas = new Button();
            buttonAlimentarFelinos = new Button();
            buttonSacarFelinos = new Button();
            buttonLimpiarBebederos = new Button();
            buttonLimpiarPasillos = new Button();
            buttonGenerarReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).BeginInit();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.AccessibleDescription = "";
            textBoxNombre.AccessibleName = "";
            textBoxNombre.Location = new Point(162, 31);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(193, 27);
            textBoxNombre.TabIndex = 0;
            // 
            // textBoxApellido
            // 
            textBoxApellido.AccessibleDescription = "";
            textBoxApellido.AccessibleName = "";
            textBoxApellido.Location = new Point(162, 64);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(193, 27);
            textBoxApellido.TabIndex = 1;
            // 
            // textBoxNumeroEmpleado
            // 
            textBoxNumeroEmpleado.AccessibleDescription = "";
            textBoxNumeroEmpleado.AccessibleName = "";
            textBoxNumeroEmpleado.Location = new Point(162, 97);
            textBoxNumeroEmpleado.Name = "textBoxNumeroEmpleado";
            textBoxNumeroEmpleado.Size = new Size(72, 27);
            textBoxNumeroEmpleado.TabIndex = 2;
            // 
            // textBoxDni
            // 
            textBoxDni.Location = new Point(162, 130);
            textBoxDni.Name = "textBoxDni";
            textBoxDni.Size = new Size(125, 27);
            textBoxDni.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(162, 163);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(193, 27);
            textBoxEmail.TabIndex = 4;
            // 
            // comboBoxSector
            // 
            comboBoxSector.FormattingEnabled = true;
            comboBoxSector.Location = new Point(162, 196);
            comboBoxSector.Name = "comboBoxSector";
            comboBoxSector.Size = new Size(151, 28);
            comboBoxSector.TabIndex = 5;
            // 
            // buttonAgregarEmpleado
            // 
            buttonAgregarEmpleado.Location = new Point(105, 270);
            buttonAgregarEmpleado.Name = "buttonAgregarEmpleado";
            buttonAgregarEmpleado.Size = new Size(154, 29);
            buttonAgregarEmpleado.TabIndex = 6;
            buttonAgregarEmpleado.Text = "Agregar Empleado";
            buttonAgregarEmpleado.UseVisualStyleBackColor = true;
            buttonAgregarEmpleado.Click += buttonAgregarEmpleado_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 38);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 7;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 71);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 8;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 104);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 9;
            label3.Text = "Nro. Empleado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 137);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 10;
            label4.Text = "DNI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 170);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 11;
            label5.Text = "E-Mail";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 203);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 12;
            label6.Text = "Sector";
            // 
            // dataGridViewEmpleados
            // 
            dataGridViewEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleados.Location = new Point(388, 31);
            dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            dataGridViewEmpleados.RowHeadersWidth = 51;
            dataGridViewEmpleados.Size = new Size(950, 268);
            dataGridViewEmpleados.TabIndex = 13;
            dataGridViewEmpleados.Click += dataGridViewEmpleados_SelectionChanged;
            // 
            // buttonLimpiarEstanque
            // 
            buttonLimpiarEstanque.Location = new Point(388, 330);
            buttonLimpiarEstanque.Name = "buttonLimpiarEstanque";
            buttonLimpiarEstanque.Size = new Size(210, 29);
            buttonLimpiarEstanque.TabIndex = 14;
            buttonLimpiarEstanque.Text = "Limpiar Estanque";
            buttonLimpiarEstanque.UseVisualStyleBackColor = true;
            buttonLimpiarEstanque.Click += buttonLimpiarEstanque_Click;
            // 
            // buttonAlimentarEstanque
            // 
            buttonAlimentarEstanque.Location = new Point(625, 330);
            buttonAlimentarEstanque.Name = "buttonAlimentarEstanque";
            buttonAlimentarEstanque.Size = new Size(210, 29);
            buttonAlimentarEstanque.TabIndex = 15;
            buttonAlimentarEstanque.Text = "Alimentar Estanque";
            buttonAlimentarEstanque.UseVisualStyleBackColor = true;
            buttonAlimentarEstanque.Click += buttonAlimentarEstanque_Click;
            // 
            // buttonLimpiarJaulas
            // 
            buttonLimpiarJaulas.Location = new Point(388, 380);
            buttonLimpiarJaulas.Name = "buttonLimpiarJaulas";
            buttonLimpiarJaulas.Size = new Size(210, 29);
            buttonLimpiarJaulas.TabIndex = 17;
            buttonLimpiarJaulas.Text = "Limpiar Jaulas";
            buttonLimpiarJaulas.UseVisualStyleBackColor = true;
            buttonLimpiarJaulas.Click += buttonLimpiarJaulas_Click;
            // 
            // buttonAlimentarFelinos
            // 
            buttonAlimentarFelinos.Location = new Point(625, 380);
            buttonAlimentarFelinos.Name = "buttonAlimentarFelinos";
            buttonAlimentarFelinos.Size = new Size(210, 29);
            buttonAlimentarFelinos.TabIndex = 16;
            buttonAlimentarFelinos.Text = "Alimentar Felinos";
            buttonAlimentarFelinos.UseVisualStyleBackColor = true;
            buttonAlimentarFelinos.Click += buttonAlimentarFelinos_Click;
            // 
            // buttonSacarFelinos
            // 
            buttonSacarFelinos.Location = new Point(863, 380);
            buttonSacarFelinos.Name = "buttonSacarFelinos";
            buttonSacarFelinos.Size = new Size(210, 29);
            buttonSacarFelinos.TabIndex = 18;
            buttonSacarFelinos.Text = "Sacar Felinos";
            buttonSacarFelinos.UseVisualStyleBackColor = true;
            buttonSacarFelinos.Click += buttonSacarFelinos_Click;
            // 
            // buttonLimpiarBebederos
            // 
            buttonLimpiarBebederos.Location = new Point(388, 428);
            buttonLimpiarBebederos.Name = "buttonLimpiarBebederos";
            buttonLimpiarBebederos.Size = new Size(210, 29);
            buttonLimpiarBebederos.TabIndex = 20;
            buttonLimpiarBebederos.Text = "Limpiar Bebederos";
            buttonLimpiarBebederos.UseVisualStyleBackColor = true;
            buttonLimpiarBebederos.Click += buttonLimpiarBebederos_Click;
            // 
            // buttonLimpiarPasillos
            // 
            buttonLimpiarPasillos.Location = new Point(625, 428);
            buttonLimpiarPasillos.Name = "buttonLimpiarPasillos";
            buttonLimpiarPasillos.Size = new Size(210, 29);
            buttonLimpiarPasillos.TabIndex = 19;
            buttonLimpiarPasillos.Text = "Limpiar Pasillos";
            buttonLimpiarPasillos.UseVisualStyleBackColor = true;
            buttonLimpiarPasillos.Click += buttonLimpiarPasillos_Click;
            // 
            // buttonGenerarReporte
            // 
            buttonGenerarReporte.Location = new Point(105, 515);
            buttonGenerarReporte.Name = "buttonGenerarReporte";
            buttonGenerarReporte.Size = new Size(154, 29);
            buttonGenerarReporte.TabIndex = 21;
            buttonGenerarReporte.Text = "Generar Reporte";
            buttonGenerarReporte.UseVisualStyleBackColor = true;
            buttonGenerarReporte.Click += buttonGenerarReporte_Click;
            // 
            // FormularioEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 600);
            Controls.Add(buttonGenerarReporte);
            Controls.Add(buttonLimpiarBebederos);
            Controls.Add(buttonLimpiarPasillos);
            Controls.Add(buttonSacarFelinos);
            Controls.Add(buttonLimpiarJaulas);
            Controls.Add(buttonAlimentarFelinos);
            Controls.Add(buttonAlimentarEstanque);
            Controls.Add(buttonLimpiarEstanque);
            Controls.Add(dataGridViewEmpleados);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAgregarEmpleado);
            Controls.Add(comboBoxSector);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxDni);
            Controls.Add(textBoxNumeroEmpleado);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Name = "FormularioEmpleado";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxNumeroEmpleado;
        private TextBox textBoxDni;
        private TextBox textBoxEmail;
        private ComboBox comboBoxSector;
        private Button buttonAgregarEmpleado;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dataGridViewEmpleados;
        private Button buttonLimpiarEstanque;
        private Button buttonAlimentarEstanque;
        private Button buttonLimpiarJaulas;
        private Button buttonAlimentarFelinos;
        private Button buttonSacarFelinos;
        private Button buttonLimpiarBebederos;
        private Button buttonLimpiarPasillos;
        private Button buttonGenerarReporte;
    }
}
