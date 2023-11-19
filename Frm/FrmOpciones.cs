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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Formularios
{
    public partial class FrmOpciones : Form
    {
        public Auto auto;
        public Camion camion;
        public Tractor tractor;
        public string eleccion;

        public FrmOpciones()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radiobtnAuto.Checked)
                {
                    FrmAuto formAuto = new FrmAuto();
                    formAuto.ShowDialog();
                    if (formAuto.DialogResult == DialogResult.OK)
                    {
                        auto = formAuto.Auto;
                        eleccion = "Autos";
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (this.radiobtnTractor.Checked)
                {
                    FrmTractor formTractor = new FrmTractor();
                    formTractor.ShowDialog();
                    if (formTractor.DialogResult == DialogResult.OK)
                    {
                        tractor = formTractor.Tractor;
                        eleccion = "Tractores";
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (this.radiobtnCamion.Checked)
                {
                    FrmCamion formCamion = new FrmCamion();
                    formCamion.ShowDialog();
                    if (formCamion.DialogResult == DialogResult.OK)
                    {
                        camion = formCamion.Camion;
                        eleccion = "Camiones";
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Por favor, selecciona un tipo de vehículo.");
                }
                this.Hide();
                DialogResult = DialogResult.OK;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
