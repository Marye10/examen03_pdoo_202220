using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cadena_De_Responsabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionDirectior.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            //Arrange
            Ejecutivo[] unEjecutivo =
            {
               new Director() {Nombre = "Elvis Presley", Monto = 2000000},
               new Presidente() {Nombre = "Jerry Lee Lewis", Monto = 3000000},
               new Coordinador() {Nombre = "Frank Sinatra", Monto = 100000}
            };

            Pedido pruebaPedido = new Pedido();
            valor.Pedido() = 150000;

            //Act
            string aprobadorEsperado = Program.Main(AprobacionPedido("Director"));

            //Assert
            Assert.AreEqual(aprobadorEsperado);


        }
    }
}