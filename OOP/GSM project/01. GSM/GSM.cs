//All tasks except 7 and 12 implemented in this class!
//CheckExceptions class added to process most common exceptions 
//with non-negative and positive numbers just for demonstration purposes.

using System;
using System.Text;
using System.Collections.Generic;

namespace GSM
{
    public class GSM
    {
        public string Model { get; set; }//automatic proprerty
        public string Manufacturer { get; set; }//automatic proprerty
        public float? Price { get; set; } //automatic proprerty supposed in leva 
        public string Owner { get; set; }//automatic proprerty

        // task 9 - property Call Histroy
        // property is set private to limit the acccess through the custom methods 
        // AddCall, DeleteCall, ClearCallHistory and GetCallHistory only
        private List<Call> CallHistory { get; set; }

        private Battery battery = new Battery();
        public Battery Battery // property
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        private Display display = new Display();// in pixels
        public Display Display// property
        {
            get { return this.display; }
            set { this.display = value; }
        }

        // only Model and Manufacturer constructor, using all params constructor
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        // all params constructor
        public GSM(string model, string manufacturer, float? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = battery;
            this.display = display;
            this.CallHistory = new List<Call>();
        }

        // override ToString Method
        public override string ToString()
        {
            StringBuilder GSM_Info = new StringBuilder();
            GSM_Info.Append("Model: " + this.Model);
            GSM_Info.Append(", Manufacturer: " + this.Manufacturer);
            GSM_Info.AppendFormat(", Price: {0:C}", this.Price);
            GSM_Info.AppendFormat(", Battery: (Model: {0}, Talk time: {1} hours, Stand by time: {2} hours, Type: {3})",
                this.battery.Model, this.battery.HoursTalk, this.battery.HoursStandBy, this.battery.BatteryType);
            GSM_Info.AppendFormat(", Display: ({0}x{1} pixels, Color depth: {2})", this.display.Width, this.display.Height, this.display.Colors);
            if (this.Owner != null) GSM_Info.Append(", Owner: " + this.Owner);

            return GSM_Info.ToString();
        }

        //task 6 - IPhone4S info
        private static GSM iPhone4S = new GSM("IPhone 4S", "Apple")// static field
        {
            Price = 950,
            battery = new Battery("Apple", 14, 200, Battery.BatteryTypes.LiIon),
            display = new Display(640, 960, 16777216),
        };
        public static GSM IPhone4S // static read only property
        {
            get
            {
                iPhone4S.Owner = null; //any new IPhone has no owner until set explicitly
                return iPhone4S;
            }
        }

        // task 10 - Add, Delete and Clear CallHistory methods
        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }
        public void DeleteCall(Call myCall) // remove given call
        {
            this.CallHistory.Remove(myCall);
        }
        public void DeleteCall(int index) // remove at given index
        {
            this.CallHistory.RemoveAt(index);
        }
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        public List<Call> GetCallHistory()
        {
            return this.CallHistory;
        }
        // task 11 - calculate total price of the calls in the CallHistory with given price per minute
        public float CalculateTotalPrice(float pricePerMinute)
        {
            float totalPrice = 0;
            foreach (var call in CallHistory)
            {
                totalPrice += call.Duration * pricePerMinute / 60;
            }
            return totalPrice;
        }        
    }
}
