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
    public class Garaje<T> where T : Vehiculo
    {
        public List<T> vehiculos;

        public Garaje()
        {
            this.vehiculos = new List<T>();
        }

        public void ActualizarVehiculo(T v, T v2)
        {
            int indiceVehiculoOriginal = vehiculos.FindIndex(
                vehiculo => vehiculo.Marca == v2.Marca && vehiculo.Año == v2.Año && vehiculo.Modelo == v2.Modelo);

            if (indiceVehiculoOriginal > -1)
            {
                vehiculos[indiceVehiculoOriginal] = v2;
            }
        }

        public bool ContieneVehiculo(T vehiculo)
        {
            return vehiculos.Contains(vehiculo);
        }

        public static Garaje<T> operator +(Garaje<T> garaje, T vehiculo)
        {
            if (!garaje.ContieneVehiculo(vehiculo))
            {
                garaje.vehiculos.Add(vehiculo);
            }
            return garaje;
        }

        public static Garaje<T> operator -(Garaje<T> garaje, T vehiculo)
        {
            if (garaje.ContieneVehiculo(vehiculo))
            {
                garaje.vehiculos.Remove(vehiculo);
            }
            return garaje;
        }

        public static bool operator ==(Garaje<T> garaje, T vehiculo)
        {
            return garaje.ContieneVehiculo(vehiculo);
        }

        public static bool operator !=(Garaje<T> garaje, T vehiculo)
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
        public void AddRange(List<T> listaVehiculos)
        {
            foreach (var vehiculo in listaVehiculos)
            {
                if (!ContieneVehiculo(vehiculo))
                {
                    vehiculos.Add(vehiculo);
                }
            }
        }
    }
}