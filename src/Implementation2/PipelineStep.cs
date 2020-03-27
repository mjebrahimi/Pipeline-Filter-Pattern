using System.Threading.Tasks;

namespace PipelineFilterPattern.Implementation2
{
    public interface IPipelineStep<T>
    {
        Task<T> ExecuteAsync(T input);

        T Process(T input);
        Task<T> ProcessAsync(T input);

        IPipelineStep<T> Register(IPipelineStep<T> step);
    }

    public abstract class PipelineStep<T> : IPipelineStep<T>
    {
        private IPipelineStep<T> _nextStep;

        public async Task<T> ExecuteAsync(T input)
        {
            var type = this.GetType();
            var isOverriden = type.GetMethod("ProcessAsync").DeclaringType == type;

            //Calling async method if availeble otherwise calling sync method
            if (isOverriden)
                input = await ProcessAsync(input);
            else
                input = Process(input);

            if (_nextStep == null)
                return input;
            else
                return await _nextStep.ExecuteAsync(input);
        }

        public virtual T Process(T input)
        {
            return input;
        }

        public virtual Task<T> ProcessAsync(T input)
        {
            return Task.FromResult(input);
        }

        public IPipelineStep<T> Register(IPipelineStep<T> step)
        {
            if (_nextStep == null)
                _nextStep = step;
            else
                _nextStep.Register(step);
            return this;
        }
    }

}
