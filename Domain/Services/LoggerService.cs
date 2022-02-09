
using Domain.Interfaces.Services;
using Domain.Enumerations;
using Domain.Exception;
using System.Text;

namespace Domain.Services
{
    public class LoggerService : ILoggerService
    {

        private readonly string conectString = @"Domain\Utils\errorsLogger.txt";
        private readonly bool addErro = true;

        private string getDaultMessage()
            => $"ERROR>>[{DateTime.Now.ToString("dddd, dd MMMM yyyy  HH:mm:ss tt")}]";

        private void writeFile(string msg)
        {
            try
            {
                StreamWriter erros = new StreamWriter(conectString, addErro);
                erros.WriteLine(msg);
                erros.Close();
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Erro ao escrever no arquivo");
            }
        }

        private string readFile()
        {
            try
            {
                return File.ReadAllText(conectString, Encoding.UTF8);
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException("Erro ao ler o arquivo");
            }
        }

        public string GetLogs()
            => readFile();

        public void logError(string error)
            => writeFile($"{getDaultMessage()}<< {error}");

        public void logError(BaseException baseException)
            => writeFile($"{getDaultMessage()}<< {baseException.Message} -- {baseException.Exception?.Message}");

        public void logError(BaseException baseException, string id)
            => writeFile($"{getDaultMessage()}[ID {id}]<< {baseException.Message} -- {baseException.Exception?.Message}");

        public void logError(ErrorType error)
            => logError(error.ToString());

        public void logError(ApplicationException error)
            => logError(error.Message);

    }
}