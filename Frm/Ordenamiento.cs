using Clases;
using ClassLibrary1;
using Frm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmOrdenamiento : Form
    {
        private Garaje<Vehiculo> garaje;

        public Garaje<Vehiculo> Garaje
        {
            get { return garaje; }
            set { garaje = value; }
        }

        public FrmOrdenamiento(Garaje<Vehiculo> garaje)
        {
            InitializeComponent();
            this.garaje = garaje;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (rbtnAñoAscendente.Checked)
            {
                garaje.OrdenarPorAñoAscendente();
                DialogResult = DialogResult.OK;
            }
            else if (rbtnAñoDescendente.Checked)
            {
                garaje.OrdenarPorAñoDescendente();
                DialogResult = DialogResult.OK;
            }
            else if (rbtnMotorAscendente.Checked)
            {
                garaje.OrdenarPorMotorAscendente();
                DialogResult = DialogResult.OK;
            }
            else if (rbtnMotorDescendente.Checked)
            {
                garaje.OrdenarPorMotorDescendente();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un criterio de ordenación.");
            }

        }
    }
}
