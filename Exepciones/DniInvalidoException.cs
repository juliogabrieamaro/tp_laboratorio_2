﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class DniInvalidoException: Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : base() { }

        public DniInvalidoException(Exception e)
            : this()
        {
            this.mensajeBase = e.Message;
        }

        public DniInvalidoException(string message)
            : base(message) 
        { 
        }
        public DniInvalidoException(string message, Exception e) 
            : base(message, e)
        { 
        }

    }
}
