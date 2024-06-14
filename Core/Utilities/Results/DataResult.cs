using Core.Entities;

namespace Core.Utilities.Results;

public class DataResult<T> : IDataResult<T> 
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public DataResult(T data,string message,bool success): this(data,success)
    {
        Message = message;
    }
    
    public DataResult(T data,bool success)
    {
        Success = success;
        Data = data;
    }
    
}