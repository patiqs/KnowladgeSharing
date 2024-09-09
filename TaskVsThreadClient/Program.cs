using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;

HttpClient client = new();
client.Timeout = TimeSpan.FromSeconds(30);

ConcurrentBag<Exception> exceptions = new ConcurrentBag<Exception>();

var chosenApi = args.Any()?  args[0] : "task";

await Invoke(chosenApi, 1);
await Invoke(chosenApi, 10);
await Invoke(chosenApi, 100);
await Invoke(chosenApi, 1000);
if (chosenApi=="task") await Invoke(chosenApi, 5000);

return;

async Task Invoke(string api, int times)
{
  exceptions.Clear();
  var sw = Stopwatch.StartNew();
  var getters = Enumerable.Repeat( ()=> Get(api), times).Select(getter=>getter());
  var results = await Task.WhenAll(getters);
  sw.Stop();

  Console.WriteLine($"------------{times} {api} -----------");
  Console.WriteLine($"Elapsed overall:{sw.Elapsed} " +
                    $"min:{results.Min(r => r.Elapsed.TotalSeconds):F3} s " +
                    $"avg:{results.Average(r => r.Elapsed.TotalSeconds):F3} s " +
                    $"max:{results.Max(r=>r.Elapsed.TotalSeconds):F3} s");

  var statusReport = string.Join(',', results.GroupBy(r => r.StatusCode).Select(group => $"{group.Key}:{group.Count()}"));
  Console.WriteLine($"statuses: {statusReport}");

  if (exceptions.IsEmpty) return;
  var exceptionReport = string.Join(Environment.NewLine, exceptions.GroupBy(ex => ex.Message).Select(group => $"{group.Count(),-5} - {group.Key}"));
  Console.WriteLine($"exceptions:");
  Console.WriteLine(exceptionReport);
}

async Task<InvocationDetails> Get(string api)
{
  Stopwatch sw = Stopwatch.StartNew();
  try
  {
    HttpResponseMessage httpResponseMessage = await client.GetAsync($"http://localhost:5000/{api}");
    sw.Stop();
    return new InvocationDetails(api, httpResponseMessage.StatusCode, sw.Elapsed);
  }
  catch (Exception ex)
  {
    sw.Stop();
    exceptions.Add(ex);
  }

  return new InvocationDetails(api, HttpStatusCode.InternalServerError, sw.Elapsed);
}

public record InvocationDetails(string Api, HttpStatusCode StatusCode, TimeSpan Elapsed);
