using System.Diagnostics;
using System.Net;

InvocationDetails result = await GetAsync();

Console.WriteLine($"{result.Elapsed} to get '{result.StatusCode}'");
return;

static async Task<InvocationDetails> GetAsync()
{
  HttpClient client = new HttpClient();
  Stopwatch sw = Stopwatch.StartNew();
  try
  {
    HttpResponseMessage httpResponseMessage = await client.GetAsync("https://localhost:5000/task");
    sw.Stop();
    return new InvocationDetails(httpResponseMessage.StatusCode, sw.Elapsed);
  }
  catch (Exception ex)
  {
    sw.Stop();
    Console.WriteLine(ex.Message);
  }

  return new InvocationDetails(HttpStatusCode.InternalServerError, sw.Elapsed);
}

public record InvocationDetails(HttpStatusCode StatusCode, TimeSpan Elapsed);
