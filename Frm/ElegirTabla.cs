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
    public partial class ElegirTabla : Form
    {
        private string datoSeleccionado;
        public ElegirTabla()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string datoSeleccionado = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(datoSeleccionado))
            {
                this.datoSeleccionado = datoSeleccionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento antes de hacer clic en Aceptar.");
            }
        }

        public string ObtenerDatoElegido()
        {
            return this.datoSeleccionado;
        }
    }
}
