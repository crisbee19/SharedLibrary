using Shared.Http;
using Xunit;

public class HttpServerTests
{
   private class TestServer : HttpServer
   {
      public bool InitCalled { get; private set; }

      public override void Init()
      {
         InitCalled = true;
      }
   }

   [Fact]
   public void Constructor_CallsInit()
   {
      var server = new TestServer();

      Assert.True(server.InitCalled);
   }
}
