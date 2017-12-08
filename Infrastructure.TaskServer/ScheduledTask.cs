using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.TaskServer
{
    public class ScheduledTask
    {
        public TechnicalTaskStatus Status { get; set; }   
        public int TaskId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="submittedTask"></param>
        public ScheduledTask(IRunnableTask submittedTask)
        {
            _submittedTask = submittedTask;
            TaskId = submittedTask.Id;
            _tokenSource = new CancellationTokenSource();
        }

        public void Run()
        {
            var token = _tokenSource.Token;

            Task.Factory.StartNew(() => _submittedTask.Run(token), token);

            token.Register(Notify);
        }

        public void Cancel()
        {
            _tokenSource.Cancel();
        }

        public void Notify()
        {
            // add event handling here
        }

        private readonly IRunnableTask _submittedTask;
        private readonly CancellationTokenSource _tokenSource;
    }
}
