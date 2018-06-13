using System.Threading.Tasks;

namespace Jacaranda.Data
{
    public interface IErrorLoggerService
    {
        Task LogErrorToDbAsync(string requestUrl, string requestBody, string message, string stackTrace);
    }
}
