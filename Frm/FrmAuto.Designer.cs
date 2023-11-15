namespace Formularios
{
    partial class FrmAuto
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
            txtVelocidadPunta = new TextBox();
            txtColor = new TextBox();
            label6 = new Label();
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
            label5.Location = new Point(197, 9);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 8;
            label5.Text = "Velocidad Max";
            // 
            // txtVelocidadPunta
            // 
            txtVelocidadPunta.Location = new Point(197, 27);
            txtVelocidadPunta.Name = "txtVelocidadPunta";
            txtVelocidadPunta.Size = new Size(132, 23);
            txtVelocidadPunta.TabIndex = 9;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(197, 93);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(132, 23);
            txtColor.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(197, 75);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 11;
            label6.Text = "Color";
            // 
            // FrmAuto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(344, 264);
            Controls.Add(label6);
            Controls.Add(txtColor);
            Controls.Add(txtVelocidadPunta);
            Controls.Add(label5);
            Name = "FrmAuto";
            Text = "Auto";
            Controls.SetChildIndex(txtMarca, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtAño, 0);
            Controls.SetChildIndex(btnAceptar, 0);
            Controls.SetChildIndex(btnResetear, 0);
            Controls.SetChildIndex(cmboxMotor, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(txtVelocidadPunta, 0);
            Controls.SetChildIndex(txtColor, 0);
            Controls.SetChildIndex(label6, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox txtVelocidadPunta;
        private TextBox txtColor;
        private Label label6;
    }
}