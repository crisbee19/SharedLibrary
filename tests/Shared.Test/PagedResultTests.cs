using Shared.Http;
using Xunit;

public class PagedResultTests
{
   [Fact]
   public void Constructor_SetsValues()
   {
      var values = new List<int> { 1, 2 };
      var result = new PagedResult<int>(10, values);

      Assert.Equal(10, result.TotalCount);
      Assert.Equal(values, result.Values);
   }
}
