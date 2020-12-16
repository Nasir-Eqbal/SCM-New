using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.RuleEngine.Core
{
    public class GenerateDuplicateSlipForRoyaltyDepartmentRule : IPaymentRule
    {
        private readonly IPackagingService _packgService;
        public GenerateDuplicateSlipForRoyaltyDepartmentRule(IPackagingService packgService)
        {
            _packgService = packgService;
        }
        public Task GetPaymentDetails(Order orderInfo)
        {
           
            throw new NotImplementedException();
        }

        public bool IsMatch()
        {
            throw new NotImplementedException();
        }

        private void GenerateDuplicatePackagingSlipForRoyalty(Order order, Customer cust)
        {
            _packgService.GeneratePackaging(order, cust);
        }
    }
}
