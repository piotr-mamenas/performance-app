namespace Infrastructure.TaskServer
{
    public enum TechnicalTaskStatus
    {
        Submitted = 1,
        Starting = 2,
        Running = 3,
        Validating = 4,
        Finished = 5,
        Cancelled = 6
    }
}