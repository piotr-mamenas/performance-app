namespace Infrastructure.TaskServer
{
    public interface ICancellableTask
    {
        int Id { get; set; }
        void Cancel();
    }
}