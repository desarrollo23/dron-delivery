using DronDelivery.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DronDelivery.Infraestructure.Delivery;
using DronDelivery.Domain.Model.Delivery;
using System.Linq;
using System.IO;

namespace DronDelivery.Test
{
    [TestClass]
    public class DronDeliveryTest
    {
        [TestMethod]
        public void ValidateRightDronMovements()
        {
            // Arrange
            var dron = new Dron { Id = 1 };
            var commands = new string[] { "AAAAIAA", "AIIAADA", "IDDADAA" };

            string[] result = { "(-2, 4) dirección WEST", "(-1, 3) dirección SOUTH", "(-2, 5) dirección NORTH" };
            int cont = 0;

            var service = new DronHandler();

            // Act
            var movements = service.Movements(commands, dron);

            // Assert
            movements.ToList().ForEach(movement =>
            {
                Assert.AreEqual(result[cont], movement);
                cont++;
            });
        }

        [TestMethod]
        public void ThrowDirectoryNotFoundException()
        {
            // Arrange
            string path = "C:\\Users\\andres.duarte\\source\\repos\\dron-delivery\\DronDelivery.Infraestructure\\FilesTest";

            string fileNotFoundMessage = @"Could not find a part of the path 'C:\Users\andres.duarte\source\repos\dron-delivery\DronDelivery.Infraestructure\FilesTest'.";

            var service = new FileDronDelivery();
            service.SetParameters(path);

            try
            {
                // Act
                string[] files = service.GetFiles();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(DirectoryNotFoundException));
                var excepcion = (ex as DirectoryNotFoundException);
                Assert.AreEqual(excepcion.Message, fileNotFoundMessage);
            }

        }
    }
}
