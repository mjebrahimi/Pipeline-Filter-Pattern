using System;
using System.Threading.Tasks;

namespace PipelineFilterPattern
{
    public static class Program
    {
        public static async Task Main()
        {
            {
                Implementation1.Pipeline<string> pipeline = new Implementation1.Pipeline<string>();

                pipeline
                    .Register(new Implementation1.ReplaceWorld())
                    .Register(new Implementation1.UpperCaseString());

                var input = "Hello World!";

                var result = await pipeline.ExecuteAsync(input);

                Console.WriteLine(result);

                // Output
                //-------------------------
                // > HELLO MOHAMMAD JAVAD
                //-------------------------
            }

            {
                Implementation2.Pipeline<string> pipeline = new Implementation2.Pipeline<string>();

                pipeline
                    .Register(new Implementation2.ReplaceWorld())
                    .Register(new Implementation2.UpperCaseString());

                var input = "Hello World!";

                var result = await pipeline.ExecuteAsync(input);

                Console.WriteLine(result);

                // Output
                //-------------------------
                // > HELLO MOHAMMAD JAVAD
                //-------------------------
            }
            Console.ReadLine();
        }
    }


}

namespace Test
{

    public interface IFilter<T>
    {
        T Execute(T val);
        void Register(IFilter<T> filter);
    }

    public abstract class FilterBase<T> : IFilter<T>
    {
        private IFilter<T> _next;
        protected abstract T Process(T input);
        public T Execute(T input)
        {
            T val = Process(input);
            if (_next != null)
                val = _next.Execute(val);
            return val;
        }

        public void Register(IFilter<T> filter)
        {
            if (_next == null)
                _next = filter;
            else
                _next.Register(filter);
        }
    }

    public interface IFilterChain<T>
    {
        T Execute(T val);
        IFilterChain<T> Register(IFilter<T> filter);
    }

    public class Pipeline<T> : IFilterChain<T>
    {
        private IFilter<T> _root;
        public T Execute(T input)
        {
            return _root.Execute(input);
        }

        public IFilterChain<T> Register(IFilter<T> filter)
        {
            if (_root == null)
                _root = filter;
            else
                _root.Register(filter);
            return this;
        }
    }

    public class UpperCaseString : FilterBase<string>
    {
        protected override string Process(string input)
        {
            var result = input.ToUpper();
            return result;
        }
    }

    public class Substring : FilterBase<string>
    {
        protected override string Process(string input)
        {
            var result = input.Substring(6);
            return result;
        }
    }
}