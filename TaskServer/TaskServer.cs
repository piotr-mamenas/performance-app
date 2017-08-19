using System.ServiceProcess;

namespace TaskServer
{
    public partial class TaskServer : ServiceBase
    {
        public TaskServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
