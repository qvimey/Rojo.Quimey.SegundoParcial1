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
using Clases;

namespace Formularios
{
    public partial class FrmCRUD : Form
    {
        private frmLogin frmLogin;
        private Garaje<Vehiculo> garaje = new Garaje<Vehiculo>();
        private string fecha;
        private string perfilUsuario = "";
        AccesoDatos accesoDatos = new AccesoDatos();


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
                    garaje = garaje + frmOpciones.auto;
                }
                else if (frmOpciones.eleccion == "tractor")
                {
                    garaje = garaje + frmOpciones.tractor;
                }
                else if (frmOpciones.eleccion == "camion")
                {
                    garaje = garaje + frmOpciones.camion;
                }
            }
            ActualizarVisor();
        }

        private void VerificarPerfil()
        {
            if (this.perfilUsuario == "supervisor")
            {
                this.btnEliminar.Visible = false;
                MessageBox.Show("Bienvenido al perfil de Supervisor, usted no podra eliminar datos");
            }
            else if (this.perfilUsuario == "vendedor")
            {
                this.btnEliminar.Visible = false;
                this.btnModificar.Visible = false;
                this.btnOrdenar.Visible = false;
                this.btnAgregar.Visible = false;
                MessageBox.Show("Bienvenido al perfil de Vendedor, usted solo podra ver los datos");
            }
            else
            {
                MessageBox.Show("Bienvenido al perfil de Admin");
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
                    if (index >= 0 && index < garaje.vehiculos.Count)
                    {
                        Vehiculo vehiculoAEliminar = garaje.vehiculos[index];
                        bool eliminado = accesoDatos.EliminarDatos(vehiculoAEliminar.Id, vehiculoAEliminar.Tabla);

                        if (eliminado)
                        { 
                            garaje = garaje - vehiculoAEliminar;
                            ActualizarVisor();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el vehículo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Índice de vehículo seleccionado fuera de rango");
                        MessageBox.Show(index.ToString());
                    }
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
            ElegirTabla elegirTabla = new ElegirTabla();
            AccesoDatos acceso = new AccesoDatos();
            DialogResult resultado = elegirTabla.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                this.ltsbox.Items.Clear();
                List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos(elegirTabla.ObtenerDatoElegido());

                foreach (Vehiculo v in listaVehiculos)
                {
                    this.ltsbox.Items.Add(v);
                }
            }
        }
    }
}


