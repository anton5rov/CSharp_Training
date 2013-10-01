// Using delegates write a class Timer that can execute certain method at each t seconds.

namespace Timer
{
    using System;
    using System.Threading;

    public class Timer
    {
        public Timer(uint delay, MethodDelegate invokeMethod)
        {
            this.Delay = delay;
            this.MethodProperty = invokeMethod;
            Thread newThread = new Thread(() =>
            {
                while (true)
                {
                    this.MethodProperty();
                    Thread.Sleep((int)this.Delay);
                }
            });

            newThread.Start();
        }

        public delegate void MethodDelegate();

        public uint Delay { get; set; }

        public MethodDelegate MethodProperty { get; set; }
    }
}