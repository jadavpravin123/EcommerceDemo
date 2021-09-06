using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ECommerce.Sevice
{
    public class ServiceResponseExceptionHandler<T> : Exception
    {
        public ILogger<T> _logger;
        public string Exception { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public ServiceResponseExceptionHandler(ILogger<T> logger)
        {
            _logger = logger;
        }
        public ServiceResponseExceptionHandler(string msg, HttpStatusCode httpStatusCode)
        {
            Exception = msg;
            HttpStatusCode = httpStatusCode;

        }

    }
}
