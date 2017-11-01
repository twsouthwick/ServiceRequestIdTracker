[![Build status](https://ci.appveyor.com/api/projects/status/2tbyw33lchgke9sm/branch/master?svg=true)](https://ci.appveyor.com/project/twsouthwick/servicerequestidtracker/branch/master)

# Set up a correlation Id across microservice calls

In order to correlate requests across web api calls (for instance in a microservice scenario):

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

## Exposed services

In order to use any exposed services, the `app.UseRequestCorrelation()` must be added before any other middleware. Middleware
run before this will not have access to any of the services. If MVC is registered before, then controlls will not have access
to the correlation id.

### HttpClient for requests
An HttpClient instance is available and scoped for each request. This client sets the header so that calls made with it will
propogate the correlation id. In order to use this, request the `RequestCorrelation.CorrelatedHttpClient` via dependendency
injection.

### Correlation Id
In order to access the correlation id itself, you can request the `RequestCorrelation.ICorrelationIdAccessor` via dependency 
injection. This is scope per request and will contain the correlation id.
