
namespace DurableTaskTest
{
    using System;
    using DurableTask;
    using System.Configuration;

    class Program
    {  
        static void Main(string[] args)
        {  
            AppSettingsReader reader = new AppSettingsReader();
            string servicebusConnectionString = reader.GetValue("Microsoft.ServiceBus.ConnectionString", typeof (string)).ToString();
            string taskHubName = reader.GetValue("TaskHubName", typeof(string)).ToString();

            TaskHubClient taskHubClient = new TaskHubClient(taskHubName, servicebusConnectionString);
            TaskHubWorker taskHub = new TaskHubWorker(taskHubName, servicebusConnectionString);
            
            taskHub.DeleteHub();
            taskHub.CreateHubIfNotExists();

            OrchestrationInstance instance = null;

            string instanceId = "TestTaskHub : " + Guid.NewGuid();
            
            taskHub.AddTaskOrchestrations((typeof(TaskHubProcessingOrchestration)));
            taskHub.AddTaskActivitiesFromInterface<IActivityFunction>(new ActivityImplementor(), true);
            taskHub.AddTaskActivities(new GetUserTask());

            instance = taskHubClient.CreateOrchestrationInstance(typeof(TaskHubProcessingOrchestration), instanceId, "hello");
            
            taskHub.Start();
            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();
            taskHub.Stop(true);
        }
    }
}
