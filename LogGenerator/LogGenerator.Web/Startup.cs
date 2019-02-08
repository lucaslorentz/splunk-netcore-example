using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace LogGenerator.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Application started");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // Simple properties
                logger.LogInformation(LoggingEvents.ReceivedRequest, "Received request at {Path}", context.Request.Path);

                var request = new
                {
                    Date = DateTime.Now,
                    UserAgent = context.Request.Headers["User-Agent"].ToString(),
                    Ip = context.Connection.RemoteIpAddress.ToString()
                };

                // Serialize complex objects
                logger.LogInformation(LoggingEvents.RequestDetails, "Request details {@Request}", request);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }

    public static class LoggingEvents
    {
        public static readonly EventId ReceivedRequest = new EventId(1, "ReceivedRequest");
        public static readonly EventId RequestDetails = new EventId(2, "RequestDetails");
    }
}
