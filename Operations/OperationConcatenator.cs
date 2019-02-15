using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace Operations
{
	public sealed class OperationConcatenator<T1, T2>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
				operation2.AsObservable())
				.Then((T1 result1, T2 result2) => selector(result1, result2))))
			;
		}

		public IOperation<(T1, T2)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2)>(Observable.When(
				operation1.AsObservable().And(
				operation2.AsObservable())
				.Then((T1 result1, T2 result2) => (result1, result2))))
			;
		}

        public OperationConcatenator<T1, T2, T3> And<T3>(IOperation<T3> next)
        {
            return new OperationConcatenator<T1, T2, T3>(operation1, operation2, next);
        }

		public OperationConcatenator<T1, T2, T3> And<T3>(Func<T3> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3> And<T3>(Func<Task<T3>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
				operation3.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3) => selector(result1, result2, result3))))
			;
		}

		public IOperation<(T1, T2, T3)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
				operation3.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3) => (result1, result2, result3))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4> And<T4>(IOperation<T4> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4>(operation1, operation2, operation3, next);
        }

		public OperationConcatenator<T1, T2, T3, T4> And<T4>(Func<T4> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4> And<T4>(Func<Task<T4>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
				operation4.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4) => selector(result1, result2, result3, result4))))
			;
		}

		public IOperation<(T1, T2, T3, T4)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
				operation4.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4) => (result1, result2, result3, result4))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5> And<T5>(IOperation<T5> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5>(operation1, operation2, operation3, operation4, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5> And<T5>(Func<T5> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5> And<T5>(Func<Task<T5>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
				operation5.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5) => selector(result1, result2, result3, result4, result5))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
				operation5.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5) => (result1, result2, result3, result4, result5))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6> And<T6>(IOperation<T6> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6>(operation1, operation2, operation3, operation4, operation5, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6> And<T6>(Func<T6> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6> And<T6>(Func<Task<T6>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
				operation6.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6) => selector(result1, result2, result3, result4, result5, result6))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
				operation6.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6) => (result1, result2, result3, result4, result5, result6))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7> And<T7>(IOperation<T7> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7>(operation1, operation2, operation3, operation4, operation5, operation6, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7> And<T7>(Func<T7> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7> And<T7>(Func<Task<T7>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
				operation7.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7) => selector(result1, result2, result3, result4, result5, result6, result7))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
				operation7.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7) => (result1, result2, result3, result4, result5, result6, result7))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8> And<T8>(IOperation<T8> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8> And<T8>(Func<T8> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8> And<T8>(Func<Task<T8>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
				operation8.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8) => selector(result1, result2, result3, result4, result5, result6, result7, result8))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
				operation8.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8) => (result1, result2, result3, result4, result5, result6, result7, result8))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9> And<T9>(IOperation<T9> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9> And<T9>(Func<T9> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9> And<T9>(Func<Task<T9>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
				operation9.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
				operation9.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9) => (result1, result2, result3, result4, result5, result6, result7, result8, result9))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> And<T10>(IOperation<T10> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> And<T10>(Func<T10> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> And<T10>(Func<Task<T10>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
				operation10.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
				operation10.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> And<T11>(IOperation<T11> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, operation10, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> And<T11>(Func<T11> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> And<T11>(Func<Task<T11>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
				operation11.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
				operation11.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> And<T12>(IOperation<T12> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, operation10, operation11, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> And<T12>(Func<T12> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> And<T12>(Func<Task<T12>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;
        private readonly IOperation<T12> operation12;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11, IOperation<T12> operation12)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        this.operation12 = operation12;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
				operation12.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
				operation12.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> And<T13>(IOperation<T13> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, operation10, operation11, operation12, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> And<T13>(Func<T13> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> And<T13>(Func<Task<T13>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;
        private readonly IOperation<T12> operation12;
        private readonly IOperation<T13> operation13;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11, IOperation<T12> operation12, IOperation<T13> operation13)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        this.operation12 = operation12;
        this.operation13 = operation13;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
				operation13.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
				operation13.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> And<T14>(IOperation<T14> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, operation10, operation11, operation12, operation13, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> And<T14>(Func<T14> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> And<T14>(Func<Task<T14>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;
        private readonly IOperation<T12> operation12;
        private readonly IOperation<T13> operation13;
        private readonly IOperation<T14> operation14;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11, IOperation<T12> operation12, IOperation<T13> operation13, IOperation<T14> operation14)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        this.operation12 = operation12;
        this.operation13 = operation13;
        this.operation14 = operation14;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
				operation14.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
				operation14.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14))))
			;
		}

        public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> And<T15>(IOperation<T15> next)
        {
            return new OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(operation1, operation2, operation3, operation4, operation5, operation6, operation7, operation8, operation9, operation10, operation11, operation12, operation13, operation14, next);
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> And<T15>(Func<T15> next)
        {
            return And(Operation.Create(next));
        }

		public OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> And<T15>(Func<Task<T15>> next)
        {
            return And(Operation.Create(next));
        }
    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;
        private readonly IOperation<T12> operation12;
        private readonly IOperation<T13> operation13;
        private readonly IOperation<T14> operation14;
        private readonly IOperation<T15> operation15;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11, IOperation<T12> operation12, IOperation<T13> operation13, IOperation<T14> operation14, IOperation<T15> operation15)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        this.operation12 = operation12;
        this.operation13 = operation13;
        this.operation14 = operation14;
        this.operation15 = operation15;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
			
				operation14.AsObservable()).And(
				operation15.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14, T15 result15) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
			
				operation14.AsObservable()).And(
				operation15.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14, T15 result15) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15))))
			;
		}

    }
	public sealed class OperationConcatenator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        private readonly IOperation<T1> operation1;
        private readonly IOperation<T2> operation2;
        private readonly IOperation<T3> operation3;
        private readonly IOperation<T4> operation4;
        private readonly IOperation<T5> operation5;
        private readonly IOperation<T6> operation6;
        private readonly IOperation<T7> operation7;
        private readonly IOperation<T8> operation8;
        private readonly IOperation<T9> operation9;
        private readonly IOperation<T10> operation10;
        private readonly IOperation<T11> operation11;
        private readonly IOperation<T12> operation12;
        private readonly IOperation<T13> operation13;
        private readonly IOperation<T14> operation14;
        private readonly IOperation<T15> operation15;
        private readonly IOperation<T16> operation16;

        internal OperationConcatenator(IOperation<T1> operation1, IOperation<T2> operation2, IOperation<T3> operation3, IOperation<T4> operation4, IOperation<T5> operation5, IOperation<T6> operation6, IOperation<T7> operation7, IOperation<T8> operation8, IOperation<T9> operation9, IOperation<T10> operation10, IOperation<T11> operation11, IOperation<T12> operation12, IOperation<T13> operation13, IOperation<T14> operation14, IOperation<T15> operation15, IOperation<T16> operation16)
        {
        this.operation1 = operation1;
        this.operation2 = operation2;
        this.operation3 = operation3;
        this.operation4 = operation4;
        this.operation5 = operation5;
        this.operation6 = operation6;
        this.operation7 = operation7;
        this.operation8 = operation8;
        this.operation9 = operation9;
        this.operation10 = operation10;
        this.operation11 = operation11;
        this.operation12 = operation12;
        this.operation13 = operation13;
        this.operation14 = operation14;
        this.operation15 = operation15;
        this.operation16 = operation16;
        }

		public IOperation<T> Select<T>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> selector)
		{
			return 
				new Operation<T>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
			
				operation14.AsObservable()).And(
			
				operation15.AsObservable()).And(
				operation16.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14, T15 result15, T16 result16) => selector(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15, result16))))
			;
		}

		public IOperation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> SelectTuple<T>()
		{
			return 
				new Operation<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)>(Observable.When(
				operation1.AsObservable().And(
			
				operation2.AsObservable()).And(
			
				operation3.AsObservable()).And(
			
				operation4.AsObservable()).And(
			
				operation5.AsObservable()).And(
			
				operation6.AsObservable()).And(
			
				operation7.AsObservable()).And(
			
				operation8.AsObservable()).And(
			
				operation9.AsObservable()).And(
			
				operation10.AsObservable()).And(
			
				operation11.AsObservable()).And(
			
				operation12.AsObservable()).And(
			
				operation13.AsObservable()).And(
			
				operation14.AsObservable()).And(
			
				operation15.AsObservable()).And(
				operation16.AsObservable())
				.Then((T1 result1, T2 result2, T3 result3, T4 result4, T5 result5, T6 result6, T7 result7, T8 result8, T9 result9, T10 result10, T11 result11, T12 result12, T13 result13, T14 result14, T15 result15, T16 result16) => (result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15, result16))))
			;
		}

    }
}
