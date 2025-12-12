using System;
using System.IO;
using Shared.Config;
using Xunit;

public class ConfigurationTests
{
   [Fact]
   public void LoadConfigurationFile_ParsesKeyValuePairs()
   {
      var path = Path.GetTempFileName();
      File.WriteAllText(path, "a=1\nb=hello");

      var cfg = Configuration.LoadConfigurationFile(path);

      Assert.Equal("1", cfg["a"]);
      Assert.Equal("hello", cfg["b"]);
   }

   [Fact]
   public void Get_ReturnsEnvironmentVariableFirst()
   {
      Environment.SetEnvironmentVariable("CFG_TEST", "env");

      var value = Configuration.Get("CFG_TEST", "default");

      Assert.Equal("env", value);
      Environment.SetEnvironmentVariable("CFG_TEST", null);
   }

   [Fact]
   public void Get_Generic_InvalidValue_ReturnsDefault()
   {
      var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.cfg");
      File.WriteAllText(path, "X=abc");

      var value = Configuration.Get("X", 99);

      Assert.Equal(99, value);
   }
}
