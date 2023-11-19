using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmVehiculo : Form
    {
        protected string marca;
        protected string modelo;
        protected int año;
        protected TipoMotor motor;
        protected int Id;
        public FrmVehiculo()
        {
            InitializeComponent();
        }

        protected bool VerificarDatos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtMarca.Text) || string.IsNullOrWhiteSpace(this.txtModelo.Text))
                {
                    throw new Exception("Rellene los campos vacíos");
                }

                if (!int.TryParse(this.txtAño.Text, out int año))
                {
                    throw new Exception("Ingrese un año válido");
                }

                if (this.cmboxMotor.SelectedItem == null)
                {
                    throw new Exception("Elija el motor");
                }

                marca = this.txtMarca.Text;
                modelo = this.txtModelo.Text;
                motor = (TipoMotor)this.cmboxMotor.SelectedIndex;
                Id = this.Id;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
