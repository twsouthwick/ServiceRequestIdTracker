[![Build status](https://ci.appveyor.com/api/projects/status/2tbyw33lchgke9sm/branch/master?svg=true)](https://ci.appveyor.com/project/twsouthwick/servicerequestidtracker/branch/master)

# Creating a microservice session id

In order to track request IDs across web api calls (for instance in a microservice scenario):

```csharp
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddRequestCorrelation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRequestCorrelation();
        app.UseMvc();
    }
}
```

Now, to request access to the id, request the interface `ICorrelationIdAccessor` via DI. Logs requested via `ILogger<>` will also contain the service request id as scoped information.