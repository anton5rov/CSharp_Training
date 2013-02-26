using System;

namespace GSM
{
    public class Call
    {
        private readonly DateTime dateTime = new DateTime();
        private string DialedPhoneNumber{get; set;}
        private byte duration; // in seconds 
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
        }
        public byte Duration
        {
            get { return this.duration; }
            set 
            {
                if (CheckExceptions.CheckNonNegative("Call.Duration", value))
                   this.duration = value;
            }

        }

        public Call() : this("[Unknown number]", 0)
        {            
        }
        public Call(string dialedPhoneNumber, byte duration)
        {
            this.dateTime = DateTime.Now;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duration = duration;
        }
        public override string ToString()
        {
            return ("Date: " + this.dateTime.ToShortDateString() + " Time: " + this.dateTime.ToShortTimeString() + 
                " Dialed Number: " + this.DialedPhoneNumber + " Duration: "+ this.Duration + " sec");
        }
    }
}
