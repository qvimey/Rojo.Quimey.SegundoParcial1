using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Tractor : Vehiculo, ITractor
    {
        public int Potencia;
        public int PesoEnKG;
        public string Tamaño;

        public Tractor()
        {
        }

        public Tractor(string marca, string modelo, int año, TipoMotor motor) : base(marca, modelo, año, motor)
        {
            this.Potencia = 0;
            this.Tamaño = "Chico";
        }

        public Tractor(string marca, string modelo, int año, TipoMotor motor, string tamaño) : this(marca, modelo, año, motor)
        {
            this.Tamaño = tamaño;
        }

        public Tractor(string marca, string modelo, int año, TipoMotor motor, string tamaño, int potencia) : this(marca, modelo, año, motor, tamaño)
        {
            this.Potencia = potencia;
        }

        public Tractor(string marca, string modelo, int año, TipoMotor motor, string tamaño, int potencia, int pesoEnKG) : this(marca, modelo, año, motor, tamaño, potencia)
        {
            this.PesoEnKG = pesoEnKG;
        }

        protected override void IniciandoMotor()
        {
            Console.WriteLine("Iniciando Motor Tractor");
        }
        
        public override void ArrancarVehiculo()
        {
            Console.WriteLine("Arrancando el tractor");
        }

        public void ArarTierra()
        {
            Console.WriteLine("Arando la tierra con el tractor");
        }

        public void Sembrar()
        {
            Console.WriteLine("Sembrando con el tractor");
        }

        public override string ToString()
        {
            return $"Tractor: {this.Marca} {this.Modelo}, Año: {this.Año}, Motor: {this.Motor}, " +
                   $"Caballos de Fuerza: {this.Potencia}, Tamaño: {this.Tamaño}, Peso en KG: {this.PesoEnKG}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Tractor otroTractor)
            {
                return base.Equals(obj) &&
                       Motor == otroTractor.Motor &&
                       Tamaño == otroTractor.Tamaño &&
                       Potencia == otroTractor.Potencia &&
                       PesoEnKG == otroTractor.PesoEnKG;
            }
            return false;
        }
    }
}
