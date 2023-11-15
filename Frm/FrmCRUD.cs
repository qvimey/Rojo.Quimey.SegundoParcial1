using ClassLibrary1;
using Frm;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Numerics;

namespace Formularios
{
    public partial class FrmCRUD : Form
    {
        private frmLogin frmLogin;
        private Garaje garaje = new Garaje();
        private string fecha;
        string perfilUsuario = "";


        public FrmCRUD(frmLogin frmLogin, string _nombreUsuario, string perfilUsuario)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            MostrarFecha();
            this.txtBienvenido.Text = $"Bienvenido, {_nombreUsuario}";
            this.perfilUsuario = perfilUsuario;
            VerificarPerfil();
        }
        private void MostrarFecha()
        {
            fecha = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtFecha.Text = "Fecha: " + fecha;
        }
        public void ActualizarVisor()
        {
            this.ltsbox.Items.Clear();
            foreach (Vehiculo v in garaje.vehiculos)
            {
                this.ltsbox.Items.Add(v);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmOpciones frmOpciones = new FrmOpciones();
            frmOpciones.ShowDialog();

            if (frmOpciones.DialogResult == DialogResult.OK)
            {
                if (frmOpciones.eleccion == "auto")
                {
                    this.garaje += frmOpciones.auto;
                }
                else if (frmOpciones.eleccion == "tractor")
                {
                    this.garaje += frmOpciones.tractor;
                }
                else if (frmOpciones.eleccion == "camion")
                {
                    this.garaje += frmOpciones.camion;
                }
            }
            ActualizarVisor();
        }

        private void VerificarPerfil()
        {
            if (this.perfilUsuario == "supervisor")
            {
                this.btnEliminar.Visible = false;
            }
            if (this.perfilUsuario == "vendedor")
            {
                this.btnEliminar.Visible=false;
                this.btnModificar.Visible=false;
                this.btnOrdenar.Visible=false;
                this.btnAgregar.Visible=false;
            }

        }
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.frmLogin.Close();
            }

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

            if (this.ltsbox.SelectedIndex != -1)
            {
                int index = this.ltsbox.SelectedIndex;
                Vehiculo vehiculo = garaje.vehiculos[index];

                if (vehiculo is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)vehiculo);
                    frmAuto.ShowDialog();
                    if (frmAuto.DialogResult == DialogResult.OK)
                    {
                        garaje.vehiculos[index] = frmAuto.Auto;
                    }
                    ActualizarVisor();
                }
                if (vehiculo is Tractor)
                {
                    FrmTractor frmTractor = new FrmTractor((Tractor)vehiculo);
                    frmTractor.ShowDialog();
                    if (frmTractor.DialogResult == DialogResult.OK)
                    {
                        garaje.vehiculos[index] = frmTractor.Tractor;
                    }
                    ActualizarVisor();
                }
                if (vehiculo is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)vehiculo);
                    frmCamion.ShowDialog();
                    if (frmCamion.DialogResult == DialogResult.OK)
                    {
                        garaje.vehiculos[index] = frmCamion.Camion;
                    }
                    ActualizarVisor();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehiculo para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (this.ltsbox.SelectedIndex != -1)
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este vehículo?",
                    "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int index = this.ltsbox.SelectedIndex;
                    garaje.vehiculos.RemoveAt(index);
                    ActualizarVisor();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehículo para eliminar");
            }
        }

        private void BtnOrdenar_Click(object sender, EventArgs e)
        {
            FrmOrdenamiento ordenar = new FrmOrdenamiento(garaje);
            DialogResult resultado = ordenar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ActualizarVisor();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (garaje.vehiculos != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    using (saveFileDialog)
                    {
                        saveFileDialog.Filter = "XML Files ().xml)|.xml";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string nombre_del_archivo = saveFileDialog.FileName;

                            XmlSerializer serializador = new XmlSerializer(typeof(List<Vehiculo>));
                            using (XmlTextWriter lectura = new XmlTextWriter(nombre_del_archivo, Encoding.UTF8))
                            {
                                serializador.Serialize(lectura, garaje.vehiculos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargar_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog archivo = new OpenFileDialog();
                using (archivo)
                {
                    archivo.Filter = "XML Files (*.xml)|*.xml";

                    if (archivo.ShowDialog() == DialogResult.OK)
                    {
                        string nombre_archivo = archivo.FileName;
                        XmlSerializer serialize = new XmlSerializer(typeof(List<Vehiculo>));
                        try
                        {
                            using (XmlTextReader lector = new XmlTextReader(nombre_archivo))
                            {
                                garaje.vehiculos = (List<Vehiculo>)serialize.Deserialize(lector);
                            }
                            ActualizarVisor();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


