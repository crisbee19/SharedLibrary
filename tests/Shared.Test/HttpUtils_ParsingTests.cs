using Shared.Http;
using Xunit;

public class HttpUtils_ParsingTests
{
   [Fact]
   public void DetectContentType_Json()
   {
      var type = HttpUtils.DetectContentType("{ \"a\": 1 }");
      Assert.Equal("application/json", type);
   }

   [Fact]
   public void DetectContentType_Xml()
   {
      var type = HttpUtils.DetectContentType("<root></root>");
      Assert.Equal("application/xml", type);
   }

   [Fact]
   public void ParseFormData_MergesDuplicateKeys()
   {
      var result = HttpUtils.ParseFormData("a=1&a=2");

      Assert.Equal("1,2", result["a"]);
   }
}
