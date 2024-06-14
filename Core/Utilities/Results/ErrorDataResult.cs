namespace Core.Utilities.Results;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string message, bool success) : base(data, message, false)
    {
    }

    public ErrorDataResult(T data, bool success) : base(data, false)
    {
    }
    
    
    public ErrorDataResult(string message) : base(default, message, false)
    {
    }

    public ErrorDataResult() : base(default, false)
    {
    }
}