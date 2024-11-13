using System.Diagnostics.CodeAnalysis;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            throw new InvalidOperationException();
        
        if (!isSuccess && error == Error.None)
            throw new InvalidOperationException();
        
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    
    public static Result<T> Success<T>(T value) => new(value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new(default!, false, error);
    
    public static Result<T> Create<T>(T value) => 
        value is not null ? Success(value) : Failure<T>(Error.NullValue);
}

public class Result<T> : Result
{
    private readonly T? _value;

    protected internal Result(T value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }
    
    public T? Value => IsSuccess ? _value : throw new InvalidOperationException("The value of failure result can not be accessed");
    
    public static implicit operator Result<T>(T value) => Create(value);
}