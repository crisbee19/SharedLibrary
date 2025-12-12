using System.Collections.Specialized;
using Shared.Http;
using Xunit;

public class HttpRouterTests
{
   [Fact]
   public void ParseUrlParams_MatchesAndExtractsParameters()
   {
      var result = HttpRouter.ParseUrlParams(
          "/users/42/posts/abc",
          "/users/:id/posts/:slug"
      );

      Assert.NotNull(result);
      Assert.Equal("42", result["id"]);
      Assert.Equal("abc", result["slug"]);
   }

   [Fact]
   public void ParseUrlParams_ReturnsNullOnMismatch()
   {
      var result = HttpRouter.ParseUrlParams(
          "/users/42",
          "/users/:id/posts"
      );

      Assert.Null(result);
   }
}
