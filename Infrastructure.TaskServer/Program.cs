using System.ServiceProcess;

namespace Infrastructure.TaskServer
{
    internal static class Program
    {
        private static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new TaskService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
