namespace NugetTestProject;

using Microsoft.AspNetCore.Mvc.Testing;

public class Tests
{
    private WebApplicationFactory<HelloWorldProgram> factory;

    [SetUp]
    public void Setup()
    {
        this.factory = new WebApplicationFactory<HelloWorldProgram>();
    }

    [Test]
    public async Task Test1()
    {
        var client = this.factory.CreateClient();
        var response = await client.GetAsync("/");
        Assert.AreEqual("Hello World!", await response.Content.ReadAsStringAsync());
    }
}