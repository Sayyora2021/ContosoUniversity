namespace ContosoUniversity.Tests.Controllers;



public abstract class AbstractControllerTests : IClassFixture<TestApplicationFactory>
{
    protected HttpClient Client { get; }



    protected AbstractControllerTests(TestApplicationFactory factory)
    {
        Client = factory.CreateClient();
    }



}
