using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Tests.Core.Fakes;
using System.Linq;

namespace Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class StorageReaderTests
    {
        [TestMethod]
        public void Read_WithALine_ShouldReturnOneOrder()
        {
            //Arrange
            var filePath = string.Empty;
            var storageReader = new StorageReaderFakeWithALine(filePath);

            //Act
            var orders = storageReader.Read();

            //Assert
            orders.First().OrderId.Should().Be(1);
            orders.First().DealId.Should().Be(1);
            orders.First().Email.Should().Be("bugs@bunny.com");
            orders.First().Street.Should().Be("123 sesame st.");
            orders.First().City.Should().Be("new york");
            orders.First().State.Should().Be("ny");
            orders.First().ZipCode.Should().Be("10011");
            orders.First().CreditCard.Should().Be("12345689010");
        }

        [TestMethod]
        public void Read_WithoutLines_ShouldReturnOneOrder()
        {
            //Arrange
            var filePath = string.Empty;
            var storageReader = new StorageReaderFakeWithoutLines(filePath);

            //Act
            var orders = storageReader.Read();

            //Assert
            orders.Should().BeEmpty();
        }

        [TestMethod]
        public void Read_WithNull_ShouldReturnOneOrder()
        {
            //Arrange
            var filePath = string.Empty;
            var storageReader = new StorageReaderFakeNull(filePath);

            //Act
            var orders = storageReader.Read();

            //Assert
            orders.Should().BeEmpty();
        }

    }
}