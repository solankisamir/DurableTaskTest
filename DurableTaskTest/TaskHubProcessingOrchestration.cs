using System;
using System.Threading.Tasks;
using DurableTask;

namespace DurableTaskTest
{
    public class TaskHubProcessingOrchestration : TaskOrchestration<int, string>
    {
        public override async Task<int> RunTask(OrchestrationContext context, string input)
        {
            int processed = 0;

            while (processed < 50)
            {
                processed += await this.ReduceNumber((50 - processed));

                Console.WriteLine("Processed is now =>" + processed);
            }

            return processed;
        }

        Task<int> ReduceNumber(int inputNumber)
        {
            Console.WriteLine("Received Value " + inputNumber);
            return Task.FromResult(5);
        }
    }
}
