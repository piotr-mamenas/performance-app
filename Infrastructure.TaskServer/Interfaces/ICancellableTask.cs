namespace Infrastructure.TaskServer.Interfaces
{
    public interface ICancellableTask
    {
        int Id { get; set; }
        void Cancel();
    }
}