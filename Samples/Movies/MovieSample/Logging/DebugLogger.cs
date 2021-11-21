using System.Diagnostics;
using MovieSample;

namespace PaymentProcessing.Logging
{
    public class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}