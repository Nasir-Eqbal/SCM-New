using NSubstitute;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.RuleEngine.Tests.VideoRuleTest
{
    public class VideoLibraryRuleTest
    {
        [Fact]
        public void CheckPaymentFoVideo_LearningtoSki_AddFree_FirstAidVideo()
        {
            // Arrange

            var product = new Product() { Name = "Lerning To Ski", ProductId = "vid-001", ProductPrice = 28.5f, ProducType = ProductTypes.Videos, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0066", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
            var freeproduct = new Product() { Name = "First Aid", ProductId = "prd-001", ProductPrice = 28.5f, ProducType = ProductTypes.Videos, Quantity = 1 };

            IPaymentService _pytmService = Substitute.For<IPaymentService>(); 
            IPackagingService _pkgService = Substitute.For<IPackagingService>(); 
            //Act

            var result = _pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);
            var newOrder = _pkgService.AddFreeComplmentryProduct(order);
            var addedProduct = newOrder.ProductSelected.Find(x => x.ProductId == "prd-001");
            Assert.Equal(freeproduct.ProductId, addedProduct.ProductId);
            


        }
    }
}
