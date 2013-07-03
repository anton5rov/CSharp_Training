// -----------------------------------------------------------------------
// <copyright file="Tree.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>

    

    public class TreeWithDictionary<T>
    {
        public Dictionary<T, List<TreeNode<T>>> Nodes { get; set; }

        public TreeWithDictionary()
        {
            this.Nodes = new Dictionary<T, List<TreeNode<T>>>();
        }

        public TreeWithDictionary(T root)
            :this()
        {
            this.Nodes.Add(root, new List<TreeNode<T>>());
        }

        public TreeWithDictionary(T parent, T childValue)
            : this(parent)
        {
            AddPair(parent, childValue);
        }

        public void AddRoot(T root)
        {
            this.Nodes.Add(root, new List<TreeNode<T>>());
        }

        public void AddPair(T parent, T childValue)
        {
            TreeNode<T> child = new TreeNode<T>();
            child.Value = childValue;
            child.HasParrent = true;
            if (!this.Nodes.ContainsKey(parent))
            {
                this.Nodes.Add(parent, new List<TreeNode<T>>());
            }

            this.Nodes[parent].Add(child);

            if (!this.Nodes.ContainsKey(childValue))
            {
                this.Nodes.Add(childValue, new List<TreeNode<T>>());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Nodes.ElementAt(0).Key + Environment.NewLine);
            foreach (var de in Nodes)
            {
                foreach (var node in de.Value)
                {
                    sb.AppendFormat("{0} -> {1}", de.Key, node.Value + Environment.NewLine); 
                }
            }

            return sb.ToString();
        }
    }
}