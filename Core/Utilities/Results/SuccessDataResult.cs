using Core.Entities;

namespace Core.Utilities.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data, string message, bool success) : base(data, message, true)
    {
    }

    public SuccessDataResult(T data, bool success) : base(data, true)
    {
    }
    
    public SuccessDataResult(string message) : base(success: true, message: message, data: default)
    {
    }
    
    public SuccessDataResult() : base(success: true, message: default, data: default)
    {
    }
}