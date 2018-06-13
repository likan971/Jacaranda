using System;

namespace Jacaranda.Utilities
{
    public static class ExceptionExtension
    {
        public static string GetFullMessages(this Exception exception, string separator = ">>")
        {
            if (exception.InnerException == null)
            {
                return exception.Message;
            }

            return $"{exception.Message} {separator} {GetFullMessages(exception.InnerException, separator)}";
        }
    }
}
