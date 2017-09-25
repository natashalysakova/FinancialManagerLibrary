using System;
using System.Runtime.Serialization;

namespace FinancialManagerLibrary.Exceptions
{
    [Serializable]
    public class LimitReachedException : Exception
    {
        public LimitReachedException()
        {
        }

        public LimitReachedException(double balance, double amount) : this(
            $"Not able to decrease balance because limit is reached. Balance='{balance}' Amount='{amount}'")
        {
        }

        public LimitReachedException(string message) : base(message)
        {
        }

        public LimitReachedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LimitReachedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}