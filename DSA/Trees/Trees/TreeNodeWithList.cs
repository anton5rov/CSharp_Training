// -----------------------------------------------------------------------
// <copyright file="TreeNode.cs" company="Telerik">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trees
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generic class TreeNode of T with List of nodes.
    /// Not fully implemented.
    /// </summary>

    public class TreeNodeWithList<T>
    {
        public T Value { get; set; }

        public List<TreeNodeWithList<T>> Children { get; set; }
        
        public  bool hasParent { get; set; }

        public TreeNodeWithList()
        {
            this.Children = new List<TreeNodeWithList<T>>();
        }

        public TreeNodeWithList(T value)
            : this()
        {
            this.Value = value;
        }

        public TreeNodeWithList(T value, TreeNodeWithList<T> child)
            : this(value)
        {
            this.AddChild(child);
        }

        public void AddChild(TreeNodeWithList<T> child)
        {
            child.hasParent = true;
            this.Children.Add(child);
        }

        public TreeNodeWithList<T> GetChild(int index)
        {
            return this.Children[index];
        }
    }
}