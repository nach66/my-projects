using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesClient
{
    class DoubleException : Exception
    {
        public string Value { get; set; }
        public decimal V { get; set; }

        public DoubleException()
        {
        }

        public DoubleException(string message) : base(message)
        {
        }

        public DoubleException(string message, string value) : base(message)
        {
            Value = value;
        }

        public DoubleException(string message, decimal value) : base(message)
        {
            V = value;
        }

        public DoubleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
