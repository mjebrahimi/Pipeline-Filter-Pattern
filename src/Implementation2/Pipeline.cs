using System.Threading.Tasks;

namespace PipelineFilterPattern.Implementation2
{
    public interface IPipeline<T>
    {
        Task<T> ExecuteAsync(T input);
        IPipelineStep<T> Register(IPipelineStep<T> step);
    }

    public class Pipeline<T> : IPipeline<T>
    {
        private IPipelineStep<T> _rootStep;

        public Task<T> ExecuteAsync(T input)
        {
            return _rootStep.ExecuteAsync(input);
        }

        public IPipelineStep<T> Register(IPipelineStep<T> step)
        {
            if (_rootStep == null)
                _rootStep = step;
            else
                _rootStep.Register(step);
            return _rootStep;
        }
    }

}
