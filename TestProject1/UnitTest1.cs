namespace TestProject1;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

[Parallelizable(ParallelScope.All)]
public class Tests
{
    [Test]
    public async Task Test1()
    {
        var client = new CustomApplicationFactory<HelloWorldProgram>("1").CreateClient();
        for (var x = 0; x < 1000; x++)
        {
            var response = await client.GetAsync("/");
            Assert.AreEqual("Hello World! 1", await response.Content.ReadAsStringAsync());
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }

    [Test]
    public async Task Test2()
    {
        var client = new CustomApplicationFactory<HelloWorldProgram>("2").CreateClient();
        for (var x = 0; x < 1000; x++)
        {
            var response = await client.GetAsync("/");
            Assert.AreEqual("Hello World! 2", await response.Content.ReadAsStringAsync());
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }
}

public class CustomApplicationFactory<T>(string instance) : WebApplicationFactory<T>
    where T : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureHostConfiguration(config =>
        {
            config.AddInMemoryCollection(
                new Dictionary<string, string?> { { "Instance", instance } }
            );
        });

        return base.CreateHost(builder);
    }
}
