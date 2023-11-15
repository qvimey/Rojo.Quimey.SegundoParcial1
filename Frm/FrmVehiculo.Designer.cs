namespace Formularios
{
    partial class FrmVehiculo
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
            lblmarca = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            txtAño = new TextBox();
            btnAceptar = new Button();
            btnResetear = new Button();
            cmboxMotor = new ComboBox();
            SuspendLayout();
            // 
            // lblmarca
            // 
            lblmarca.AutoSize = true;
            lblmarca.Location = new Point(12, 9);
            lblmarca.Name = "lblmarca";
            lblmarca.Size = new Size(40, 15);
            lblmarca.TabIndex = 0;
            lblmarca.Text = "Marca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 2;
            label3.Text = "Año";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 176);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Motor";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(22, 27);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(139, 23);
            txtMarca.TabIndex = 4;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(22, 93);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(139, 23);
            txtModelo.TabIndex = 5;
            // 
            // txtAño
            // 
            txtAño.Location = new Point(22, 150);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(139, 23);
            txtAño.TabIndex = 6;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(173, 232);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnResetear
            // 
            btnResetear.Location = new Point(254, 232);
            btnResetear.Name = "btnResetear";
            btnResetear.Size = new Size(75, 23);
            btnResetear.TabIndex = 9;
            btnResetear.Text = "Resetear";
            btnResetear.UseVisualStyleBackColor = true;
            // 
            // cmboxMotor
            // 
            cmboxMotor.FormattingEnabled = true;
            cmboxMotor.Items.AddRange(new object[] { "Termico", "Electrico", "Hibrido", "A Gas" });
            cmboxMotor.Location = new Point(22, 204);
            cmboxMotor.Name = "cmboxMotor";
            cmboxMotor.Size = new Size(139, 23);
            cmboxMotor.TabIndex = 10;
            // 
            // FrmVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 261);
            Controls.Add(cmboxMotor);
            Controls.Add(btnResetear);
            Controls.Add(btnAceptar);
            Controls.Add(txtAño);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblmarca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehiculo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblmarca;
        private Label label2;
        private Label label3;
        private Label label4;
        protected TextBox txtMarca;
        protected TextBox txtModelo;
        protected TextBox txtAño;
        protected Button btnResetear;
        protected ComboBox cmboxMotor;
        protected Button btnAceptar;
    }
}