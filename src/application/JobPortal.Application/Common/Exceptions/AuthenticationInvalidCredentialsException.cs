﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Common.Exceptions
{
    public class AuthenticationInvalidCredentialsException : Exception
    {
        public AuthenticationInvalidCredentialsException(string message) : base(message)
        {

        }
    }
}
