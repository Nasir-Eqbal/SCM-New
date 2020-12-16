using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.RuleEngine.Core
{
    public interface IPaymentRule
    {
        Task GetPaymentDetails(Order orderInfo);
        bool IsMatch();
    }
}
