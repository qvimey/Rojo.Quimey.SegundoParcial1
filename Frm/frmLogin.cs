using Formularios;
using System.Text.Json;
using ClassLibrary1;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;

namespace Frm
{
    public partial class frmLogin : Form
    {
        private Usuario[] ListaUsuarios;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void CargarUsuarios()
        {

            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MOCK_DATA.json");

            try
            {
                if (File.Exists(jsonFilePath))
                {
                    using (StreamReader lector = new StreamReader(jsonFilePath))
                    {
                        string json = lector.ReadToEnd();
                        this.ListaUsuarios = JsonSerializer.Deserialize<Usuario[]>(json);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo JSON no existe en la ubicación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Error al deserializar el archivo JSON: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "";
            this.txtClave.Text = "";
            DialogResult = DialogResult.Cancel;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarUsuarios();

                string nombreUsuario = "";
                string correoIngresado = this.txtUsuario.Text;
                string contraseñaIngresada = this.txtClave.Text;
                bool inicioSesionExitoso = false;
                string perfilUsuario = "";

                if (ListaUsuarios != null)
                {
                    foreach (var usuario in ListaUsuarios)
                    {
                        if (usuario != null && usuario.correo != null && usuario.clave != null)
                        {
                            if (usuario.correo == correoIngresado && usuario.clave == contraseñaIngresada)
                            {
                                inicioSesionExitoso = true;
                                nombreUsuario = usuario.nombre;
                                perfilUsuario = usuario.perfil;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La lista de usuarios no está inicializada.");
                }

                this.Hide();

                if (inicioSesionExitoso)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    DialogResult = DialogResult.OK;
                    FrmCRUD frmCRUD = new FrmCRUD(this, nombreUsuario, perfilUsuario);
                    frmCRUD.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Inténtalo de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CheckBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrar.Checked)
            {
                this.txtClave.PasswordChar = '\0';
            }
            else
            {
                this.txtClave.PasswordChar = '*';
            }
        }
    }
}

