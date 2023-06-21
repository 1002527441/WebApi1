namespace WebApi1.Application.TestServices;

public interface ITestService
{
    Task<string> AddTest(string name);
    Task<string> DeleteById(string Id);
    Task<string> GetById(string Id);
}