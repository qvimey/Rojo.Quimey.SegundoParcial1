namespace Formularios
{
    partial class FrmOrdenamiento
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
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            rbtnMotorDescendente = new RadioButton();
            rbtnMotorAscendente = new RadioButton();
            rbtnAñoDescendente = new RadioButton();
            rbtnAñoAscendente = new RadioButton();
            btnAceptar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Ordenamiento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 1;
            label2.Text = "Ordenar Por:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtnMotorDescendente);
            groupBox1.Controls.Add(rbtnMotorAscendente);
            groupBox1.Controls.Add(rbtnAñoDescendente);
            groupBox1.Controls.Add(rbtnAñoAscendente);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(155, 134);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Elija la opcion deseada";
            // 
            // rbtnMotorDescendente
            // 
            rbtnMotorDescendente.AutoSize = true;
            rbtnMotorDescendente.ForeColor = SystemColors.ButtonFace;
            rbtnMotorDescendente.Location = new Point(6, 97);
            rbtnMotorDescendente.Name = "rbtnMotorDescendente";
            rbtnMotorDescendente.Size = new Size(150, 19);
            rbtnMotorDescendente.TabIndex = 3;
            rbtnMotorDescendente.TabStop = true;
            rbtnMotorDescendente.Text = "Por Motor Descendente";
            rbtnMotorDescendente.UseVisualStyleBackColor = true;
            // 
            // rbtnMotorAscendente
            // 
            rbtnMotorAscendente.AutoSize = true;
            rbtnMotorAscendente.ForeColor = SystemColors.Control;
            rbtnMotorAscendente.Location = new Point(6, 72);
            rbtnMotorAscendente.Name = "rbtnMotorAscendente";
            rbtnMotorAscendente.Size = new Size(144, 19);
            rbtnMotorAscendente.TabIndex = 2;
            rbtnMotorAscendente.TabStop = true;
            rbtnMotorAscendente.Text = "Por Motor Ascendente";
            rbtnMotorAscendente.UseVisualStyleBackColor = true;
            // 
            // rbtnAñoDescendente
            // 
            rbtnAñoDescendente.AutoSize = true;
            rbtnAñoDescendente.ForeColor = SystemColors.ButtonFace;
            rbtnAñoDescendente.Location = new Point(6, 47);
            rbtnAñoDescendente.Name = "rbtnAñoDescendente";
            rbtnAñoDescendente.Size = new Size(139, 19);
            rbtnAñoDescendente.TabIndex = 1;
            rbtnAñoDescendente.TabStop = true;
            rbtnAñoDescendente.Text = "Por Año Descendente";
            rbtnAñoDescendente.UseVisualStyleBackColor = true;
            // 
            // rbtnAñoAscendente
            // 
            rbtnAñoAscendente.AutoSize = true;
            rbtnAñoAscendente.ForeColor = SystemColors.ButtonFace;
            rbtnAñoAscendente.Location = new Point(6, 22);
            rbtnAñoAscendente.Name = "rbtnAñoAscendente";
            rbtnAñoAscendente.Size = new Size(133, 19);
            rbtnAñoAscendente.TabIndex = 0;
            rbtnAñoAscendente.TabStop = true;
            rbtnAñoAscendente.Text = "Por Año Ascendente";
            rbtnAñoAscendente.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(40, 218);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(95, 38);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // FrmOrdenamiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(176, 269);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmOrdenamiento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ordenamiento";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rbtnAñoAscendente;
        private RadioButton rbtnMotorDescendente;
        private RadioButton rbtnMotorAscendente;
        private RadioButton rbtnAñoDescendente;
        private Button btnAceptar;
    }
}