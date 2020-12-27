namespace ScrumTaskBoardXP.Business.Results
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
