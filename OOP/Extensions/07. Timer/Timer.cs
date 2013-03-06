using System;
using System.Threading;

class Timer
{
    public delegate void MethodDelegate();    

    public int Delay { get; set; }
    public MethodDelegate MethodProperty { get; set; }
    
    public Timer(int delay, MethodDelegate invokeMethod) //constructor
    {
        this.Delay = delay;
        this.MethodProperty = invokeMethod;
        Thread newThread = new Thread(() => //for parallel execution of methods
        {
            while (true)
            {
                this.MethodProperty();
                Thread.Sleep(this.Delay);
            }
        });
        newThread.Start();        
    }

    public static void SampleMethod()
    {
        Console.WriteLine("Call of SampleMethod at: {0}", DateTime.Now);        
    }
    public static void SampleMethod1()
    {
        Console.WriteLine("Call of SampleMethod 1 at: {0}", DateTime.Now);        
    }
    
    static void Main()
    {
        Timer timer = new Timer(2000, SampleMethod);
        Timer timer1 = new Timer(1000, SampleMethod1);
    }
}