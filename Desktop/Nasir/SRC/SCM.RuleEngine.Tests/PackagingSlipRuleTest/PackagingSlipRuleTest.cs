using NSubstitute;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.RuleEngine.Tests.PackagingSlipRuleTest
{
   public class PackagingSlipRuleTest
    {
        
        [Fact]
        public void CheckPaymentForPhysicalProduct_TransactionStatusSuccess()
        {
            // Arrange
            var product = new Product() { Name="Cloths",ProductId="cl-001",ProducType=ProductTypes.PhysicalProduct,ProductPrice=25.5F};
            var order = new Order() { OrderId = "ord-0001", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
            
            IPaymentService _pytmService = Substitute.For<IPaymentService>(); ;

            //Act
            
            var result=_pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);

        }
        [Fact]
        public void CheckPaymentForPhysicalProduct_ThenGenerate_PackingSlip_ForShipping()
        {
            // Arrange
            var product = new Product() { Name = "Cloths", ProductId = "cl-001", ProducType = ProductTypes.PhysicalProduct, ProductPrice = 25.5F };
            var order = new Order() { OrderId = "ord-0001", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
           
            var customer = new Customer() { CustomerId = "00111", OrderId = "ord-0001", Address = new ShippingAddress() { City = "a", CustomeAddressLine1 = "B" } };
            IPackagingService _packgService = Substitute.For<IPackagingService>(); ;

            //Act

            var result = _packgService.GeneratePackaging(order, customer);
            //Assert
            Assert.True(result.IsSlipGenerated ==true);
            Assert.True(result.SlipType == PackingSlipType.SlipForShipping);

        }
        [Fact]
        public void CheckPaymentForBook_ThenGenerate_DuplicatePackingSlip_ForRoyality()
        {
            // Arrange
            var product = new Product() { Name = "My Book", ProductId = "cl-001", ProducType = ProductTypes.Books, ProductPrice = 25.5F };
            var order = new Order() { OrderId = "ord-0001", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };

            var customer = new Customer() { CustomerId = "00111", OrderId = "ord-0001", Address = new ShippingAddress() { City = "a", CustomeAddressLine1 = "B" } };
            IPackagingService _packgService = Substitute.For<IPackagingService>(); ;

            //Act

            var result = _packgService.GeneratePackaging(order, customer);
            //Assert
            Assert.True(result.IsSlipGenerated == true);
            Assert.True(result.SlipType == PackingSlipType.SlipForRoyalty);
        }
        

    }
}
