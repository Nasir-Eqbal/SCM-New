using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Service.Abstraction
{
    public interface IPackagingService
    {
        public PackagingSlipGenerationResponse GeneratePackaging(Order order, Customer customer);
        public Order AddFreeComplmentryProduct(Order order);
    }
}
