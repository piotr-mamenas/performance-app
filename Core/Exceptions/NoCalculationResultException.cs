using System;

namespace Core.Exceptions
{
    public class NoCalculationResultException : Exception
    {
        public NoCalculationResultException()
        {
            
        }

        public NoCalculationResultException(string message)
            : base($"No Calculation Result: {message}")
        {
        }
    }
}
