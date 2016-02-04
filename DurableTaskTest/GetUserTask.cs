

namespace DurableTaskTest
{
    using System;
    using DurableTask;

    public sealed class GetUserTask : TaskActivity<string, string>
    {
        public GetUserTask()
        {
        }

        protected override string Execute(TaskContext context, string input)
        {
            Console.WriteLine("Waiting for user to enter name...");

            if (string.IsNullOrEmpty(input))
            {
                throw new SerializableException("hello");
            }

            Console.WriteLine("User Name Entered: ");

            return string.Empty;
        }
    }
}