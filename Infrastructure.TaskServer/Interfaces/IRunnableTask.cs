using System.Collections.Generic;
using System.Threading;

namespace Infrastructure.TaskServer.Interfaces
{
    public interface IRunnableTask
    {
        int Id { get; set; }
        IList<string> Run(CancellationToken cancellationToken);
    }
}