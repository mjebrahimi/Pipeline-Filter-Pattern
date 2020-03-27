using System.Threading.Tasks;

namespace PipelineFilterPattern.Implementation2
{
    public class UpperCaseString : PipelineStep<string>
    {
        public override async Task<string> ProcessAsync(string input)
        {
            return input.ToUpper();
        }
    }

    public class ReplaceWorld : PipelineStep<string>
    {
        public override async Task<string> ProcessAsync(string input)
        {
            return input.Replace("World", "Mohammad Javad");
        }
    }
}
