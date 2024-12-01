using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions
{
    public class AppException : Exception
    {
        public ExceptionStatusCode StatusCode { get; set; }

        public AppException(ExceptionStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }

}