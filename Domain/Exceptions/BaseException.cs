

using Domain.Services;
using Domain.Enumerations;
using Domain.Interfaces.Services;

namespace Domain.Exception
{
    public class BaseException : ApplicationException
    {
        public string Message { get; }
        public ApplicationException? Exception { get; }

        private readonly ILoggerService logService = new LoggerService();

        public BaseException(ErrorType ErrorType)
        {
            this.Message = ErrorType.ToString();

            logService.logError(this.Message);
        }

        public BaseException(ErrorType ErrorType, ApplicationException e)
        {
            this.Message = ErrorType.ToString();
            this.Exception = e;

            logService.logError(this);
        }
        public BaseException(ErrorType ErrorType, ApplicationException e, string id)
        {
            this.Message = ErrorType.ToString();
            this.Exception = e;


            logService.logError(this, id);
        }

        public BaseException(string Message, ApplicationException e)
        {
            this.Message = Message;
            this.Exception = e;

            logService.logError(this);
        }
        
        public BaseException(string Message)
        {
            this.Message = Message;

            logService.logError(this);
        }

        public BaseException(ErrorType ErrorType, string id)
        {
            this.Message = ErrorType.ToString();

            logService.logError(this, id);
        }
        public BaseException(string Message, string id)
        {
            this.Message = Message;

            logService.logError(this, id);
        }
    }
}