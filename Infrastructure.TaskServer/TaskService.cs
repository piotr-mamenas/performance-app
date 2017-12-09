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
            // single core for now
            var taskManager = new TaskManager();

            while (true)
            {
                taskManager.RunNext();
                // TODO: need to add logic to fetch task from db
            }
        }

        protected override void OnStop()
        {
            //TODO: Disposal logic
        }
    }
}
