namespace Timer
{
    using System;
    
    public class TimerTest
    {
        public static void Main()
        {
            Timer timer = new Timer(2000, SampleMethod1);
            Timer timer1 = new Timer(1000, SampleMethod2);
        }

        public static void SampleMethod1()
        {
            Console.WriteLine("Call of SampleMethod 1 at: {0}", DateTime.Now);
        }

        public static void SampleMethod2()
        {
            Console.WriteLine("Call of SampleMethod 2 at: {0}", DateTime.Now);
        }
    }
}
