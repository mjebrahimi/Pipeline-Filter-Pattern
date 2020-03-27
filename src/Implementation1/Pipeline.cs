using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipelineFilterPattern.Implementation1
{
    public interface IPipeline<T>
    {
        IPipeline<T> Register(IPipelineStep<T> step);
        Task<T> ExecuteAsync(T input);
    }

    public class Pipeline<T> : IPipeline<T>
    {
        private List<IPipelineStep<T>> _pipelinSteps = new List<IPipelineStep<T>>();

        public async Task<T> ExecuteAsync(T input)
        {
            foreach (var pipelineStep in _pipelinSteps)
            {
                var type = pipelineStep.GetType();
                var isOverriden = type.GetMethod("ProcessAsync").DeclaringType == type;

                //Calling async method if availeble otherwise calling sync method
                if (isOverriden)
                    input = await pipelineStep.ProcessAsync(input);
                else
                    input = pipelineStep.Process(input);
            }
            return input;
        }

        public IPipeline<T> Register(IPipelineStep<T> step)
        {
            _pipelinSteps.Add(step);
            return this;
        }
    }

}
