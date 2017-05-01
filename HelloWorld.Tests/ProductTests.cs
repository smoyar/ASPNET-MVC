using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Moq;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(() =>
                {
                    return new Product[]{
                new Product{Name="Baseball", Price=5 },
                new Product{Name="Football", Price=10 },
                new Product {Name="Tennis", Price=18 }
                    };
                });

            // Arrange. Call data in repository
            var controller = new HomeController(mockProductRepository.Object);

            // Act. Take the data
            var result = controller.Products();

            // Assert. Checking if the data meets requirement
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(3, products.Length, "Length is invalid");

            Assert.AreEqual(2, products.Where(t=> t.Price < 10).Count(), "Number of cheap products incorrect" );
            Assert.AreEqual(2, products.Where(t => t.Price >= 10).Count(), "Number of expensive products incorrect" );
        }
    }
}