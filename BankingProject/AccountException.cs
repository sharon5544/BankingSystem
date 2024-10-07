using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject
{
    /// <summary>
    /// Represents the userdefined exception class
    /// </summary>
    public class AccountException : Exception
    {
        public AccountException() : base() { }

        public AccountException(string message) : base(message) { }

    }
}
