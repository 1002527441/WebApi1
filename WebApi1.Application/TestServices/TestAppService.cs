namespace WebApi1.Application.TestServices;

[ApiDescriptionSettings("Test")]
public class TestAppService:IDynamicApiController
{
    private readonly ITestService _testService;

    public TestAppService(ITestService testService)
    {
            this._testService  = testService;
    }
    public async Task<string> Add(string name)
    {
       return await _testService.AddTest(name);
    }


    public async Task<string> Delete(string Id)
    {
        return await _testService.DeleteById(Id);
    }

    public async Task<string> Get(string Id)
    {
        return await _testService.GetById(Id);
    }
}
