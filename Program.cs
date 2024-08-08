using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddHttpClient();
builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("CheckActiveSessions");
    q.AddJob<SessionTimeoutService>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(
        opts =>
            opts.ForJob(jobKey)
                .WithIdentity("CheckActiveSessions-trigger")
                .WithCronSchedule("0 * * ? * *")
    );
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles()
    .UseStaticFiles()
    .UseWebSockets()
    .UseRouting()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    }).UseCXPerium();

app.Run();
