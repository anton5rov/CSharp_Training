namespace Exam
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;
    using System.Collections.Generic;

    class Supermarket
    {
        public class SupermarketQueue
        {
            public BigList<string> Queue { get; set; }

            private Dictionary<string, int> namesCountDictionary = new Dictionary<string,int>();

            public SupermarketQueue()
            {
                this.Queue = new BigList<string>();
            }

            public void Append(string name)
            {
                this.Queue.Add(name);
                AddToDictionary(name);
            }

            public void Insert(int position, string name)
            {
                if (position < 0 || this.Queue.Count < position)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (position == this.Queue.Count)
                {
                    this.Append(name);
                }
                else
                {
                    this.Queue.Insert(position, name);
                    AddToDictionary(name);
                }
            }

            public int Find(string name)
            {
                try
                {
                    return this.namesCountDictionary[name];
                }
                catch 
                {
                    return 0;
                }
            }

            public string Serve(int count)
            {
                if (count < 0 || this.Queue.Count < count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    string name = this.Queue[0];
                    sb.AppendFormat("{0} ", name);
                    this.namesCountDictionary[name]--;
                    this.Queue.RemoveAt(0);
                }
				
                // Remove last space.
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }

            private void AddToDictionary(string name)
            {
                if (!this.namesCountDictionary.ContainsKey(name))
                {
                    this.namesCountDictionary.Add(name, 1);
                }
                else
                {
                    this.namesCountDictionary[name]++;
                }
            }
        }
		
        static void Main()
        {
            SupermarketQueue superQueue = new SupermarketQueue();

            StringBuilder output = new StringBuilder();

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End")
                {
                    break;
                }
                else 
                {
                    string[] command = ParseInput(inputLine);
                    ProcessCommand(command, superQueue, output);
                }
            }
            output.Remove(output.Length - 1, 1);
			
            Console.WriteLine(output.ToString());
        }

        private static void ProcessCommand(string[] command, SupermarketQueue superQueue, StringBuilder output)
        {
            switch (command[0])
            {
                case "Append": AppendCommand(command, superQueue, output);
                    break;

                case "Insert": InsertCommand(command, superQueue, output);
                    break;

                case "Find": FindCommand(command, superQueue, output);
                     break;
                case "Serve": ServeCommand(command, superQueue, output);
                    break;
                
                default:
                    break;
            }
        }

        private static void ServeCommand(string[] command, SupermarketQueue superQueue, StringBuilder output)
        {
            try
            {
                string result = superQueue.Serve(int.Parse(command[1]));
                output.Append(result + Environment.NewLine);
            }
            catch (ArgumentOutOfRangeException)
            {
                output.Append("Error" + Environment.NewLine);
            }
        }

        private static void FindCommand(string[] command, SupermarketQueue superQueue, StringBuilder output)
        {
            int count;
            count = superQueue.Find(command[1]);
            output.Append(count + Environment.NewLine);
        }

        private static void InsertCommand(string[] command, SupermarketQueue superQueue, StringBuilder output)
        {
            try
            {
                superQueue.Insert(int.Parse(command[1]), command[2]);
                output.Append("OK" + Environment.NewLine);
            }
            catch (ArgumentOutOfRangeException)
            {
                output.Append("Error" + Environment.NewLine);
            }
        }

        private static void AppendCommand(string[] command, SupermarketQueue superQueue, StringBuilder output)
        {
            superQueue.Append(command[1]);
            output.Append("OK" + Environment.NewLine);
        }

        private static string[] ParseInput(string inputLine)
        {
            string[] split = inputLine.Split(new char[]{' '});
            return split;
        }
    }
}