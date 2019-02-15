using Operations;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp12
{

    class Customer
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = "Name";
    }

    class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
    }

    class Repository<TEntity>
        where TEntity : class
    {
        public Task<TEntity> CreateNewAsync()
        {
            return Task.FromResult((TEntity)Activator.CreateInstance(typeof(TEntity)));
        }

        public Task SaveAsync(TEntity entity)
        {
            return Task.FromException(new InvalidOperationException("Failed to save customer"));
            //return Task.CompletedTask;
        }

        public Task ProjectAsync(TEntity entity)
        {
            //return Task.FromException(new InvalidOperationException("Failed to save customer"));
            return Task.CompletedTask;
        }

        public IObservable<TEntity> CreateNew()
        {
            return Observable.FromAsync(CreateNewAsync)
                .WithConsoleLogAndTrace("DAL CreateNew");
        }

        public IObservable<TEntity> Save(TEntity entity)
        {
            return Observable.FromAsync(async () => { await SaveAsync(entity); return entity; })
                .WithConsoleLogAndTrace("DAL Save");
        }

        public IOperation<TEntity> CreateNewOperation()
        {
            return Operation.Create(CreateNewAsync)
                .WithConsoleLogAndTrace("DAL CreateNew");
        }

        public IOperation<TEntity> SaveOperation(TEntity entity)
        {
            return Operation.Create(SaveAsync, entity)
                .WithConsoleLogAndTrace("DAL Save");
        }

        public IOperation<IResult<TEntity>> CreateNewResult()
        {
            return Operation.CreateResult(CreateNewAsync)
                .WithConsoleLogAndTrace("DAL CreateNew");
        }

        public IOperation<IResult<TEntity>> SaveResult(TEntity entity)
        {
            return Operation.CreateResult(SaveAsync, entity)
                .WithConsoleLogAndTrace("DAL Save");
        }
    }

    class CustomerService
    {
        public async Task<Customer> CreateNewCustomerAsync(string name)
        {
            var repo = new Repository<Customer>();
            var customer = await repo.CreateNewAsync();
            customer.Name = name;
            await repo.SaveAsync(customer);
            return customer;
        }

        public IObservable<Customer> CreateNewCustomer(string name)
        {
            var repo = new Repository<Customer>();
            return repo
                .CreateNew()
                .WithConsoleLogAndTrace("Business CreateNewCustomer")
                .Do(x =>
                {
                    x.Name = name;
                })
                .Tap(repo.SaveAsync)
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled at business level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 1"))
                ;
        }

        public IOperation<Customer> CreateNewCustomerOperation(string name)
        {
            var repo = new Repository<Customer>();
            return repo
                .CreateNewOperation()
                .WithConsoleLogAndTrace("Business CreateNewCustomer")
                .ContinueWith(x =>
                {
                    x.Name = name;
                })
                .ContinueWith(repo.SaveAsync)
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled at business level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 1"))
                ;


        }

        public IOperation<IResult<Customer>> CreateNewCustomerResult(string name)
        {
            var repo = new Repository<Customer>();
            return repo
                .CreateNewResult()
                .WithConsoleLogAndTrace("Business CreateNewCustomer")
                .ContinueWith(x =>
                {
                    x.Value.Name = name;
                })
                .ContinueWith(repo.SaveAsync)
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled at business level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 1"))
                ;


        }
    }

    class ApplicationService
    {
        public async Task<CustomerDto> CreateNewCustomerAsync(string name)
        {
            var service = new CustomerService();
            var customer = await service.CreateNewCustomer(name);
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name
            };
        }

        public async Task<CustomerDto> CreateNewCustomer(string name)
        {
            var service = new CustomerService();
            return await service
                .CreateNewCustomer(name)
                .WithConsoleLogAndTrace("Application CreateNewCustomer")
                .Log((InvalidOperationException e) => { })
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled  at application level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 2"))
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .RunAsync(CancellationToken.None);
        }

        public async Task<CustomerDto> CreateNewCustomerOperation(string name)
        {
            var service = new CustomerService();
            return await service
                .CreateNewCustomerOperation(name)
                .WithConsoleLogAndTrace("Application CreateNewCustomer")
                .Log((InvalidOperationException e) => { })
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled  at application level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 2"))
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ExecuteAsync(CancellationToken.None);
        }

        public async Task<CustomerDto> CreateNewCustomerResult(string name)
        {
            var service = new CustomerService();
            var result =
                await service
                .CreateNewCustomerResult(name)
                .WithConsoleLogAndTrace("Application CreateNewCustomer")
                .Log((InvalidOperationException e) => { })
                //.Catch((Exception e) =>
                //{
                //    Console.WriteLine("Exception caught and handled  at application level: " + e.Message);
                //    return Observable.Return(new Customer());
                //})
                //.Finally(() => Console.WriteLine("Finally 2"))
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ExecuteAsync(CancellationToken.None);

            return result.Value;
        }
    }

    static class Program
    {
        static async Task Main(string[] args)
        {
            var controller = new ApplicationService();
            try
            {
                var customerDto = await controller.CreateNewCustomerResult("Nikos");
                Console.WriteLine($"Customer {customerDto.Name} ({customerDto.Id})");
            }
            catch(Exception e)
            {
                Console.WriteLine("Unhandled exception: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
