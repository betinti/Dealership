using Domain.Models;
using Domain.Enumerations;
using Domain.Exception;

namespace Domain.Interfaces.Services
{
    public interface ILoggerService
    {
        void logError(string error);
        void logError(ErrorType error);
        void logError(BaseException error);
        void logError(BaseException error, string id);
        void logError(ApplicationException error);
        string GetLogs();
    }
}