using Shared.Http;
using Xunit;

public class ResultTests
{
   [Fact]
   public void SuccessResult_SetsPayload()
   {
      var result = new Result<int>(5);

      Assert.False(result.IsError);
      Assert.Equal(5, result.Payload);
   }

   [Fact]
   public void ErrorResult_SetsError()
   {
      var ex = new Exception("fail");
      var result = new Result<int>(ex);

      Assert.True(result.IsError);
      Assert.Equal(ex, result.Error);
   }
}
