using System.Collections.Generic;

namespace Infrastructure.TaskServer
{
    public interface IRunnableTask
    {
        IList<string> Run();
    }
}