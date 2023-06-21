namespace WebApi1.Application.TestServices;


public class TestService : ITestService, ITransient
{
    /// <summary>
    /// add Test
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<string> AddTest(string name)
    {
        await Task.Delay(1000);
        return name;
    }
    /// <summary>
    /// delete
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<string> DeleteById(string Id)
    {
        await Task.Delay(1000);
        return Id;
    }

    /// <summary>
    /// GetById
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<string> GetById(string Id)
    {
        await Task.Delay(1000);
        return Id;
    }
}
