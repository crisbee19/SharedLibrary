using System.Collections;
using System.Net;
using Shared.Http;
using Xunit;

public class HttpMiddlewareTests
{
   [Fact]
   public async Task HttpMiddleware_InvokesNext()
   {
      bool called = false;

      HttpMiddleware mw = async (_, _, _, next) =>
      {
         called = true;
         await next();
      };

      await mw(null!, null!, new Hashtable(), () => Task.CompletedTask);

      Assert.True(called);
   }
}
