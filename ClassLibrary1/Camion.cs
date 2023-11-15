using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Camion : Vehiculo, ICamion
    {
        public int CapacidadDeCarga;
        public string Tamaño;

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
            return $"Camion: {this.Marca} {this.Modelo}, Año: {this.Año}, Motor: {this.Motor}, " +
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
        public override bool Equals(object? obj)
        {
            if (obj is Camion otroCamion)
            {
                return base.Equals(obj) &&
                       Motor == otroCamion.Motor &&
                       Tamaño == otroCamion.Tamaño &&
                       CapacidadDeCarga == otroCamion.CapacidadDeCarga;
            }
            return false;
        }
    }

}
