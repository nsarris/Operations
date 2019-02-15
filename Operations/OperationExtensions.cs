using Newtonsoft.Json;
using System;
using System.Reactive.Joins;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Operations
{
    public static class OperationExtensions
    {
        public static IOperation<T> WithConsoleLogAndTrace<T>(this IOperation<T> opeartion, string tag)
        {
            return new Operation<T>(opeartion.AsObservable().Do(
                onNext: x => Console.WriteLine($"[TRACE]{tag}, Value = {JsonConvert.SerializeObject(x is IResult result ? result.Value : x)}"),
                onError: ex => Console.WriteLine($"[LOG]{tag}, Exception = {ex.Message}")));
        }

        public static OperationConcatenator<T1, T2> And<T1, T2>(this IOperation<T1> source, IOperation<T2> operation)
        {
            return new OperationConcatenator<T1, T2>(source, operation);
        }

        public static IOperation<TResult> Select<TSource, TResult>(this IOperation<TSource> source, Func<TSource, int, TResult> selector)
        {
            return new Operation<TResult>(source.AsObservable().Select(selector));
        }

        public static IOperation<TResult> Select<TSource, TResult>(this IOperation<TSource> source, Func<TSource, TResult> selector)
        {
            return new Operation<TResult>(source.AsObservable().Select(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Action<T, int> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Action<T> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, int, TResult> selector)
        {
            return new Operation<TResult>(source.AsObservable().Select(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, TResult> selector)
        {
            return new Operation<TResult>(source.AsObservable().Select(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Func<T, int, CancellationToken, Task> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Func<T, CancellationToken, Task> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Func<T, int, Task> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<T> ContinueWith<T>(this IOperation<T> source, Func<T, Task> selector)
        {
            return new Operation<T>(source.AsObservable().Tap(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, int, CancellationToken, Task<TResult>> selector)
        {
            return new Operation<TResult>(source.AsObservable().SelectMany(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, CancellationToken, Task<TResult>> selector)
        {
            return new Operation<TResult>(source.AsObservable().SelectMany(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, int, Task<TResult>> selector)
        {
            return new Operation<TResult>(source.AsObservable().SelectMany(selector));
        }

        public static IOperation<TResult> ContinueWith<TSource, TResult>(this IOperation<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            return new Operation<TResult>(source.AsObservable().SelectMany(selector));
        }




        #region Result continuations

        public static IOperation<IResult<T>> ContinueWith<T>(this IOperation<IResult<T>> source, Action<T> selector)
        {
            return new Operation<IResult<T>>(source.AsObservable().Tap(x => Operation.CreateResult(selector, x.Value)));
        }

        public static IOperation<IResult<T>> ContinueWith<T>(this IOperation<IResult<T>> source, Action selector)
        {
            return new Operation<IResult<T>>(source.AsObservable().Tap(x => Operation.CreateResult(selector, x.Value)));
        }

        public static IOperation<IResult<T>> ContinueWith<T>(this IOperation<IResult<T>> source, Func<T, Task> selector)
        {
            return new Operation<IResult<T>>(source.AsObservable().Tap(x => Operation.CreateResult(selector, x.Value)));
        }

        public static IOperation<IResult<TResult>> Select<TSource, TResult>(this IOperation<IResult<TSource>> source, Func<TSource, TResult> selector)
        {
            return new Operation<IResult<TResult>>(source.AsObservable().Select(x => Result.FromInvocation(() => selector(x.Value))));
        }

        #endregion


        public static IOperation<T> Trace<T>(this IOperation<T> source, Action<T> handler)
        {
            return new Operation<T>(source.AsObservable().Do(handler));
        }

        public static IOperation<T> TraceSafe<T>(this IOperation<T> source, Action<T> handler)
        {
            try
            {
                return new Operation<T>(source.AsObservable().Do(handler));
            }
            catch
            {
                //swallow
                return source;
            }
        }

        public static IOperation<T> Log<T>(this IOperation<T> source, Action<Exception> handler)
        {
            return new Operation<T>(source.AsObservable().Log(handler));
        }

        public static IOperation<T> Log<T, TException>(this IOperation<T> source, Action<TException> handler)
            where TException : Exception
        {
            return new Operation<T>(source.AsObservable().Log(handler));
        }

        public static IOperation<TSource> Catch<TSource, TException>(this IOperation<TSource> source, Func<TException, IObservable<TSource>> handler) 
            where TException : Exception
        {
            return new Operation<TSource>(source.AsObservable().Catch(handler));
        }

        public static IOperation<IVoidResult> Catch<TException>(this IOperation<IVoidResult> source, Func<TException, IVoidResult> handler)
            where TException : Exception
        {
            return new Operation<IVoidResult>(
                source.AsObservable().Catch((TException e) => Observable.Return(handler(e))));
        }

        public static IOperation<IResult<TSource>> Catch<TSource, TException>(this IOperation<IResult<TSource>> source, Func<TException, IResult<TSource>> handler)
            where TException : Exception
        {
            return new Operation<IResult<TSource>>(
                source.AsObservable().Catch((TException e) => Observable.Return(handler(e))));
        }

        public static Task<T> ExecuteAsync<T>(this IOperation<T> operation)
        {
            return ((Operation<T>)operation).ExecuteAsync();
        }
        public static Task<T> ExecuteAsync<T>(this IOperation<T> operation, CancellationToken cancellationToken)
        {
            return ((Operation<T>)operation).ExecuteAsync(cancellationToken);
        }
    }
}
