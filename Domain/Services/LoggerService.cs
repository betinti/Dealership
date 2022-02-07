
using Domain.Interfaces.Services;
using Domain.Enumerations;
using Domain.Exception;

namespace Domain.Services
{
    public class LoggerService : ILoggerService
    {

        private readonly string conectString = @"Domain\Utils\errorsLogger.txt";
        private readonly bool addErro = true;

        private string getDaultMessage()
            => $"ERROR>>[{DateTime.Now.ToLongDateString()}]";

        private void handleFile(string msg)
        {
            StreamWriter erros = new StreamWriter(conectString, addErro);
            erros.WriteLine(msg);
            erros.Close();
        }

        public void logError(string error)
            => handleFile($"{getDaultMessage()}<< {error}");

        public void logError(BaseException baseException)
            => handleFile($"{getDaultMessage()}<< {baseException.Message} -- {baseException.Exception?.Message}");

        public void logError(BaseException baseException, string id)
            => handleFile($"{getDaultMessage()}[ID {id}]<< {baseException.Message} -- {baseException.Exception?.Message}");

        public void logError(ErrorType error)
            => logError(error.ToString());

        public void logError(ApplicationException error)
            => logError(error.Message);


    }
}