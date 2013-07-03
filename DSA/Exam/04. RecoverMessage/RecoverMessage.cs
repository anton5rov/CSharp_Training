namespace Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class CharNode : IComparable<CharNode>
    {
        public char Char { get; private set; }
        public HashSet<CharNode> Children { get; private set; }
        public HashSet<CharNode> Parents { get; private set; }

        public CharNode(char ch)
        {
            this.Char = ch;
            this.Children = new HashSet<CharNode>();
            this.Parents = new HashSet<CharNode>();
        }

        public void AddChild(CharNode chNode)
        {
            this.Children.Add(chNode);
        }

        public void AddToParent(CharNode chNode)
        {
            this.Parents.Add(chNode);
        }

        public int CompareTo(CharNode other)
        {
            return this.Char.CompareTo(other.Char);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Key: {0} Childs: ", this.Char);
            foreach (var item in this.Children)
            {
                sb.AppendFormat("{0} ", item.Char);
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }

    public class RecoverMessage
    {
        public static void Main(string[] args)
        {
            Dictionary<char, CharNode> Graf = new Dictionary<char, CharNode>();

            ConstructGraf(Graf);
            List<char> bestSolution = new List<char>();
            ProcessGraf(Graf, bestSolution);
            PrintResult(bestSolution);
        }

        private static void PrintResult(List<char> bestSolution)
        {
            foreach (var ch in bestSolution)
            {
                Console.Write(ch);
            }
            
            Console.WriteLine();
        }

        private static void ConstructGraf(Dictionary<char, CharNode> Graf)
        {
            string input = Console.ReadLine();
            int numOfLines = int.Parse(input);

            for (int i = 0; i < numOfLines; i++)
            {
                input = Console.ReadLine();

                // input new line
                if (!Graf.ContainsKey(input[0]))
                {
                    CharNode firstNode = new CharNode(input[0]);
                    Graf.Add(firstNode.Char, firstNode);
                }

                for (int j = 1; j < input.Length; j++)
                {
                    if (!Graf.ContainsKey(input[j]))
                    {
                        CharNode node = new CharNode(input[j]);
                        Graf.Add(node.Char, node);
                        Graf[input[j - 1]].AddChild(node);
                        Graf[input[j]].AddToParent(Graf[input[j - 1]]);
                    }
                    else
                    {
                        Graf[input[j - 1]].AddChild(Graf[input[j]]);
                        Graf[input[j]].AddToParent(Graf[input[j - 1]]);
                    }
                }
            }
        }

        private static void ProcessGraf(Dictionary<char, CharNode> Graf, List<char> bestSolution)
        {
            if (Graf.Count == 0)
            {
                return;
            }

            char minRoot = FindMinRoot(Graf);
            
            bestSolution.Add(minRoot);

            RemoveRoot(Graf, minRoot);

            ProcessGraf(Graf, bestSolution);
        }

        private static char FindMinRoot(Dictionary<char, CharNode> Graf)
        {
            char minRoot = 'z';

            foreach (var node in Graf)
            {
                if (node.Value.Parents.Count == 0)
                {
                    if (node.Key < minRoot)
                    {
                        minRoot = node.Key;
                    }
                }
            }
            return minRoot;
        }

        private static void RemoveRoot(Dictionary<char, CharNode> Graf, char minRoot)
        {
            RemoveParentFromChildrenLists(Graf, minRoot);
            Graf.Remove(minRoot);
        }

        private static void RemoveParentFromChildrenLists(Dictionary<char, CharNode> Graf, char ch)
        {
            HashSet<CharNode> Children = Graf[ch].Children;

            foreach (var child in Children)
            {
                child.Parents.Remove(Graf[ch]);
            }
        }
    }
}

// 3
// ace
// bcd
// H
