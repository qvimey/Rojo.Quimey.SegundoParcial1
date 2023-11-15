using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IAutos
    {
        void ArrancarVehiculo();
        void Acelerar(int velocidadIncremento);
        void Pintar(string nuevoColor);
    }
    public interface ICamion
    {
        void ArrancarVehiculo();
        void CargarMercancia(double cantidad);
        void DescargarMercancia(double cantidad);

    }
    public interface ITractor
    {
        void ArrancarVehiculo();
        void ArarTierra();
        void Sembrar();
    }
}
    