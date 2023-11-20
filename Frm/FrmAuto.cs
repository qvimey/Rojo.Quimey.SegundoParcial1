using Clases;
using ClassLibrary1;
using System;
using System.Collections;
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
        public FrmAuto(Auto auto,int index) : this()
        {
            this.txtMarca.Text = auto.Marca;
            this.txtModelo.Text = auto.Modelo;
            this.txtAño.Text = auto.Año.ToString();
            this.txtColor.Text = auto.Color;
            this.txtVelocidadPunta.Text = auto.VelocidadPunta.ToString();
            this.Id = index;
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
                    try
                    {
                        AccesoDatos acceso = new AccesoDatos();
                        if (acceso.ExisteVehiculoEnBaseDeDatos(this.Id, "Autos"))
                        {
                            acceso.ModificarDatos(this.auto);
                        }
                        else
                        {
                            acceso.InsertarDatos(auto = new Auto(marca, modelo, año, motor, velocidadMax, color, this.Id));
                        }
                        DialogResult = DialogResult.OK;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al modificar/insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
