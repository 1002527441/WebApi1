namespace WebApi1.Application.TestServices;

[ApiDescriptionSettings("Test")]
public class TestAppService:IDynamicApiController
{
    private readonly ITestService _testService;

    public TestAppService(ITestService testService)
    {
            this._testService  = testService;
    }
    public async Task<string> AddTest(string name)
    {
       return await _testService.AddTest(name);
    }


    public async Task<string> DeleteById(string Id)
    {
        return await _testService.DeleteById(Id);
    }

    public async Task<string> GetById(string Id)
    {
        return await _testService.GetById(Id);
    }
}
