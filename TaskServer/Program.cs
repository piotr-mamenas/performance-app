using System.ServiceProcess;

namespace TaskServer
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new TaskServer()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
