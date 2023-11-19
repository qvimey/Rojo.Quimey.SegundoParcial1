using Clases;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmAuto : FrmVehiculo
    {
        private Auto auto;
        public Auto Auto
        {
            get { return auto; }
            set { auto = value; }
        }
        public FrmAuto()
        {
            InitializeComponent();
        }
        public FrmAuto(Auto auto) : this()
        {
            this.txtMarca.Text = auto.Marca;
            this.txtModelo.Text = auto.Modelo;
            this.txtAño.Text = auto.Año.ToString();
            this.txtColor.Text = auto.Color;
            this.txtVelocidadPunta.Text = auto.VelocidadPunta.ToString();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string color = txtColor.Text;

                if (!VerificarDatos())
                {
                    throw new Exception("Error al completar todos los casilleros");
                }

                if (!int.TryParse(this.txtVelocidadPunta.Text, out int velocidadMax))
                {
                    throw new Exception("Ingrese correctamente la velocidad máxima");
                }

                if (!int.TryParse(this.txtAño.Text, out int año))
                {
                    throw new Exception("Ingrese correctamente el año");
                }

                if (string.IsNullOrWhiteSpace(this.txtColor.Text))
                {
                    throw new Exception("Ingrese correctamente el color");
                }
                else
                {

                    auto = new Auto(marca, modelo, año, motor, velocidadMax, color);

                    DialogResult = DialogResult.OK;
                    AccesoDatos accesoDatos = new AccesoDatos();
                    if (accesoDatos.ExisteVehiculoEnBaseDeDatos(auto.Id))
                    {
                        accesoDatos.ModificarDatos(auto);
                    }
                    else
                    {
                        auto = new Auto(marca, modelo, año, motor, velocidadMax, color);
                        DialogResult = DialogResult.OK;
                        accesoDatos.InsertarDatos(auto);
                    }

                }
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
            this.txtColor.Text = "";
            this.txtVelocidadPunta.Text = "";
            this.cmboxMotor.Text = "";
        }
    }
}
