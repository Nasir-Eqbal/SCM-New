using SCM.RuleEngine.Domain;
using System;

namespace SCM.Service.Abstraction
{
    public interface IPaymentService
    {
        public PaymentResponse GetPaymentDetails(Order order);
        public AgentComissionResponse GenerateComissionToAgent(Order order, Agent agent);
    }
}
