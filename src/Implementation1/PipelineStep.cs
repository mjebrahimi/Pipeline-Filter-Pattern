using System.Threading.Tasks;

namespace PipelineFilterPattern.Implementation1
{
    public interface IPipelineStep<T>
    {
        T Process(T input);
        Task<T> ProcessAsync(T input);
    }

    public abstract class PipelineStep<T> : IPipelineStep<T>
    {
        public virtual T Process(T input)
        {
            return input;
        }

        public virtual Task<T> ProcessAsync(T input)
        {
            return Task.FromResult(input);
        }
    }

}
