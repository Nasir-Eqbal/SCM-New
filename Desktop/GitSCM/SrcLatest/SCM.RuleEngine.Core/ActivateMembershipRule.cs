using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.RuleEngine.Core
{
    public class ActivateMembershipRule : IPaymentRule
    {
        private readonly IMembershipService _membership;
        public ActivateMembershipRule(IMembershipService membership)
        {
            _membership = membership;
        }
        public Task GetPaymentDetails(Order orderInfo)
        {
            throw new NotImplementedException();
        }

        public bool IsMatch()
        {
            throw new NotImplementedException();
        }

        private void ActivateMembershipForCustomer(Customer cust)
        {
            _membership.UpdateMembership(cust);

        }
    }
}
