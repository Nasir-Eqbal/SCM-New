using NSubstitute;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.RuleEngine.Tests.AgentComissionRuleTest
{
    public class AgentComissionRule
    {
        [Fact]
        public void CheckPaymentFor_PhysicalProduct_OR_Book_Then_GenerateComissionToAgent()
        {
            // Arrange

            var product = new Product() { Name = "Table Tenis", ProductId = "bb-001", ProductPrice = 28.5f, ProducType = ProductTypes.PhysicalProduct, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0008", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
            var agent = new Agent() { };
            var agent2 = new Agent() { };

            var product2 = new Product() { Name = "Lord Of King", ProductId = "bk-001", ProductPrice = 28.5f, ProducType = ProductTypes.Books, Quantity = 1 };
            var order2 = new Order() { OrderId = "ord-0008", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product2 } };

            IPaymentService _pytmService = Substitute.For<IPaymentService>(); ;

            //Act

            var result = _pytmService.GetPaymentDetails(order);
            var result2 = _pytmService.GetPaymentDetails(order2);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);
            Assert.True(result2.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);

           var comm= _pytmService.GenerateComissionToAgent(order, agent);
            var comm2= _pytmService.GenerateComissionToAgent(order, agent2);

            Assert.True(comm.IsSuccess);
            Assert.True(comm2.IsSuccess);


        }
    }
}
