using System;
using System.Reactive.Linq;

namespace Operations
{
    public class ExponentialBackoffRetryStrategy : IRetryStrategy
    {
        private readonly int exponentBase;
        private readonly int maxRetries;
        private readonly Action<Exception, int> onError;

        public ExponentialBackoffRetryStrategy(int exponentBase, int maxRetries, Action<Exception,int> onError = null)
        {
            this.exponentBase = exponentBase;
            this.maxRetries = maxRetries;
            this.onError = onError;
        }

        public IObservable<T> Apply<T>(IObservable<T> source)
        {
            return source.RetryWhen(error =>
                error.Zip(Observable.Range(1, maxRetries), (exception, index) => { OnError(exception, index); return index; })
                .SelectMany(retryCount => Observable.Timer(TimeSpan.FromSeconds(Math.Pow(exponentBase, retryCount)))));
        }

        private void OnError(Exception exception, int index)
        {
            try
            {
                onError?.Invoke(exception, index);
            }
            catch
            {
                //Swallow
            }
        }
    }
}
