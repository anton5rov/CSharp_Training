// -----------------------------------------------------------------------
// <copyright file="Article.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Article
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

        public Article()
        {
        }

        public Article(string name, int weight, int value)
            : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }
    }
}
