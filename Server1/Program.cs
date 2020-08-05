using System;
using Hangfire;
using Hangfire.SqlServer;

namespace Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server =(localdb)\hangfire; Database = Hangfire; Integrated Security = SSPI; ";
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });

            var backgroudJobServerOptions = new BackgroundJobServerOptions
            {
                WorkerCount = 2
            };
            using (var server = new BackgroundJobServer(backgroudJobServerOptions))
            {
                Console.WriteLine("Hangfire Server 1 started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
