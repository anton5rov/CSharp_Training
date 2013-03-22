using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class Customer
    {
        public string Name { get; protected set; }
        protected Customer(string name)
        {
            this.Name = name;
        }
    }
}