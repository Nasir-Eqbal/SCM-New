using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.RuleEngine.Core
{
    public interface IPaymentRuleEvaluator
    {
        Task<bool> EvaluateRule(Order order);
    }
}
