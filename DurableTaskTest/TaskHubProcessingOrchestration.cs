using System;
using System.Threading.Tasks;
using DurableTask;

namespace DurableTaskTest
{
    public class TaskHubProcessingOrchestration : TaskOrchestration<int, string>
    {
        private IActivityFunction _activityProxy;

        public override async Task<int> RunTask(OrchestrationContext context, string input)
        {
            this.Initialize(context);
            
            int processed = 0;

            try
            {
                // this is not getting hit
                await this._activityProxy.DoSomeActivity(string.Empty);
            }
            catch (Exception exception)
            {
                var taskException = exception as TaskFailedException;
                if (taskException != null)
                {
                    var taskExceptionInternal = taskException.InnerException as SerializableException;
                    if (taskExceptionInternal != null)
                    {
                        Console.WriteLine("Wolla");
                    }
                }
            }

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

        protected void Initialize(OrchestrationContext context)
        {
            this._activityProxy = context.CreateClient<IActivityFunction>(true);
        }
    }
}
