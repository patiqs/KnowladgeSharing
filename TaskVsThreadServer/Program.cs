WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

WebApplication app = builder.Build();

SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

app.MapGet("task", async () => await Task.Delay(3000));

app.MapGet("thread", () => { Thread.Sleep(3000); });

app.MapGet("mix", () => { Task.Delay(3000).Wait(); });

app.MapGet("complex", () => { Task.Run(async () => await Task.Delay(3000)).Wait(); });

var client = new HttpClient();
app.MapGet("evil", () =>
{
  Task.Run(async () => await client.GetAsync("http://localhost:5000/task")).Wait();
});

app.Run();
