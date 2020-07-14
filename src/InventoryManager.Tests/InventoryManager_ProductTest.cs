using System;
using Xunit;
using InventoryManager.Models;

namespace InventoryManager.Tests
{
    public class ProductTest
    {
        [Fact]
        public void Should_Have_Name()
        {
            var productName = "Komputer HP";
            var product = new Product
            {
                Name = productName
            };

            Assert.Equal(productName, product.Name);
        }

        [Fact]
        public void Should_Have_Wrong_Name()
        {
            var productName = "Komputer HP";
            var wrongProductName = "Komputer XD";
            var product = new Product
            {
                Name = productName
            };

            Assert.NotEqual(product.Name, wrongProductName);
        }
    }
}
