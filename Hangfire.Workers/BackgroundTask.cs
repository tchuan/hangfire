using System;
using System.Threading.Tasks;

namespace Hangfire.Workers
{
    public interface IBackgroundTask
    {
        Task Execute(string arg);
    }

    public class BackgroundTask : IBackgroundTask
    {
        public async Task Execute(string arg)
        {
            Console.WriteLine($"I'm processing {arg}...");

            await Task.Delay(30000);

            Console.WriteLine("Done");
        }
    }
}
