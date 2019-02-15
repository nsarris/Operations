using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public interface IResult<T>
    {
        T Value { get; }

        Exception Exception { get; }
    }

    public class Result<T> : IResult<T>
    {
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

    public class Result : IResult<Void>
    {
        public Void Value => Void.Value;

        public Exception Exception { get; }

        public Result()
        {

        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public static Result<T> Success<T>(T result)
        {
            return new Result<T>(result);
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Fail(Exception e)
        {
            return new Result(e);
        }

        public static Result<T> Fail<T>(Exception e)
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
