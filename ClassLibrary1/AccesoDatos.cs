using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibrary1;

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

        /*public List<Vehiculo> ObtenerListaDatos()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "select id,cadena,entero,flotante from dato";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    Vehiculo dato = new Dato();
                    dato.id = (int)this.lector["id"];
                    dato.cadena = this.lector["cadena"].ToString();
                    dato.entero = (int)this.lector["entero"];
                    dato.flotante = (float)this.lector.GetDouble(3);
                    lista.Add(dato);
                }

                this.lector.Close();
            }
            catch
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return lista;
        }*/

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
                    this.comando.CommandText = "INSERT INTO Camiones(Marca, Modelo, Año, Motor, Tamaño, CapacidadCarga) " +
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
                // Manejar la excepción según tus necesidades.
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
    



       /* public bool ModificarDatos(Dato d)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", d.id);
                this.comando.Parameters.AddWithValue("@cadena", d.cadena);
                this.comando.Parameters.AddWithValue("@entero", d.entero);
                this.comando.Parameters.AddWithValue("@flotante", d.flotante);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"update dato set cadena = @cadena,entero = @entero,flotante=@flotante where id = @id";
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
        public bool EliminarDatos(int id)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@id", id);
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "DELETE FROM dato WHERE id = @id";
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
     }
}*/
