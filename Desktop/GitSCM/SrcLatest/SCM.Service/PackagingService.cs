using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Service
{
  public  class PackagingService : IPackagingService
    {
        public Order AddFreeComplmentryProduct(Order order)
        {
            throw new NotImplementedException();
        }

        public PackagingSlipGenerationResponse GeneratePackaging(Order order, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
