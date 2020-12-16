using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.RuleEngine.Domain
{
    public static class TransactionStatusConstant
    {
        public const string TransactionStatusCompleted = "transaction-completed";
        public const string TransactionStatusInitiated = "transaction-initiated";
        public const string TransactionStatusFailed = "transaction-failed";
    }
}
