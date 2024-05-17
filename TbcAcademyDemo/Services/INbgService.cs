namespace TbcAcademyDemo.Services
{
    public interface INbgService
    {
        Task<string> GetRates(CancellationToken cancellationToken);
    }
}
