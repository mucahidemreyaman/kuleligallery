﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        {

        }

        public AlreadyExistsException() : base()
        {

        }
    }
}
