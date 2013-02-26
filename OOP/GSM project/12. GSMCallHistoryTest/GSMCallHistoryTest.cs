// Add reference to 01.GSM if necessarry

using System;
using System.Text;
using System.Collections.Generic;

namespace GSM
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            GSM myPhone = new GSM("Nokia123", "Nokia");
            Call myCall1 = new Call("0888 123 456", 15);
            Call myCall2 = new Call("0888 123 456", 35);
            Call myCall3 = new Call("0888 123 456", 70);
            
            myPhone.AddCall(myCall1);
            myPhone.AddCall(myCall2);
            myPhone.AddCall(myCall3);
            PrintCallHistory(myPhone.GetCallHistory());            

            float callPricePerMinute = 0.37f;
            //Total call time is 2 min. Result should be 0.74
            Console.WriteLine("Total calls price: {0:C}", myPhone.CalculateTotalPrice(callPricePerMinute));

            int longestCallDuration = 0;
            int longestCallIndex = 0;
            int tempIndex = 0;
            foreach (var call in myPhone.GetCallHistory())
            {
                if (call.Duration > longestCallDuration) longestCallIndex = tempIndex;
                tempIndex++;
            }
            myPhone.DeleteCall(longestCallIndex);
            //Total call time is 50 sec now. Result should be about 0.31
            Console.WriteLine("Total calls price: {0:C}", myPhone.CalculateTotalPrice(callPricePerMinute));

            myPhone.ClearCallHistory();
            PrintCallHistory(myPhone.GetCallHistory());
        }

        private static void PrintCallHistory(List<Call> CallHistory)
        {
            if (CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
                return;
            }
            Console.WriteLine("Calls in call history:");
            foreach (var call in CallHistory)
            {
                Console.WriteLine(call);
            }
        }
    }
}
