using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobacionCredito.Tests
{
    [TestClass()]
    public class EntidadCrediticiaTests
    {
        [TestMethod()]
        public void ObtieneResultadoValidacionTest()
        {
            //Arrange
            Cliente[] pruebaClientes =
            {
                new Cliente() {Nombre = "Misty", PuntajeDataCredito = 100, ValorPrestamo = 20000},
                new Cliente() {Nombre = "Donn", PuntajeDataCredito = 76, ValorPrestamo = 20000},
                new Cliente() {Nombre = "Brook", PuntajeDataCredito = 73, ValorPrestamo = 20000}
            };

            //Act
            int aprobadosEnA = 1;
            int eaprobadosEnB = 2;

            //Assert
            Assert.AreEqual(aprobadosEnA, eaprobadosEnB);


        }


      


    }
    
}