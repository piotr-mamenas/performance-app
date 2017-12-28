using System.ServiceProcess;

namespace Infrastructure.TaskServer
{
    public partial class TaskService : ServiceBase
    {
        public TaskService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var taskManager = new TaskManager();
            
            taskManager.Start();
        }

        protected override void OnStop()
        {
            //TODO: Disposal logic
        }
    }
}
