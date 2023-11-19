using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Auto : Vehiculo, IAutos
    {
        public int VelocidadPunta;
        public string Color;
        public override string Tabla => "Autos";

        public Auto()
        {

        }

        public Auto(string marca, string modelo, int año, TipoMotor motor) : base(marca, modelo, año, motor)
        {
            this.Color = "color a confirmar";
            this.VelocidadPunta = 0;
        }

        public Auto(string marca, string modelo, int año, TipoMotor motor, int velocidadPunta) : this(marca, modelo, año, motor)
        {
            this.VelocidadPunta = velocidadPunta;
        }

        public Auto(string marca, string modelo, int año, TipoMotor motor, int velocidadPunta, string color) : this(marca, modelo, año, motor, velocidadPunta)
        {
            this.Color = color;
        }

        public override void ArrancarVehiculo()
        {
            Console.WriteLine("Arrancando Auto");
        }

        public override string ToString()
        {
            return $"Id:{this.Id} Coche: {this.Marca} , {this.Modelo} - Año: {this.Año} - Motor: {this.Motor} - " +
                   $"Velocidad Punta: {this.VelocidadPunta} km/h - Color: {this.Color}";
        }
        protected override void IniciandoMotor()
        {
            Console.WriteLine("Motor Iniciado Auto");
        }
        public override bool Equals(object obj)
        {
            if (obj is Auto otroAuto)
            {
                return base.Equals(obj) &&
                       VelocidadPunta == otroAuto.VelocidadPunta &&
                       Color == otroAuto.Color;
            }

            return false;
        }

        public void Acelerar(int velocidadIncremento)
        {
            VelocidadPunta += velocidadIncremento;
            Console.WriteLine($"Acelerando... Nueva velocidad: {VelocidadPunta} km/h");
        }

        public void Pintar(string nuevoColor)
        {
            Console.WriteLine($"Pintando... Nuevo color: {nuevoColor}");
        }
  
        public override void ConfigurarComando(SqlCommand comando)
        {
            base.ConfigurarComando(comando); 

            comando.Parameters.AddWithValue("@velocidadMax", this.VelocidadPunta);
            comando.Parameters.AddWithValue("@color", this.Color);
        }
    }
}
    

