using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Service.Abstraction
{
    public interface IMembershipService
    {
        Task UpdateMembership(Customer cust);
    }
}
