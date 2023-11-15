namespace Formularios
{
    partial class FrmTractor
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
            label7 = new Label();
            txtPotencia = new TextBox();
            label1 = new Label();
            txtPesoEnKG = new TextBox();
            label5 = new Label();
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(193, 65);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 12;
            label7.Text = "Potencia";
            // 
            // txtPotencia
            // 
            txtPotencia.Location = new Point(193, 93);
            txtPotencia.Name = "txtPotencia";
            txtPotencia.Size = new Size(136, 23);
            txtPotencia.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 14;
            label1.Text = "Peso en KG";
            // 
            // txtPesoEnKG
            // 
            txtPesoEnKG.Location = new Point(193, 27);
            txtPesoEnKG.Name = "txtPesoEnKG";
            txtPesoEnKG.Size = new Size(136, 23);
            txtPesoEnKG.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(193, 130);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 16;
            label5.Text = "Tamaño";
            // 
            // comboxTamaño
            // 
            comboxTamaño.FormattingEnabled = true;
            comboxTamaño.Items.AddRange(new object[] { "Chico", "Mediano", "Grande" });
            comboxTamaño.Location = new Point(193, 150);
            comboxTamaño.Name = "comboxTamaño";
            comboxTamaño.Size = new Size(136, 23);
            comboxTamaño.TabIndex = 17;
            // 
            // FrmTractor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(349, 266);
            Controls.Add(comboxTamaño);
            Controls.Add(label5);
            Controls.Add(txtPesoEnKG);
            Controls.Add(label1);
            Controls.Add(txtPotencia);
            Controls.Add(label7);
            Name = "FrmTractor";
            Text = "FrmTractor";
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAño, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnResetear, 0);
            Controls.SetChildIndex(cmboxMotor, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(txtPotencia, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(txtPesoEnKG, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(comboxTamaño, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox txtPotencia;
        private Label label1;
        private TextBox txtPesoEnKG;
        private Label label5;
        private ComboBox comboxTamaño;
    }
}