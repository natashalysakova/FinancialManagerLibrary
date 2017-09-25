using System;
using System.Runtime.Serialization;

namespace FinancialManagerLibrary.Wallets
{
    [Serializable]
    public class OverdraftLimitReachedException : Exception
    {
        public OverdraftLimitReachedException()
        {
        }

        public OverdraftLimitReachedException(double overdraftLimit, double usedOverdraft, double amount) : this(
            $"Not able to decrease balance because overdraft limit is reached. Limit='{overdraftLimit}' Used='{usedOverdraft}' Amount='{amount}'")
        {
        }

        public OverdraftLimitReachedException(string message) : base(message)
        {
        }

        public OverdraftLimitReachedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OverdraftLimitReachedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}