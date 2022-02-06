
using Domain.Interfaces.Services;
using Domain.Enumerations;
using Domain.Exception;

namespace Domain.Services
{
    public class LoggerService : ILoggerService
    {

        private readonly string conectString = @"Domain\Utils\errorsLogger.txt";
        private readonly bool addErro = true;

        private void handleFile(string msg)
        {
            StreamWriter erros = new StreamWriter(conectString, addErro);
            erros.WriteLine(msg);
            erros.Close();
        }

        public void logError(string error)
            => handleFile($"ERROR>>[{DateTime.UtcNow.Kind}]<< {error}");

        public void logError(BaseException baseException)
            => handleFile($"ERROR>>[{DateTime.UtcNow.Kind}]<< {baseException.Message} -- {baseException.Exception?.Message}");
        
        public void logError(BaseException baseException, string id)
            => handleFile($"ERROR>>[{DateTime.UtcNow.Kind}][ID {id}]<< {baseException.Message} -- {baseException.Exception?.Message}");

        public void logError(ErrorType error)
            => logError(error.ToString());

        public void logError(ApplicationException error)
            => logError(error.Message);


    }
}