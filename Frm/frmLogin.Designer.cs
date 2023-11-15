namespace Frm
{
    partial class frmLogin
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
            btnIngresar = new Button();
            btnCancelar = new Button();
            Usuario = new Label();
            Clave = new Label();
            txtClave = new TextBox();
            txtUsuario = new TextBox();
            checkBoxMostrar = new CheckBox();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(12, 220);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(135, 44);
            btnIngresar.TabIndex = 0;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += BtnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(153, 220);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 44);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // Usuario
            // 
            Usuario.AutoSize = true;
            Usuario.BackColor = SystemColors.ButtonHighlight;
            Usuario.Location = new Point(26, 56);
            Usuario.Name = "Usuario";
            Usuario.Size = new Size(50, 15);
            Usuario.TabIndex = 2;
            Usuario.Text = "Usuario:";
            // 
            // Clave
            // 
            Clave.AutoSize = true;
            Clave.BackColor = SystemColors.ControlLightLight;
            Clave.Location = new Point(26, 138);
            Clave.Name = "Clave";
            Clave.Size = new Size(39, 15);
            Clave.TabIndex = 3;
            Clave.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(127, 135);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(162, 23);
            txtClave.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(127, 53);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(162, 23);
            txtUsuario.TabIndex = 5;
            // 
            // checkBoxMostrar
            // 
            checkBoxMostrar.AutoSize = true;
            checkBoxMostrar.Location = new Point(295, 139);
            checkBoxMostrar.Name = "checkBoxMostrar";
            checkBoxMostrar.Size = new Size(15, 14);
            checkBoxMostrar.TabIndex = 6;
            checkBoxMostrar.UseVisualStyleBackColor = true;
            checkBoxMostrar.CheckedChanged += CheckBoxMostrar_CheckedChanged;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(310, 279);
            Controls.Add(checkBoxMostrar);
            Controls.Add(txtUsuario);
            Controls.Add(txtClave);
            Controls.Add(Clave);
            Controls.Add(Usuario);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingreso Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIngresar;
        private Button btnCancelar;
        private Label Usuario;
        private Label Clave;
        private TextBox txtClave;
        private TextBox txtUsuario;
        private CheckBox checkBoxMostrar;
    }
}