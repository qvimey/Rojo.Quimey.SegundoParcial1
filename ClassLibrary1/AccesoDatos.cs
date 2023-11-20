using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibrary1;
using System.Data;
using System.Collections;

namespace Clases
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        public SqlCommand comando;
        private SqlDataReader lector;

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion;
        }
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }
        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }
     
        public List<Vehiculo> ObtenerListaDatos(string Tabla)
        {
            Garaje<Vehiculo> lista = new Garaje<Vehiculo>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                if (Tabla == "Autos")
                {
                    this.comando.CommandText = $"SELECT Id, Marca, Modelo, Año, Motor, VelocidadPunta, Color FROM Autos ";
                }
                if (Tabla == "Camiones")
                {
                    this.comando.CommandText = "SELECT Id, Marca, Modelo, Año, Motor, Tamaño, CapacidadDeCarga FROM Camiones ";
                }
                if (Tabla == "Tractores")
                {
                    this.comando.CommandText = "SELECT Id, Marca, Modelo, Año, Motor, Tamaño, Potencia, PesoEnKG FROM Tractores ";
                }
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                while (lector.Read())
                {
                    int id = (int)lector["Id"];
                    string marca = lector["Marca"].ToString();
                    string modelo = lector["Modelo"].ToString();
                    int año = (int)lector["Año"];
                    TipoMotor motor = (TipoMotor)Enum.Parse(typeof(TipoMotor), lector["Motor"].ToString());

                    if (Tabla == "Autos")
                    {
                        int velocidadPunta = (int)lector["VelocidadPunta"];
                        string color = lector["Color"].ToString();

                        lista += new Auto(marca, modelo, año, motor, velocidadPunta, color, id);
                    }
                    if (Tabla == "Camiones")
                    {
                        string tamaño = lector["Tamaño"].ToString();
                        int capacidadCarga = (int)lector["CapacidadDeCarga"];

                        lista += (new Camion(marca, modelo, año, motor, tamaño, capacidadCarga,id));
                    }
                    if (Tabla == "Tractores")
                    {
                        string tamaño = lector["Tamaño"].ToString();
                        int potencia = (int)lector["Potencia"];
                        int pesoEnKG = (int)lector["PesoEnKG"];

                        lista += (new Tractor(marca, modelo, año, motor, tamaño, potencia, pesoEnKG,id));
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista.vehiculos;
        }
        
        public bool InsertarDatos(Vehiculo vehiculo)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                if (vehiculo is Auto)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "INSERT INTO Autos(Marca, Modelo, Año, Motor, VelocidadPunta, Color) " +
                                               "VALUES (@marca, @modelo, @año, @motor, @velocidadMax, @color)";
                }
                else if (vehiculo is Camion)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "INSERT INTO Camiones(Marca, Modelo, Año, Motor, Tamaño, CapacidadDeCarga) " +
                                               "VALUES (@marca, @modelo, @año, @motor, @tamaño, @capacidadCarga)";
                }
                else if (vehiculo is Tractor)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "INSERT INTO Tractores(Marca, Modelo, Año, Motor, Tamaño, Potencia, PesoEnKG) " +
                                               "VALUES (@marca, @modelo, @año, @motor, @tamaño, @potencia, @pesoEnKG)";
                }


                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
        public bool ExisteVehiculoEnBaseDeDatos(int id, string Tabla)
        {
            SqlConnection conexion = this.conexion;
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Id FROM {Tabla} WHERE Id = @id";
                comando.Parameters.Add("@id", (SqlDbType)id);
                comando.Connection = conexion;

                conexion.Open();
                int cantidad = (int)comando.ExecuteScalar();
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        public bool ModificarDatos(Vehiculo vehiculo)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                if (vehiculo is Auto)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "UPDATE Autos SET Marca = @marca, Modelo = @modelo, Año = @año, Motor = @motor, VelocidadPunta = @velocidadMax, Color = @color " +
                                               "WHERE Id = @id";
                }
                else if (vehiculo is Camion)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "UPDATE Camiones SET Marca = @marca, Modelo = @modelo, Año = @año, Motor = @motor, Tamaño = @tamaño, CapacidadDeCarga = @capacidadCarga " +
                                               "WHERE Id = @id";
                }
                else if (vehiculo is Tractor)
                {
                    vehiculo.ConfigurarComando(this.comando);
                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "UPDATE Tractores SET Marca = @marca, Modelo = @modelo, Año = @año, Motor = @motor, Tamaño = @tamaño, Potencia = @potencia, PesoEnKG = @pesoEnKG " +
                                               "WHERE Id = @id";
                }


                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
        public bool EliminarDatos(int id, string tabla)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", id);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"DELETE FROM {tabla} WHERE id = @id";

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }
    }
}
        
