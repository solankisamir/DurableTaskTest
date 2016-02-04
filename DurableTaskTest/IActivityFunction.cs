
namespace DurableTaskTest
{
    using System.Threading.Tasks;

    public interface IActivityFunction
    {
        Task<bool> DoSomeActivity(string instanceId);
    }
}