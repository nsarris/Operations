using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public interface IResult
    {
        object Value { get; }
        Exception Exception { get; }
    }
    public interface IResult<T> : IResult
    {
        T Value { get; }
    }

    public interface IVoidResult : IResult<Void>
    {
        
    }

    public class Result<T> : IResult<T>
    {
        object IResult.Value => Value;

        public Result(T value)
        {
            Value = value;
        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public T Value { get; }

        public Exception Exception { get; }
    }

    public class Result : IVoidResult
    {
        object IResult.Value => Value;

        public Void Value => Void.Value;

        public Exception Exception { get; }

        public Result()
        {

        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public static IResult<T> Success<T>(T result)
        {
            return new Result<T>(result);
        }

        public static IResult<T> Success<T>(IResult<T> result)
        {
            return new Result<T>(result.Value);
        }

        public static IVoidResult Success()
        {
            return new Result();
        }

        public static IVoidResult Fail(Exception e)
        {
            return new Result(e);
        }

        public static IResult<T> Fail<T>(Exception e)
        {
            return new Result<T>(e);
        }

        public async static Task<IResult<T>> FromInvocationAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return Success(await func());
            }
            catch (Exception e)
            {
                return Fail<T>(e);
            }
        }

        public async static Task<IResult<T>> FromInvocationAsync<T>(Func<T, Task> func, T flowthroughValue)
        {
            try
            {
                await func(flowthroughValue);
                return Success(flowthroughValue);
            }
            catch (Exception e)
            {
                return Fail<T>(e);
            }
        }

        public async static Task<IVoidResult> FromInvocationAsync(Func<Task> func)
        {
            try
            {
                await func();
                return Success();
            }
            catch (Exception e)
            {
                return Fail(e);
            }
        }

        public static IVoidResult FromInvocation(Action action)
        {
            try
            {
                action();
                return Success();
            }
            catch (Exception e)
            {
                return Fail(e);
            }
        }

        public static IResult<T> FromInvocation<T>(Action action, T flowthroughResult)
        {
            try
            {
                action();
                return Success(flowthroughResult);
            }
            catch (Exception e)
            {
                return Fail<T>(e);
            }
        }

        public static IResult<T> FromInvocation<T>(Func<T> func)
        {
            try
            {
                return Success(func());
            }
            catch (Exception e)
            {
                return Fail<T>(e);
            }
        }

        public static IResult<T> FromInvocation<T>(Action<T> func, T flowthroughValue)
        {
            try
            {
                func(flowthroughValue);
                return Result.Success(flowthroughValue);
            }
            catch (Exception e)
            {
                return Result.Fail<T>(e);
            }
        }
    }
}
