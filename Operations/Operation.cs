using Operations;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Operations
{
    public interface IOperation<out T>
    {
        IObservable<T> AsObservable();
    }

    public static class Operation
    {
        public static IOperation<T> Create<T>(Func<T> func)
        {
            return new Operation<T>(func);
        }

        public static IOperation<T> Create<T>(Func<Task<T>> func)
        {
            return new Operation<T>(func);
        }

        
        public static IOperation<T> Create<T>(Action func, T flowthroughValue)
        {
            return new Operation<T>(() => { func(); return flowthroughValue; });
        }

        public static IOperation<T> Create<T>(Func<Task> func, T flowthroughValue)
        {
            return new Operation<T>(async () => { await func(); return flowthroughValue; });
        }

        public static IOperation<Void> Create(Func<Task> func)
        {
            return new Operation<Void>(async () => { await func(); return Void.Value; });
        }

        public static IOperation<T> Create<T>(Action<T> func, T flowthroughValue)
        {
            return new Operation<T>(() => { func(flowthroughValue); return flowthroughValue; });
        }

        public static IOperation<T> Create<T>(Func<T, Task> func, T flowthroughValue)
        {
            return new Operation<T>(async () => { await func(flowthroughValue); return flowthroughValue; });
        }



        public static IOperation<IResult<T>> CreateResult<T>(Func<Task<T>> func)
            => Create(async () => await Result.FromInvocationAsync(func));

        public static IOperation<IVoidResult> CreateResult(Func<Task> func)
            => Create(async () => await Result.FromInvocationAsync(func));

        public static IOperation<IResult<T>> CreateResult<T>(Func<T, Task> func, T flowthroughValue)
            => Create(async () => await Result.FromInvocationAsync(func, flowthroughValue));
        
        public static IOperation<IResult<T>> CreateResult<T>(Func<T> func)
            => Create(() => Result.FromInvocation(func));

        public static IOperation<IVoidResult> CreateResult(Action action)
            => Create(() => Result.FromInvocation(action));

        public static IOperation<IResult<T>> CreateResult<T>(Action action, T flowthroughValue)
            => Create(() => Result.FromInvocation(action, flowthroughValue));

        public static IOperation<IResult<T>> CreateResult<T>(Action<T> func, T flowthroughValue)
            => Create(() => Result.FromInvocation(func, flowthroughValue));
    }


    public class Operation<T> : IOperation<T>
    {
        private readonly IObservable<T> observable;

        public IObservable<T> AsObservable() => observable;

        internal Operation(IObservable<T> observable)
        {
            this.observable = observable;
        }

        public Operation(Func<T> func)
        {
            observable = Observable.Start(func);
        }

        public Operation(Func<Task<T>> func)
        {
            observable = Observable.FromAsync(func);
        }

        public Task<T> ExecuteAsync()
        {
            return ExecuteAsync(CancellationToken.None);
        }

        public async Task<T> ExecuteAsync(CancellationToken cancellationToken)
        {
            return await observable.RunAsync(cancellationToken);
        }
    }
}
