using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Service.Abstraction
{
    public interface INotificationService
    {
        bool Send(Customer cust);
    }
}
