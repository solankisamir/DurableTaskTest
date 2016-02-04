

namespace DurableTaskTest
{
    using System;
    using System.Threading.Tasks;

    public class ActivityImplementor : IActivityFunction
    {
        public ActivityImplementor()
        {
            
        }

        public Task<bool> DoSomeActivity(string instanceId)
        {
            Console.WriteLine("helloe");
            if (string.IsNullOrEmpty(instanceId))
            {
                throw new SerializableException("Oh my God!!");
            }

            return Task.FromResult(true);
        }
    }
}