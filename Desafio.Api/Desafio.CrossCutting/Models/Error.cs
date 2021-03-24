using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.CrossCutting.Models
{
    public class Error
    {
        public string Message { get; set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
