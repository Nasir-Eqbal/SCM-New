using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.RuleEngine.Core
{
    public class PaymentRuleEvaluator : IPaymentRuleEvaluator
    {
        List<IPaymentRule> _rules = new List<IPaymentRule>();
        private readonly IPaymentService _paymentService;
        private readonly IPackagingService _packService;
        private readonly INotificationService _notfyService;
        private readonly IMembershipService _membershipService;

        public PaymentRuleEvaluator(IPaymentService paymentService, IPackagingService packService, INotificationService notfyService, IMembershipService membershipService)
        {
            _paymentService = paymentService;
            _packService = packService;
            _notfyService = notfyService;
            _membershipService = membershipService;
            _rules.Add(new GeneratePackagingSlipRule(_packService));
            _rules.Add(new GenerateDuplicateSlipForRoyaltyDepartmentRule(_packService));
            _rules.Add(new ActivateMembershipRule(_membershipService));
        }
        public Task<bool> EvaluateRule(Order order)
        {
            foreach (var rule in _rules)
            {
                if(rule.IsMatch())
                {
                    Task.Run(()=> rule.GetPaymentDetails(order));
                }
            }

            return Task.FromResult(true);
        }
    }
}
