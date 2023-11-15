using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Garaje
    {
        public List<Vehiculo> vehiculos;
   
        public Garaje() 
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public void ActualizarVehiculo(Vehiculo v, Vehiculo v2)
        {
            int indiceVehiculoOriginal = vehiculos.FindIndex(
            v => v.Marca == v2.Marca && v.Año == v2.Año && v.Modelo == v2.Modelo);
            if (indiceVehiculoOriginal > -1)
            {
                vehiculos[indiceVehiculoOriginal] = v2;
            }
        }
        public bool ContieneVehiculo(Vehiculo vehiculo)
        {
            return vehiculos.Contains(vehiculo);
        }

        public static Garaje operator +(Garaje garaje, Vehiculo vehiculo)
        {
            if (!garaje.ContieneVehiculo(vehiculo))
            {
                garaje.vehiculos.Add(vehiculo);
            }
            return garaje;
        }

        public static Garaje operator -(Garaje garaje, Vehiculo vehiculo)
        {
            if (garaje.ContieneVehiculo(vehiculo))
            {
                garaje.vehiculos.Remove(vehiculo);
            }
            return garaje;
        }

        public static bool operator ==(Garaje garaje, Vehiculo vehiculo)
        {
            return garaje.ContieneVehiculo(vehiculo);
        }

        public static bool operator !=(Garaje garaje, Vehiculo vehiculo)
        {
            return !garaje.ContieneVehiculo(vehiculo);
        }
        public void OrdenarPorAñoAscendente()
        {
            this.vehiculos = this.vehiculos.OrderBy(v => v.Año).ToList();
        }

        public void OrdenarPorAñoDescendente()
        {
            this.vehiculos = this.vehiculos.OrderByDescending(v => v.Año).ToList();
        }
        public void OrdenarPorMotorAscendente()
        {
            this.vehiculos = this.vehiculos.OrderBy(v => v.Motor).ToList();
        }

        public void OrdenarPorMotorDescendente()
        {
            this.vehiculos = this.vehiculos.OrderByDescending(v => v.Motor).ToList();
        }
    }

    
}
