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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Formularios
{
    public partial class FrmTractor : FrmVehiculo
    {

        private Tractor tractor = new Tractor();

        public Tractor Tractor
        {
            get { return tractor; }
            set { tractor = value; }
        }
        public FrmTractor()
        {
            InitializeComponent();
        }
        public FrmTractor(Tractor tractor) : this()
        {
            this.txtMarca.Text = tractor.Marca;
            this.txtModelo.Text = tractor.Modelo;
            this.txtAño.Text = tractor.Año.ToString();
            this.txtPesoEnKG.Text = tractor.PesoEnKG.ToString();
            this.txtPotencia.Text = tractor.Potencia.ToString();
            this.cmboxMotor.Text = tractor.Motor.ToString();
            this.comboxTamaño.Text = tractor.Tamaño.ToString();
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

                if (!int.TryParse(this.txtPesoEnKG.Text, out int pesoEnKG))
                {
                    throw new Exception("Ingrese correctamente el peso en KG");
                }

                if (!int.TryParse(this.txtPotencia.Text, out int potencia))
                {
                    throw new Exception("Ingrese correctamente la potencia");
                }
           
                if (this.comboxTamaño.SelectedItem == null)
                {
                    throw new Exception("Elegir correctamente el tamaño");
                }

                string tamaño = this.comboxTamaño.Text;
                tractor = new Tractor(marca, modelo, año, motor, tamaño, potencia, pesoEnKG);
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
            this.txtPesoEnKG.Text = "";
            this.txtPotencia.Text = "";
            this.cmboxMotor.Text = "";
            this.comboxTamaño.Text = "";
        }
    }
}


