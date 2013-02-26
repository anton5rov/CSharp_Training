using System;

namespace GSM
{
    public class Battery
    {
        public enum BatteryTypes
        {
            LiIon,
            NiMH,
            NiCd
        }

        private float hoursTalk;
        private float hourStandy;
        public string Model {get; set;}
        public float HoursTalk 
        { 
            get
            {
                return this.hoursTalk;
            } 
            set 
            {
                if (CheckExceptions.CheckNonNegative("Battery.HoursTalk", (int)value)) this.hoursTalk = value;
            } 
        }
        public float HoursStandBy 
        {
            get
            {
                return this.hourStandy;
            }
            set 
            {
                if (CheckExceptions.CheckNonNegative("Battery.HoursStandBy", (int)value)) this.hourStandy = value;
            } 
        }
        public BatteryTypes BatteryType { get; set; }
        
        public Battery()// parameterless constructor
        {
        }
        public Battery(string model, float hTalk, float hStandBy, BatteryTypes bType) // all params constructor
        {
            this.Model = model;
            this.HoursTalk = hTalk;
            this.HoursStandBy = hStandBy;
            this.BatteryType = bType;
        }
    }
}
