 using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;

namespace ClassLibrary1
{
    [XmlInclude(typeof(Auto))]
    [XmlInclude(typeof(Camion))]
    [XmlInclude(typeof(Tractor))]

    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public TipoMotor Motor { get; set; }

        public Vehiculo()
        {

        }
        public Vehiculo(string marca)
        {
            this.Marca = "Sin marca";
            this.Modelo = "Sin modelo";
            this.Año = 0;
            this.Motor = TipoMotor.Gas;
            this.Marca = marca;
        }

        public Vehiculo(string marca, string modelo) : this(marca)
        {
            this.Modelo = modelo;
        }

        public Vehiculo(string marca, string modelo, int año) : this(marca, modelo)
        {
            this.Año = año;
        }

        public Vehiculo(string marca, string modelo, int año, TipoMotor motor) : this(marca, modelo, año)
        {
            this.Motor = motor;
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return a.Marca == b.Marca && a.Modelo == b.Modelo && a.Año == b.Año;
        }

        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

        public virtual void ArrancarVehiculo()
        {
            Console.WriteLine("Iniciando motor del " + this.Marca + " " + this.Modelo);
        }

        public override string ToString()
        {
            return $"Vehículo: {this.Marca} {this.Modelo}, Año: {this.Año}, Motor: {this.Motor}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vehiculo vehiculo)
            {
                return this == vehiculo;
            }
            return false;
        }

        public static implicit operator string(Vehiculo vehiculo)
        {
            return vehiculo.ToString();
        }

        public static explicit operator int(Vehiculo vehiculo)
        {
            if (vehiculo is null)
            {
                throw new ArgumentNullException(nameof(vehiculo));
            }
            return vehiculo.Año;
        }

        protected abstract void IniciandoMotor();
    }
}