// -----------------------------------------------------------------------
// <copyright file="SetOfArticles.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SetOfArticles : IComparable<SetOfArticles>
    {
        public HashSet<Article> Set { get; set; }

        public SetOfArticles()
        {
            this.Set = new HashSet<Article>();
        }

        public SetOfArticles(HashSet<Article> set)
            : this()
        {
            foreach (var article in set)
            {
                this.Set.Add(article);
            }
        }

        public void AddArticle(Article article)
        {
            this.Set.Add(article);
        }

        public int SumOfValues()
        {
            int sum = 0;
            foreach (var article in this.Set)
            {
                sum += article.Value;
            }

            return sum;
        }

        public int SumOfWeights()
        {
            int sum = 0;
            foreach (var article in this.Set)
            {
                sum += article.Weight;
            }

            return sum;
        }

        public int CompareTo(SetOfArticles other)
        {
            return this.SumOfValues().CompareTo(other.SumOfValues());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var article in this.Set)
            {
                sb.AppendFormat("{0}: weight -> {1}, cost -> {2}\r\n",
                    article.Name, article.Weight, article.Value);
            }

            sb.AppendFormat("Common weight: {0}\r\n", this.SumOfWeights());
            sb.AppendFormat("Common cost: {0}\r\n", this.SumOfValues());

            return sb.ToString();
        }
    }
}
