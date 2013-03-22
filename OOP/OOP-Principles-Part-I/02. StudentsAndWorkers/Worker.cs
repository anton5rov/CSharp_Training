using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndWorkers
{
    class Worker : Human
    {
        public float WeekSalary { get; set; }
        public float WorkHoursPerDay { get; set; }
        public float MoneyPerHour { get; private set; }
        
        public Worker(string fName, string lName) : base(fName, lName) { }
        public Worker(string fName, string lName, float weekSalary)
            : this(fName, lName)
        {
            this.WeekSalary = weekSalary;
        }
        public Worker(string fName, string lName, float weekSalary, byte workHoursPerDay)
            : this(fName, lName, weekSalary)
        {   
            this.WorkHoursPerDay = workHoursPerDay;
            this.MoneyPerHour = this.CalculateMoneyPerHour();

        }
        public float CalculateMoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            strB.AppendFormat("{0} " + "{1} " + "Money per hour: {2}", this.FirstName, this.LastName, this.MoneyPerHour);
            return strB.ToString();
        }

    }
}
