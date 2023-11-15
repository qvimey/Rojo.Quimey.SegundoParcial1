namespace Formularios
{
    partial class FrmCamion
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
            label5 = new Label();
            txtCapacidadCarga = new TextBox();
            label6 = new Label();
            comboxTamaño = new ComboBox();
            SuspendLayout();
            // 
            // btnResetear
            // 
            btnResetear.Click += BtnResetear_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(193, 9);
            label5.Name = "label5";
            label5.Size = new Size(135, 15);
            label5.TabIndex = 8;
            label5.Text = "Capacidad de Carga(KG)";
            // 
            // txtCapacidadCarga
            // 
            txtCapacidadCarga.Location = new Point(193, 27);
            txtCapacidadCarga.Name = "txtCapacidadCarga";
            txtCapacidadCarga.Size = new Size(136, 23);
            txtCapacidadCarga.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(193, 65);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 10;
            label6.Text = "Tamaño";
            // 
            // comboxTamaño
            // 
            comboxTamaño.FormattingEnabled = true;
            comboxTamaño.Items.AddRange(new object[] { "Chico", "Mediano", "Grande" });
            comboxTamaño.Location = new Point(193, 93);
            comboxTamaño.Name = "comboxTamaño";
            comboxTamaño.Size = new Size(134, 23);
            comboxTamaño.TabIndex = 11;
            // 
            // FrmCamion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(339, 262);
            Controls.Add(comboxTamaño);
            Controls.Add(label6);
            Controls.Add(txtCapacidadCarga);
            Controls.Add(label5);
            Name = "FrmCamion";
            Text = "Camion";
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAño, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnResetear, 0);
            Controls.SetChildIndex(cmboxMotor, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtCapacidadCarga, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(comboxTamaño, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        protected TextBox txtCapacidadCarga;
        private Label label6;
        protected ComboBox comboxTamaño;
    }
}