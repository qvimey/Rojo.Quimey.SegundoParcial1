using Clases;
using ClassLibrary1;

namespace PruebasUnitarias
{
    [TestClass]
    public class AccesoDatosTests
    {
        [TestMethod]
        public void InsertarDatos_Auto_InsertaCorrectamente()
        {
            // Arrange
            AccesoDatos accesoDatos = new AccesoDatos();
            Auto auto = new Auto()
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Año = 2022,
                Motor = TipoMotor.Gas,
                VelocidadPunta = 200,
                Color = "Rojo"
            };

            // Act
            bool resultado = accesoDatos.InsertarDatos(auto);

            // Assert
            Assert.IsTrue(resultado);

        }
        [TestMethod]

        public void ContieneVehiculo_DebeDevolverFalseSiNoExiste()
        {
            // Arrange
            Garaje<Vehiculo> garaje = new Garaje<Vehiculo>();
            Vehiculo vehiculo = new Auto();

            // Act
            bool contieneVehiculo = garaje.ContieneVehiculo(vehiculo);

            // Assert
            Assert.IsFalse(contieneVehiculo);
        }

        [TestMethod]
        public void ContieneVehiculo_DebeDevolverTrueSiExiste()
        {
            // Arrange
            Garaje<Vehiculo> garaje = new Garaje<Vehiculo>();
            Vehiculo vehiculo = new Auto();
            garaje += vehiculo;

            // Act
            bool contieneVehiculo = garaje.ContieneVehiculo(vehiculo);

            // Assert
            Assert.IsTrue(contieneVehiculo);
        }
        
    }
}
