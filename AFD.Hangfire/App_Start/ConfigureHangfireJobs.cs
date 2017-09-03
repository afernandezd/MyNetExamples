using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;

namespace AFD.Hangfire.App_Start
{
    public class ConfigureHangfireJobs
    {
        public static void Configure()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget Job Executed"));

            // delayed job example
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed job executed"), TimeSpan.FromMinutes(1));

            // recurring job example
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Minutely Job executed"), Cron.Minutely);

            // Continuations job example
            var id = BackgroundJob.Enqueue(() => Console.WriteLine("Hello, "));
            BackgroundJob.ContinueWith(id, () => Console.WriteLine("world!"));
        }
    }
}