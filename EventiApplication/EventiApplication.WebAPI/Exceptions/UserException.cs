using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string Message): base(Message)
        {

        }
    }
}
