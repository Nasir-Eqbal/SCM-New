using NSubstitute;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SCM.RuleEngine.Tests.EmailNotificationTest
{
    public class SendEmailNotification
    {
        [Fact]
        public void CheckPaymentForNewMembership_SendEmailNotificationForActivation()
        {
            // Arrange

            var product = new Product() { Name = "site-member", ProductId = "mem-001", ProductPrice = 28.5f, ProducType = ProductTypes.NewMembership, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0003", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
            var cust = new Customer() { CustomerId = "cst-007", OrderId = "ord-0003", EmailId = "test@yahoo.com", Address = new ShippingAddress() { } ,IsNewCustomer= true};

            IPaymentService _pytmService = Substitute.For<IPaymentService>(); 
            INotificationService _notifySvc = Substitute.For<INotificationService>();

            //Act

            var result = _pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);
            var notify = _notifySvc.Send(cust);
            Assert.True(notify);

        }

        [Fact]
        public void CheckPaymentFoUpgradeMembership_SendEmailNotificationForUpgrade()
        {
            var product = new Product() { Name = "site-member", ProductId = "mem-001", ProductPrice = 28.5f, ProducType = ProductTypes.UpgradeMembership, Quantity = 1 };
            var order = new Order() { OrderId = "ord-0004", CreatedDateTime = DateTime.UtcNow, ProductSelected = new List<Product>() { product } };
            var cust = new Customer() { CustomerId = "cst-008", OrderId = "ord-0004", EmailId = "test@yahoo.com", Address = new ShippingAddress() { } ,IsNewCustomer=false};

            IPaymentService _pytmService = Substitute.For<IPaymentService>();
            INotificationService _notifySvc = Substitute.For<INotificationService>();

            //Act

            var result = _pytmService.GetPaymentDetails(order);
            //Assert
            Assert.True(result.TransactionStatus == TransactionStatusConstant.TransactionStatusCompleted);
            var notify = _notifySvc.Send(cust);
            Assert.True(notify);

        }
    }
}
