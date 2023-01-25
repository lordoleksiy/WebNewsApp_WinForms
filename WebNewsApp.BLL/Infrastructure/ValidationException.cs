using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        //protected ValidationException() : base(,)
        public string Property { get; protected set; }
        public ValidationException(string message) : base(message)
        {}
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
        //protected   
    }
}
