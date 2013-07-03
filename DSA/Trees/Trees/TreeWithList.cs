// -----------------------------------------------------------------------
// <copyright file="Tree.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trees
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// TODO: Update summary.
    /// Not fully implemented.
    /// </summary>

    public class TreeWithList<T>
    {
        public TreeNodeWithList<T> Root { get; private set; }

        public Dictionary<TreeNodeWithList<T>, List<TreeNodeWithList<T>>> TreeDictionary { get; set; }

        public TreeWithList(T value)
        {
            this.Root = new TreeNodeWithList<T>(value);
            this.TreeDictionary = new Dictionary<TreeNodeWithList<T>, List<TreeNodeWithList<T>>>();
            this.TreeDictionary.Add(Root, new List<TreeNodeWithList<T>>());
        }

        public TreeWithList(T value, params TreeWithList<T>[] subtrees)
            : this(value)
        {
            this.AddNode(this.Root, subtrees);
        }

        public void AddNode(TreeNodeWithList<T> parent, params TreeWithList<T>[] subtrees)
        {
            if (!this.TreeDictionary.ContainsKey(parent))
            {
                this.TreeDictionary.Add(parent, new List<TreeNodeWithList<T>>());
            }

            foreach (var tree in subtrees)
            {
                parent.AddChild(tree.Root);
            }
        }
    }
}