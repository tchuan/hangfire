using Hangfire;
using Hangfire.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HangFireDashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnqueueController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EnqueueController> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public EnqueueController(ILogger<EnqueueController> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Test");
            return "Enqueued Job " + _backgroundJobClient.Enqueue<BackgroundTask>(work => work.Execute(HttpContext.TraceIdentifier));
        }
    }
}
