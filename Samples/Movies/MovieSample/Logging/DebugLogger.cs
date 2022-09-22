using System.Diagnostics;

namespace MovieSample.Logging
{
    public class DebugLogger : ILogger
    {
        public DebugLogger()
        {
        }

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}