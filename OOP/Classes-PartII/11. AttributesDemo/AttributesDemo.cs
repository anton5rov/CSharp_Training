using System;
using System.Reflection;
using System.Collections.Generic;

namespace AttributesDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum |
                    AttributeTargets.Interface, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        private int major;
        private int minor;
        public string Version { get; private set; }
        public VersionAttribute():this(1, 0) 
        {
        }
        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
            this.Version = major + "." + minor;            
        }           
    }

    [VersionAttribute(1, 11)]
    public class Class1
    {
    }
    [VersionAttribute(2, 22)]
    public class Class2
    {
    }
    public class testAttributes
    {
        static void Main()
        {
            var typesArray = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in typesArray)
	        {
                if (type.IsClass && (type.Namespace == "AttributesDemo"))
                {
                    Object[] attirbutes = type.GetCustomAttributes(false);
                    foreach (var attr in attirbutes)
                    {
                        if (attr is VersionAttribute)
                        {
                            // cast has lower priority than '.', so additional parentheses needed
                            Console.WriteLine("{0} Version is: {1}", type.Name, ((VersionAttribute)attr).Version);
                        }
                    }
                }
            }
        }
    }
}