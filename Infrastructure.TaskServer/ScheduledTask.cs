using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Infrastructure.TaskServer.Interfaces;

namespace Infrastructure.TaskServer
{
    public class ScheduledTask
    {
        public TaskStatus Status => _runningTask.Status;

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

        public async Task<IList<ValidationFailure>> Run()
        {
            var token = _tokenSource.Token;
            token.Register(Notify);

            _result = await Task.Factory.StartNew(() => _submittedTask.Run(token), token);

            return _result.Result;
        }

        public void Cancel()
        {
            _tokenSource.Cancel();
        }

        public void Notify()
        {
        }

        private readonly IRunnableTask _submittedTask;
        private readonly CancellationTokenSource _tokenSource;
        private Task _runningTask;
        private Task<IList<ValidationFailure>> _result;
    }
}
