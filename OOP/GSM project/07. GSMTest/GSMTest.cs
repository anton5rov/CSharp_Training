// Add reference to 01.GSM if necessarry

using System;

namespace GSM
{
    class GSMTest
    {
        static void Main()
        {
            GSM[] gsmArray = new GSM[3];
            gsmArray[0] = new GSM("Model-1", "Nokia", 100, "Ivancho", 
                new Battery("Nokia", 12, 100, Battery.BatteryTypes.NiCd), 
                new Display(200, 300, 64000));

            gsmArray[1] = new GSM("Model-15", "SonyEriccson", 200, "Pesho",
                new Battery("SonyEriccson", 20, 150, Battery.BatteryTypes.NiMH),
                new Display(400, 600, 64000));

            gsmArray[2] = new GSM("IPhone 4S", "Apple");
            gsmArray[2] = GSM.IPhone4S;
            gsmArray[2].Owner = "Marcheto";

            foreach (var tel in gsmArray)
            {
                Console.WriteLine(tel.ToString());
                Console.WriteLine();                
            }

            //Print only information for static property IPhone4S. No owner is set yet.
            Console.WriteLine(GSM.IPhone4S.ToString());            
        }
    }
}
