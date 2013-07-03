// -----------------------------------------------------------------------
// <copyright file="Path.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trees
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Path<T>
    {
        public List<TreeNode<T>> Nodes { get; set; }

        private int sum;

        public Path()
        {
            this.Nodes = new List<TreeNode<T>>();
        }

        public Path(TreeNode<T> node)
            : this()
        {
            this.AddNode(node);
        }

        public void AddNode(TreeNode<T> node)
        {
            this.Nodes.Add(node);
        }

        public void AddSubPath(Path<T> subPath)
        {
            foreach (var node in subPath.Nodes)
            {
                this.AddNode(node);
            }
        }

        public int GetSumAsInt32()
        {
            this.sum = 0;
            foreach (var node in this.Nodes)
            {
                this.sum += Convert.ToInt32(node.Value);
            }
            return this.sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var node in this.Nodes)
            {
                sb.AppendFormat("{0}, ", node.Value);
            }
            return sb.ToString().Trim(new char[]{',', ' '});
        }
    }
}


