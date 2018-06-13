using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jacaranda.Entity;

namespace Jacaranda.Data
{
    public class ErrorLoggerService : IErrorLoggerService
    {
        private JacarandaDbContext _dbContext;

        public ErrorLoggerService(JacarandaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task LogErrorToDbAsync(string requestUrl, string requestBody, string message, string stackTrace)
        {
            var errorLog = new ErrorLog {
                RequestUrl = requestUrl,
                RequestBody = requestBody,
                Message = message,
                StackTrace = stackTrace,
                CreatedTime = DateTime.Now
            };

            _dbContext.ErrorLogs.Add(errorLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
