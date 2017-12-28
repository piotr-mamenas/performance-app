using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Infrastructure.TaskServer.Interfaces
{
    public interface IRunnableTask
    {
        int Id { get; set; }
        Task<IList<ValidationFailure>> Run(CancellationToken cancellationToken);
    }
}