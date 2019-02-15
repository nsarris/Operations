using System;
using System.Linq;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Operations
{
    public static class ObservableExtensions
    {
        public static IObservable<T> WithConsoleLogAndTrace<T>(this IObservable<T> observable, string tag)
        {
            return observable.Do(
                onNext: x => Console.WriteLine($"[TRACE]{tag}, Value = {JsonConvert.SerializeObject(x is IResult result ? result.Value : x)}"),
                onError: ex => Console.WriteLine($"[LOG]{tag}, Exception = {ex.Message}"));
        }

        public static IObservable<T> Tap<T>(this IObservable<T> source, Action<T, int> selector)
        {
            return source.Select((x, i) => { selector(x, i); return x; });
        }

        public static IObservable<T> Tap<T>(this IObservable<T> source, Action<T> selector)
        {
            return source.Select((x) => { selector(x); return x; });
        }

        //Only if parallel?
        //public static IObservable<T> Tap<T>(this IObservable<T> source, IEnumerable<Action<T, int>> selectors)
        //{
        //    return source.Select((x, i) => { selector(x, i); return x; });
        //}

        //public static IObservable<T> Tap<T>(this IObservable<T> source, IEnumerable<Action<T>> selector)
        //{
        //    return source.Select((x) => { selector(x); return x; });
        //}

        public static IObservable<TSource> Tap<TSource>(this IObservable<TSource> source, Func<TSource, int, CancellationToken, Task> selector)
        {
            return source.SelectMany(async (x, i, token) => { await selector(x,i, token); return x; });
        }

        public static IObservable<TSource> Tap<TSource>(this IObservable<TSource> source, Func<TSource, CancellationToken, Task> selector)
        {
            return source.SelectMany(async (x, token) => { await selector(x, token); return x; });
        }

        public static IObservable<TSource> Tap<TSource>(this IObservable<TSource> source, Func<TSource, int, Task> selector)
        {
            return source.SelectMany(async (x,i) => { await selector(x, i); return x; });
        }

        public static IObservable<TSource> Tap<TSource>(this IObservable<TSource> source, Func<TSource, Task> selector)
        {
            return source.SelectMany(async x => { await selector(x); return x; });
        }

        //Needs all overloads from above
        public static IObservable<TSource> Tap<TSource>(this IObservable<TSource> source, IEnumerable<Func<TSource, Task>> selectors)
        {
            return source.SelectMany(async x => { await Task.WhenAll(selectors.Select(f => f(x))); return x; });
        }

        public static IObservable<T> Trace<T>(this IObservable<T> source, Action<T> handler)
        {
            return source.Do(handler);
        }

        public static IObservable<T> TraceSafe<T>(this IObservable<T> source, Action<T> handler)
        {
            try
            {
                return source.Do(handler);
            }
            catch
            {
                //swallow
                return source;
            }
        }

        public static IObservable<T> Log<T>(this IObservable<T> source, Action<Exception> handler)
        {
            return source.Do(_ => { }, handler);
        }

        public static IObservable<T> Log<T, TException>(this IObservable<T> source, Action<TException> handler)
            where TException : Exception
        {
            return source.Do(_ => { }, (Exception e) => { if (e is TException exception) handler(exception); });
        }
    }
}
