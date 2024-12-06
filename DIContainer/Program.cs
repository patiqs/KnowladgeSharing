//var sc = new ServiceCollection();
//sc.AddScoped<Foo>();
//var sp = sc.BuildServiceProvider();
//while (true)
//{
//  //var scope = sp.CreateScope(); //this will not invoke the Dispose
//  using var scope = sp.CreateScope();  //this will dispose the objects
//  var foo = scope.ServiceProvider.GetRequiredService<Foo>();
//  var bar = sp.GetRequiredService<Foo>();
//}

//class Foo() : IDisposable
//{
//  private static volatile int ID = 0;
//  private readonly int _id = Interlocked.Increment(ref ID);

//  public void Dispose() => Console.WriteLine($"{_id:D4} Disposed");

//  ~Foo() => Console.WriteLine($"{_id:D4} Destructed");
//}

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseDefaultServiceProvider(o => { o.ValidateScopes = false; });
builder.Services.AddScoped<Foo>();
var app = builder.Build();
app.Services.GetService<Foo>();
class Foo();

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<MyMiddleWare>();
//builder.Services.AddScoped<Correlation>();

//var app = builder.Build();
//var c = app.Services.GetRequiredService<Correlation>();

//app.UseMiddleware<MyMiddleWare>();

//for (int i = 0; i < 5; i++)
//{
//  var scope = app.Services.CreateScope();
//  var correlation = scope.ServiceProvider.GetRequiredService<Correlation>();
//  correlation.CorrelationId = "ccc" + i;
//  correlation.RequestId = "rrr" + i;
//  await Task.Delay(100);
//}

//app.MapGet("/", (Correlation correlation, ILogger<WebApplication> logger) =>
//{
//  logger.LogInformation($"GET /: fromparams:{correlation}");
//  var scope = app.Services.CreateScope();
//  var fromScopedProvider = scope.ServiceProvider.GetRequiredService<Correlation>();
//  logger.LogInformation($"GET /: fromscoped:{fromScopedProvider}");

//  //SATA: This throws
//  //var fromRootProvider = app.Services.GetRequiredService<Correlation>();
//  //logger.LogInformation($"GET /: fromroot:{fromRootProvider}");
//  return Results.Content(correlation.ToString());
//});

//app.Run();


//record Correlation : IDisposable
//{
//  public string CorrelationId { get; set; } = "Not set";
//  public string RequestId { get; set; } = "Not set";

//  public void Dispose()
//  {
//    CorrelationId += "disposed";
//  }
//}

//class MyMiddleWare(Correlation correlation, ILogger<MyMiddleWare> logger) : IMiddleware
//{
//  private static volatile int CorrelationId = 0;
//  private static volatile int RequestId = 0;
//  public Task InvokeAsync(HttpContext context, RequestDelegate next)
//  {
//    logger.LogInformation($"{nameof(MyMiddleWare)}: in:{correlation}");
//    correlation.CorrelationId = ((string?)context.Request.Headers.CorrelationContext)
//                                ?? (Interlocked.Increment(ref CorrelationId)).ToString();

//    correlation.RequestId = (Interlocked.Increment(ref RequestId)).ToString();

//    logger.LogInformation($"{nameof(MyMiddleWare)}:out:{correlation}");

//    return next.Invoke(context);
//  }
//}