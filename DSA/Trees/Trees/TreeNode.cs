// -----------------------------------------------------------------------
// <copyright file="TreeNode.cs" company="">
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
    public class TreeNode<T>
    {
        public T Value;
        public bool HasParrent;

        public TreeNode()
        {   
        }
        public TreeNode(T value)
            :this()
        {
            this.Value = value;
            this.HasParrent = false;
        }
    }
}
