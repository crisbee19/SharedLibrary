using System;
using System.Text.Json;
using Shared.Http;
using Xunit;

public class JsonUtilsTests
{
   private record TestPayload(int Id, string Name);

   [Fact]
   public void DefaultOptions_UsesCamelCaseNaming()
   {
      var payload = new TestPayload(1, "Alice");

      string json = JsonSerializer.Serialize(payload, JsonUtils.DefaultOptions);

      Assert.Contains("\"id\"", json);
      Assert.Contains("\"name\"", json);
      Assert.DoesNotContain("\"Id\"", json);
      Assert.DoesNotContain("\"Name\"", json);
   }

   [Fact]
   public void DefaultOptions_IsCaseInsensitiveOnDeserialization()
   {
      string json = "{ \"ID\": 5, \"NAME\": \"Bob\" }";

      var result = JsonSerializer.Deserialize<TestPayload>(
          json,
          JsonUtils.DefaultOptions
      );

      Assert.NotNull(result);
      Assert.Equal(5, result!.Id);
      Assert.Equal("Bob", result.Name);
   }

   [Fact]
   public void ErrorResult_SerializesExceptionAsJson()
   {
      var ex = new InvalidOperationException("Something failed");
      var result = new Result<string>(ex);

      string json = JsonSerializer.Serialize(
          result.Error,
          JsonUtils.DefaultOptions
      );

      Assert.Contains("Something failed", json);
   }

   [Fact]
   public void SuccessResult_SerializesPayloadCorrectly()
   {
      var payload = new TestPayload(10, "Charlie");
      var result = new Result<TestPayload>(payload);

      string json = JsonSerializer.Serialize(
          result.Payload,
          JsonUtils.DefaultOptions
      );

      Assert.Contains("\"id\":10", json);
      Assert.Contains("\"name\":\"Charlie\"", json);
   }
}
