using System;

namespace Operations
{
    public interface IRetryStrategy
    {
        IObservable<T> Apply<T>(IObservable<T> source);
    }
}
