using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvalidRangeException
{
    class InvalidRangeException<T>:ApplicationException
    {
        public T Start { get; set; }
        private T End { get; set; }
        
        
        public InvalidRangeException(string message, T start, T end, Exception innerException)
            : base(message, innerException)
        {
            this.Start = start;
            this.End = end;
        }
        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {  
        }
        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }

        public override string Message
        {
            get
            {
                return string.Format("This value is out of the defined range {0:D} - {1:D}!", this.Start, this.End);
            }
        }

    }
}
