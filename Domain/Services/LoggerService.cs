
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
            => $"ERROR>>[{DateTime.Now.ToLongDateString()}]";

        private void writeFile(string msg)
        {
            StreamWriter erros = new StreamWriter(conectString, addErro);
            erros.WriteLine(msg);
            erros.Close();
        }

        // private string readFile()
        // {
        //     string file = File.ReadAllText(conectString, Encoding.UTF8);

        //     System.Console.WriteLine(file);
        // }

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