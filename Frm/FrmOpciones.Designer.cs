namespace Formularios
{
    partial class FrmOpciones
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
            radiobtnAuto = new RadioButton();
            radiobtnTractor = new RadioButton();
            radiobtnCamion = new RadioButton();
            Opciones = new Label();
            boxVehiculos = new GroupBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            boxVehiculos.SuspendLayout();
            SuspendLayout();
            // 
            // radiobtnAuto
            // 
            radiobtnAuto.AutoSize = true;
            radiobtnAuto.Location = new Point(6, 105);
            radiobtnAuto.Name = "radiobtnAuto";
            radiobtnAuto.Size = new Size(51, 19);
            radiobtnAuto.TabIndex = 0;
            radiobtnAuto.TabStop = true;
            radiobtnAuto.Text = "Auto";
            radiobtnAuto.UseVisualStyleBackColor = true;
            // 
            // radiobtnTractor
            // 
            radiobtnTractor.AutoSize = true;
            radiobtnTractor.Location = new Point(6, 65);
            radiobtnTractor.Name = "radiobtnTractor";
            radiobtnTractor.Size = new Size(61, 19);
            radiobtnTractor.TabIndex = 1;
            radiobtnTractor.TabStop = true;
            radiobtnTractor.Text = "Tractor";
            radiobtnTractor.UseVisualStyleBackColor = true;
            // 
            // radiobtnCamion
            // 
            radiobtnCamion.AutoSize = true;
            radiobtnCamion.Location = new Point(6, 25);
            radiobtnCamion.Name = "radiobtnCamion";
            radiobtnCamion.Size = new Size(67, 19);
            radiobtnCamion.TabIndex = 2;
            radiobtnCamion.TabStop = true;
            radiobtnCamion.Text = "Camion";
            radiobtnCamion.UseVisualStyleBackColor = true;
            // 
            // Opciones
            // 
            Opciones.AutoSize = true;
            Opciones.Location = new Point(12, 9);
            Opciones.Name = "Opciones";
            Opciones.Size = new Size(111, 15);
            Opciones.TabIndex = 3;
            Opciones.Text = "Seleccione Vehiculo";
            // 
            // boxVehiculos
            // 
            boxVehiculos.Controls.Add(radiobtnCamion);
            boxVehiculos.Controls.Add(radiobtnTractor);
            boxVehiculos.Controls.Add(radiobtnAuto);
            boxVehiculos.Location = new Point(12, 27);
            boxVehiculos.Name = "boxVehiculos";
            boxVehiculos.Size = new Size(163, 142);
            boxVehiculos.TabIndex = 4;
            boxVehiculos.TabStop = false;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 175);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 38);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(93, 175);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 38);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // FrmOpciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(182, 219);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(boxVehiculos);
            Controls.Add(Opciones);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmOpciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmOpciones";
            boxVehiculos.ResumeLayout(false);
            boxVehiculos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radiobtnAuto;
        private RadioButton radiobtnTractor;
        private RadioButton radiobtnCamion;
        private Label Opciones;
        private GroupBox boxVehiculos;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}