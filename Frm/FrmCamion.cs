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
    public partial class FrmCamion : FrmVehiculo
    {
        private Camion camion = new Camion();

        public Camion Camion
        {
            get { return camion; }
            set { camion = value; }
        }
        public FrmCamion()
        {
            InitializeComponent();
        }

        public FrmCamion(Camion camion) : this()
        {
            this.txtMarca.Text = camion.Marca;
            this.txtModelo.Text = camion.Modelo;
            this.txtAño.Text = camion.Año.ToString();
            this.txtCapacidadCarga.Text = camion.CapacidadDeCarga.ToString();
            this.comboxTamaño.Text = camion.Tamaño.ToString();
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarDatos())
                {
                    throw new Exception("Error al completar todos los casilleros");
                }

                if (!int.TryParse(this.txtAño.Text, out int año))
                {
                    throw new Exception("Ingrese correctamente el año");
                }

                if (!int.TryParse(this.txtCapacidadCarga.Text, out int capacidadCarga))
                {
                    throw new Exception("Ingrese correctamente la capacidad de carga");
                }

                if (this.comboxTamaño.SelectedItem == null)
                {
                    throw new Exception("Elegir correctamente el tamaño");
                }

                string tamaño = this.comboxTamaño.Text;
                camion = new Camion(marca, modelo, año, motor, tamaño, capacidadCarga);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnResetear_Click(object sender, EventArgs e)
        {
            this.txtMarca.Text = "";
            this.txtModelo.Text = "";
            this.txtAño.Text = "";
            this.txtCapacidadCarga.Text = "";
            this.comboxTamaño.Text = "";
            this.cmboxMotor.Text = "";
        }
    }
}
