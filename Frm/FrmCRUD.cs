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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                if (frmOpciones.eleccion == "Autos")
                {
                    garaje += frmOpciones.auto;
                    accesoDatos.InsertarDatos(frmOpciones.auto);
                }
                if (frmOpciones.eleccion == "Tractores")
                {
                    garaje += frmOpciones.tractor;
                    accesoDatos.InsertarDatos(frmOpciones.tractor);
                }
                if (frmOpciones.eleccion == "Camiones")
                {
                    garaje += frmOpciones.camion;
                    accesoDatos.InsertarDatos(frmOpciones.camion);
                }
            }
            ActualizarVisor();
            ActualizarListaVehiculos(frmOpciones.eleccion);
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
            AccesoDatos acceso = new AccesoDatos();
            Vehiculo vehiculoSeleccionado = (Vehiculo)this.ltsbox.SelectedItem;
           
            if (vehiculoSeleccionado != null)
            {
                if (vehiculoSeleccionado is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)vehiculoSeleccionado, vehiculoSeleccionado.Id);
                    frmAuto.ShowDialog();

                    List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Autos");
                    int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);
                    if (index != -1)
                    {
                        listaVehiculos[index] = frmAuto.Auto;
                        if(frmAuto.DialogResult == DialogResult.OK)
                        {
                            acceso.ModificarDatos(frmAuto.Auto);
                            ActualizarVisor();
                            ActualizarListaVehiculos("Autos");
                        }
                    }
                }
                if (vehiculoSeleccionado is Tractor)
                {
                    FrmTractor frmTractor = new FrmTractor((Tractor)vehiculoSeleccionado, vehiculoSeleccionado.Id);
                    frmTractor.ShowDialog();

                    List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Tractores");
                    int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);

                    if (index != -1)
                    {
                        listaVehiculos[index] = frmTractor.Tractor;
                        if (frmTractor.DialogResult == DialogResult.OK)
                        {
                            acceso.ModificarDatos(frmTractor.Tractor);
                            ActualizarVisor();
                            ActualizarListaVehiculos("Tractores");
                        }
                    }
                }
                if (vehiculoSeleccionado is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)vehiculoSeleccionado, vehiculoSeleccionado.Id);
                    frmCamion.ShowDialog();

                    List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Camiones");
                    int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);

                    if (index != -1)
                    {
                        listaVehiculos[index] = frmCamion.Camion;
                        if (frmCamion.DialogResult == DialogResult.OK)
                        {
                            acceso.ModificarDatos(frmCamion.Camion);
                            ActualizarVisor();
                            ActualizarListaVehiculos("Camiones");
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.ltsbox.SelectedIndex != -1)
            {
                try
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este vehículo?",
                        "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        AccesoDatos acceso = new AccesoDatos();
                        Vehiculo vehiculoSeleccionado = (Vehiculo)this.ltsbox.SelectedItem;
                        if (vehiculoSeleccionado is Auto)
                        {
                            List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Autos");
                            int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);
                            if (index != -1)
                            {
                                listaVehiculos[index] = vehiculoSeleccionado;
            
                                bool eliminado = accesoDatos.EliminarDatos(vehiculoSeleccionado.Id, "Autos");
                                ActualizarVisor();
                                ActualizarListaVehiculos("Autos");
                                if (eliminado)
                                {
                                    MessageBox.Show("Vehiculo Eliminado");
                                }    
                            }
                        }
                        if (vehiculoSeleccionado is Camion)
                        {
                            List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Camiones");
                            int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);
                            if (index != -1)
                            {
                                listaVehiculos[index] = vehiculoSeleccionado;

                                bool eliminado = accesoDatos.EliminarDatos(vehiculoSeleccionado.Id, "Camiones");
                                ActualizarVisor();
                                ActualizarListaVehiculos("Camiones");
                                if (eliminado)
                                {
                                    MessageBox.Show("Camión Eliminado");
                                }
                            }
                        }
                        if (vehiculoSeleccionado is Tractor)
                        {
                            List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos("Tractores");
                            int index = listaVehiculos.FindIndex(v => v.Id == vehiculoSeleccionado.Id);
                            if (index != -1)
                            {
                                listaVehiculos[index] = vehiculoSeleccionado;

                                bool eliminado = accesoDatos.EliminarDatos(vehiculoSeleccionado.Id, "Tractores");
                                ActualizarVisor();
                                ActualizarListaVehiculos("Tractores");
                                if (eliminado)
                                {
                                    MessageBox.Show("Tractor Eliminado");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehículo para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                acceso.ObtenerListaDatos(elegirTabla.ObtenerDatoElegido());
                ActualizarListaVehiculos(elegirTabla.ObtenerDatoElegido());
            }
        }
        private void ActualizarListaVehiculos(string tabla)
        {
            this.ltsbox.Items.Clear();
            AccesoDatos acceso = new AccesoDatos();
            List<Vehiculo> listaVehiculos = acceso.ObtenerListaDatos(tabla);
            foreach (Vehiculo v in listaVehiculos)
            {
                this.ltsbox.Items.Add(v);
            }
        }
    }
}


