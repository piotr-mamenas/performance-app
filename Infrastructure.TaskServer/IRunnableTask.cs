using System.Collections.Generic;
using System.Threading;

namespace Infrastructure.TaskServer
{
    public interface IRunnableTask
    {
        int Id { get; set; }
        IList<string> Run(CancellationToken cancellationToken);
    }
}