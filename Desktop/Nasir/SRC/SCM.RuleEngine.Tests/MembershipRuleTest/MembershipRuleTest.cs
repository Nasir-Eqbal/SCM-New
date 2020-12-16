using NSubstitute;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.RuleEngine.Tests.MembershipRuleTest
{
   public class MembershipRuleTest
    {
        [Fact]
        public void CheckPaymentForMembership_ActivateMember()
        {
            // Arrange
            
            var product = new Product() { Name = "site-member", ProductId = "mem-001", ProductPrice = 28.5f, ProducType = ProductTypes.NewMembership, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0003", CreatedDateTime = DateTime.UtcNow,ProductSelected = new List<Product>() { } };

            IPaymentService _pytmService = Substitute.For<IPaymentService>(); ;

            //Act

            var result = _pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);

        }

        [Fact]
        public void CheckPaymentForUpgradeMembership_ActivateMember()
        {
            // Arrange

            var product = new Product() { Name = "site-member", ProductId = "mem-001", ProductPrice = 28.5f, ProducType = ProductTypes.UpgradeMembership, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0003", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { } };

            IPaymentService _pytmService = Substitute.For<IPaymentService>(); ;

            //Act

            var result = _pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);

        }
    }
}
