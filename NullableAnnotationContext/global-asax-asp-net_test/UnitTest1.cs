using ServiceReference1;
using System.ServiceModel;
using System.Web.Services;

namespace global_asax_asp_net_test;

public class Tests
{

  [Test]
  public async Task Test1()
  {
    var client = new ServiceReference1.MyWebServiceSoapClient(MyWebServiceSoapClient.EndpointConfiguration.MyWebServiceSoap);

    var x = await client.HelloWorldAsync();

    Assert.Pass();
  }
}