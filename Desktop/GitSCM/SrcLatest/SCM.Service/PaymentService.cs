using SCM.RuleEngine.Domain;
using SCM.Service.Abstraction;
using System;

namespace SCM.Service
{
    public class PaymentService : IPaymentService
    {
        public AgentComissionResponse GenerateComissionToAgent(Order order, Agent agent)
        {
            throw new NotImplementedException();
        }

        public PaymentResponse GetPaymentDetails(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
