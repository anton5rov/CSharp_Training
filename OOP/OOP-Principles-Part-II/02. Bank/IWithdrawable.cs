using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IWithdrawable
    {
        void MakeWithdraw(decimal sum);
    }
}
