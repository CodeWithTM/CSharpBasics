using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    internal class GenericsPractice
    {
        public interface IRequest<T> { }

        public class GetAge : IRequest<int> { }

        public class GetName : IRequest<string> { }

        public interface IHandler { };

        public abstract class Handler<T> : IHandler
        {
            public abstract T Handle(IRequest<T> request);
        };

        public abstract class Handler<TRequest, TResponse> : Handler<TResponse>
            where TRequest : IRequest<TResponse>
        {
            public override TResponse Handle(IRequest<TResponse> request) =>
                Handle((TRequest)request);

            protected abstract TResponse Handle(TRequest requst);
        }

        public class GetAgeHandler : Handler<GetAge, int>
        {
            protected override int Handle(GetAge request) => 20;
        }

        public class GetNameHandler : Handler<GetName, string>
        {
            protected override string Handle(GetName request) => "Foo";
        }


        public class RequestHandler
        {
            public Dictionary<Type, IHandler> requestHandlers = null;
            /*new()
        {
            [typeof(GetAge)] = new GetAgeHandler(),
            [typeof(GetName)] = new GetNameHandler(),
        };*/

            public T Handle<T>(IRequest<T> request)
            {
                var handler = requestHandlers[request.GetType()];
                if (handler is Handler<T> h)
                {
                    return h.Handle(request);
                }
                return default;
            }
        }

        public void Main()
        {


            MyList<int> ml2 = new MyList<int>();

            List<int> ints = new List<int>();

            MyList<int> myList = new MyList<int>();
            myList.Do<int>();

        }
    }

    public interface IMyList<T>
    {
        void Do<T1>();
    }

    public class MyList<T> : IMyList<T>
    {
        public void Do<T1>()
        {
        }
    }


    //------------another example -----------------

    public abstract class DomainEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

    }
    public class Article : DomainEntity
    {
        public string Name { get; set; }
    }

    public class Author : DomainEntity
    {
        public string Name { get; set; }
    }

    public interface IRepository<T>
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
    }

    public class BaseRepository<T> : IRepository<T> where T : DomainEntity
    {
        private readonly List<T> _repository;
        public BaseRepository(List<T> data)
        {
            _repository = data;
        }

        public Task<T> GetAsync(Guid id)
        {
            return Task.FromResult(_repository.First(a => a.Equals(id)));
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return Task.FromResult(_repository.AsEnumerable());
        }
    }

    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(List<Article> data) : base(data)
        {
        }
    }
}
