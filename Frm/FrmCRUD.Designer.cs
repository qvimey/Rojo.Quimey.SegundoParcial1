namespace Formularios
{
    partial class FrmCRUD
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnOrdenar = new Button();
            txtBienvenido = new Label();
            ltsbox = new ListBox();
            txtFecha = new Label();
            btnGuardar = new Button();
            btnCargar = new Button();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 335);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 51);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(182, 335);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(154, 51);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += BtnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(359, 335);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(161, 51);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(544, 335);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(165, 51);
            btnOrdenar.TabIndex = 3;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += BtnOrdenar_Click;
            // 
            // txtBienvenido
            // 
            txtBienvenido.AutoSize = true;
            txtBienvenido.ForeColor = SystemColors.HotTrack;
            txtBienvenido.Location = new Point(12, 9);
            txtBienvenido.Name = "txtBienvenido";
            txtBienvenido.Size = new Size(72, 15);
            txtBienvenido.TabIndex = 5;
            txtBienvenido.Text = "Bienvenido, ";
            // 
            // ltsbox
            // 
            ltsbox.BackColor = SystemColors.AppWorkspace;
            ltsbox.FormattingEnabled = true;
            ltsbox.ItemHeight = 15;
            ltsbox.Location = new Point(12, 39);
            ltsbox.Name = "ltsbox";
            ltsbox.Size = new Size(697, 289);
            ltsbox.TabIndex = 6;
            // 
            // txtFecha
            // 
            txtFecha.AutoSize = true;
            txtFecha.ForeColor = SystemColors.MenuHighlight;
            txtFecha.Location = new Point(262, 9);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(38, 15);
            txtFecha.TabIndex = 7;
            txtFecha.Text = "Fecha";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(544, 9);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 24);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(379, 9);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(150, 24);
            btnCargar.TabIndex = 9;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += BtnCargar_Click_1;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 398);
            Controls.Add(btnCargar);
            Controls.Add(btnGuardar);
            Controls.Add(txtFecha);
            Controls.Add(ltsbox);
            Controls.Add(txtBienvenido);
            Controls.Add(btnOrdenar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRUD";
            FormClosing += FrmCRUD_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnOrdenar;
        private Label txtBienvenido;
        private ListBox ltsbox;
        private Label txtFecha;
        private Button btnGuardar;
        private Button btnCargar;
    }
}