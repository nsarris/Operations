using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp12
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

        public static IOperation<T> Create<T>(Action func, T returnValue)
        {
            return new Operation<T>(() => { func(); return returnValue; });
        }

        public static IOperation<T> Create<T>(Func<Task> func, T returnValue)
        {
            return new Operation<T>(async () => { await func(); return returnValue; });
        }
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
