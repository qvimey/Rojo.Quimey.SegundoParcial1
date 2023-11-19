using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Camion : Vehiculo, ICamion
    {
        public int CapacidadDeCarga;
        public string Tamaño;
        public override string Tabla => "Camiones";
        public Camion()
        {

        }

        public Camion(string marca, string modelo, int año, TipoMotor motor) : base(marca, modelo, año, motor)
        {
            this.CapacidadDeCarga = 0;
            this.Tamaño = "Chico";
        }


        public Camion(string marca, string modelo, int año, TipoMotor motor, string tamaño) : this(marca, modelo, año, motor)
        {
            this.Tamaño = tamaño;
        }

        public Camion(string marca, string modelo, int año, TipoMotor motor, string tamaño, int capacidadDeCarga) : this(marca, modelo, año, motor, tamaño)
        {
            this.CapacidadDeCarga = capacidadDeCarga;
        }

        public void Arrancar_Vehiculo()
        {
            Console.WriteLine("Camion");
        }
        public override string ToString()
        {
            return $"Id:{this.Id} Camion: {this.Marca} , {this.Modelo}, Año: {this.Año}, Motor: {this.Motor}, " +
                   $"Capacidad MAX: {this.CapacidadDeCarga}, Tamaño: {this.Tamaño}";
        }
        public override void ArrancarVehiculo()
        {
            Console.WriteLine("Arrancando el camión");
        }

        public void CargarMercancia(double cantidad)
        {
            Console.WriteLine($"Cargando {cantidad} toneladas de mercancía en el camión");
        }

        public void DescargarMercancia(double cantidad)
        {
            Console.WriteLine($"Descargando {cantidad} toneladas de mercancía del camión");
        }

        protected override void IniciandoMotor()
        {
            Console.WriteLine("Motor Iniciado Camion");
        }
        public override bool Equals(object obj)
        {
            if (obj is Camion otroCamion)
            {
                return base.Equals(obj) &&
                       Tamaño == otroCamion.Tamaño &&
                       CapacidadDeCarga == otroCamion.CapacidadDeCarga;
            }

            return false;
        }
        public override void ConfigurarComando(SqlCommand comando)
        {
            base.ConfigurarComando(comando); 

            comando.Parameters.AddWithValue("@tamaño", this.Tamaño);
            comando.Parameters.AddWithValue("@capacidadCarga", this.CapacidadDeCarga);
        }
    }

}
