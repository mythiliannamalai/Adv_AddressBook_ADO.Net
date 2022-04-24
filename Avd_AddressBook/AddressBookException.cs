using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avd_AddressBook
{
    public class AddressBookException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {           
            Connection_Failed
        }
        public AddressBookException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
